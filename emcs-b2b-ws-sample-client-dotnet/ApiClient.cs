using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace UFSTWSSecuritySample
{
    public class ApiClient : IApiClient
    {
        public ApiClient(Settings settings)
        {
            Settings = settings;
        }

        private X509Certificate2 GetCertificate()
        {
            var certificateContent = File.ReadAllBytes(Settings.PathPKCS12);
            return new X509Certificate2(certificateContent, Settings.PKCS12Passphrase);
        }

        private void WriteEnvelope(String envelope)
        {
            var xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.OmitXmlDeclaration = true;
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.PreserveWhitespace = true;
                xmlDocument.LoadXml(envelope);
                xmlDocument.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                Console.WriteLine(stringWriter.GetStringBuilder().ToString());
            }

        }

        public async Task<XElement> CallService(IPayloadWriter payloadWriter, String endpoint)
        {
            var uri = new Uri(endpoint);

            var certificate = GetCertificate();

            var envelope = BuildEnvelope(certificate, payloadWriter);

            Console.WriteLine("REQUEST (with indentation)");
            Console.WriteLine("--------------------------");
            WriteEnvelope(envelope);


            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                request.Content = new StringContent(envelope, Encoding.UTF8, "text/xml");

                using (var response = client.SendAsync(request).Result)
                {
                    var responseEnvelope = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        // To-do: Log error
                    Console.WriteLine("Error");
                    Console.WriteLine(responseEnvelope);
                        return null;
                    }

                    Console.WriteLine("RESPONSE (with indentation)");
                    Console.WriteLine("---------------------------");
                    WriteEnvelope(responseEnvelope);


                    // https://stackoverflow.com/questions/16956605/validate-a-xml-signature-in-a-soap-envelope-with-net
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.PreserveWhitespace = true;
                    xmlDocument.LoadXml(responseEnvelope);

                    XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("wsse:BinarySecurityToken");
                    string binarySecurityToken = xmlNodeList[0].InnerText;
                    X509Certificate2 x509Certificate2 = new X509Certificate2(Convert.FromBase64String(binarySecurityToken));

                    xmlNodeList = xmlDocument.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#");
                    XmlElement signature = (XmlElement)xmlNodeList[0];
                    SignedXmlWithId signedXml = new SignedXmlWithId(xmlDocument);
                    signedXml.LoadXml(signature);

                    bool isOk = signedXml.CheckSignature(x509Certificate2, true);
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Signature verified: " + isOk);

                    Console.WriteLine(isOk);
                    // Now check that we trust the certificate 
                    var certPem = File.ReadAllText(Settings.PathPEM);
                    var cert = X509Certificate2.CreateFromPem(certPem);
                    bool isTruested = cert.Equals(x509Certificate2);
                    Console.WriteLine("Certificate trusted: " + isTruested);
                    return XElement.Parse(responseEnvelope);
                }
            }
        }

        private string BuildEnvelope(X509Certificate2 certificate, IPayloadWriter payloadWriter)
        {
            string envelope = null;

            var certificateId = string.Format("X509-{0}", Guid.NewGuid().ToString());
            var bodyId = "element-1-1272320911598-1522000";

            var dtNow = DateTime.UtcNow;
            var now = dtNow.ToString("o").Substring(0, 23) + "Z";

            // Timestamp
            var timestampExpires = dtNow.AddMinutes(50).ToString("o").Substring(0, 23) + "Z";
            var timestampId = $"TS-{Guid.NewGuid()}";

            using (var stream = new MemoryStream())
            {
                var utf8 = new UTF8Encoding(false); // Omit BOM

                using (var writer = new XmlTextWriter(stream, utf8))
                {
                    writer.WriteStartElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
                    writer.WriteAttributeString("xmlns", "soapenv", null, "http://schemas.xmlsoap.org/soap/envelope/");

                    writer.WriteStartElement("soapenv", "Header", null);

                    writer.WriteStartElement("wsse", "Security",
                        "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                    writer.WriteAttributeString("xmlns", "wsse", null,
                        "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                    writer.WriteAttributeString("xmlns", "wsu", null,
                        "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");

                    writer.WriteStartElement("wsse", "BinarySecurityToken", null);
                    writer.WriteAttributeString("EncodingType",
                        "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary");
                    writer.WriteAttributeString("ValueType",
                        "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3");
                    writer.WriteAttributeString("wsu", "Id", null, certificateId);

                    var rawData = certificate.GetRawCertData();
                    writer.WriteBase64(rawData, 0, rawData.Length);
                    writer.WriteEndElement(); //BinarySecurityToken

                    writer.WriteStartElement("wsu", "Timestamp", null);
                    writer.WriteAttributeString("wsu", "Id", null, timestampId);

                    writer.WriteElementString("wsu", "Created", null, now);

                    writer.WriteElementString("wsu", "Expires", null, timestampExpires);

                    writer.WriteEndElement(); // Timestamp

                    writer.WriteEndElement(); // Security
                    writer.WriteEndElement(); // Header

                    writer.WriteStartElement("soapenv", "Body", null);
                    writer.WriteAttributeString("xmlns", "wsu", null,
                        "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
                    writer.WriteAttributeString("wsu", "Id", null, bodyId);

                    payloadWriter.Write(writer);

                    writer.WriteEndElement(); // Body

                    writer.WriteEndElement(); //Envelope
                }

                // signing pass
                var signable = Encoding.UTF8.GetString(stream.ToArray());
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(signable);

                // https://stackoverflow.com/a/6467877
                var signedXml = new SignedXmlWithId(doc);

                var key = certificate.GetRSAPrivateKey();
                signedXml.SigningKey = key;
                signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;
                signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;

                var keyInfo = new KeyInfo();
                var x509data = new KeyInfoX509Data(certificate);
                keyInfo.AddClause(x509data);
                signedXml.KeyInfo = keyInfo;


                // Sign the wsse:BinarySecurityToken
                var referencebst = new Reference();
                referencebst.Uri = $"#{certificateId}";
                var t3 = new XmlDsigExcC14NTransform();
                referencebst.AddTransform(t3);
                referencebst.DigestMethod = SignedXml.XmlDsigSHA1Url;
                signedXml.AddReference(referencebst);


                // Sign the timestamp fragment
                var reference0 = new Reference();
                reference0.Uri = $"#{timestampId}";
                var t0 = new XmlDsigExcC14NTransform();
                reference0.AddTransform(t0);
                reference0.DigestMethod = SignedXml.XmlDsigSHA1Url;
                signedXml.AddReference(reference0);

                // Sign the body
                var reference1 = new Reference();
                reference1.Uri = $"#{bodyId}";
                var t1 = new XmlDsigExcC14NTransform();
                reference1.AddTransform(t1);
                reference1.DigestMethod = SignedXml.XmlDsigSHA1Url;
                signedXml.AddReference(reference1);



                // get the sig fragment
                signedXml.ComputeSignature();


                var xmlDigitalSignature = signedXml.GetXml();

                // modify the fragment so it points at BinarySecurityToken instead
                XmlNode info = null;

                for (int i = 0; i < xmlDigitalSignature.ChildNodes.Count; i++)
                {
                    var node = xmlDigitalSignature.ChildNodes[i];

                    if (node.Name == "KeyInfo")
                    {
                        info = node;
                        break;
                    }
                }

                info?.RemoveAll();

                var securityTokenReference = doc.CreateElement("wsse", "SecurityTokenReference",
                    "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                var reference = doc.CreateElement("wsse", "Reference",
                    "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                reference.SetAttribute("URI", certificateId);
                reference.SetAttribute("ValueType",
                    "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3");

                reference.SetAttribute("URI", "#" + certificateId);
                securityTokenReference.AppendChild(reference);
                info.AppendChild(securityTokenReference);

                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("wsse",
                    "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                nsmgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope");
                //var security_node = doc.SelectSingleNode("/soapenv:Envelope/soapenv:Header/wsse:Security", nsmgr); // To-do: Fix xpath namespace search
                var securityNode =
                    doc.SelectSingleNode(
                        "/*[local-name()='Envelope']/*[local-name()='Header']/*[local-name()='Security']");
                securityNode.AppendChild(xmlDigitalSignature);

                envelope = doc.OuterXml;
            }

            return envelope;
        }

        private class SignedXmlWithId : SignedXml
        {
            public SignedXmlWithId(XmlDocument xml) : base(xml)
            {
            }

            public override XmlElement GetIdElement(XmlDocument doc, string id)
            {
                // check to see if it's a standard ID reference
                var idElem = base.GetIdElement(doc, id);

                if (idElem == null)
                {
                    var nsManager = new XmlNamespaceManager(doc.NameTable);
                    nsManager.AddNamespace("wsu",
                        "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");

                    idElem = doc.SelectSingleNode("//*[@wsu:Id=\"" + id + "\"]", nsManager) as XmlElement;
                }

                return idElem;
            }
        }

        private Settings Settings { get; }
    }
}
