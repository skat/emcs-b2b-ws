using System;
using System.Xml;
using System.Text;

namespace UFSTWSSecuritySample
{
  public class OIOLedsageDokumentOpret : IPayloadWriter
  {
    public OIOLedsageDokumentOpret(string seNummer, string afgiftOperatoerPunktAfgiftIdentifikator, string docPath)
    {
      SENummer = seNummer;
      AfgiftOperatoerPunktAfgiftIdentifikator = afgiftOperatoerPunktAfgiftIdentifikator;
      DocumentPath = docPath;
    }

    public void Write(XmlTextWriter writer)
    {
      var now = DateTime.UtcNow.ToString("o").Substring(0, 23) + "Z";
      var transactionId = Guid.NewGuid().ToString();

      writer.WriteStartElement("ns3", "OIOLedsageDokumentOpret_I", "urn:oio:skat:emcs:ws:1.0.1");
      writer.WriteStartElement("ho", "HovedOplysninger", "http://rep.oio.dk/skat.dk/basis/kontekst/xml/schemas/2006/09/01/");
      writer.WriteStartElement("ho", "TransaktionIdentifikator", null);
      writer.WriteString(transactionId);
      writer.WriteEndElement(); // TransaktionIdentifikator
      writer.WriteStartElement("ho", "TransaktionTid", null);
      writer.WriteString(now);
      writer.WriteEndElement(); // TransaktionTid
      writer.WriteEndElement(); // HovedOplysninger
      writer.WriteStartElement("ns3", "VirksomhedIdentifikationStruktur", "urn:oio:skat:emcs:ws:1.0.1");
      writer.WriteStartElement("ns3", "Indberetter", "urn:oio:skat:emcs:ws:1.0.1");
      writer.WriteStartElement("ns2", "VirksomhedSENummerIdentifikator", "http://rep.oio.dk/skat.dk/motor/class/virksomhed/xml/schemas/20080401/");
      writer.WriteString(SENummer);
      writer.WriteEndElement(); // VirksomhedSENummerIdentifikator
      writer.WriteEndElement(); // Indberetter
      writer.WriteStartElement("ns4", "AfgiftOperatoerPunktAfgiftIdentifikator", "urn:oio:skat:emcs:1.0.1");
      writer.WriteString(AfgiftOperatoerPunktAfgiftIdentifikator);
      writer.WriteEndElement(); // AfgiftOperatoerPunktAfgiftIdentifikator
      writer.WriteEndElement(); // VirksomhedIdentifikationStruktur
      writer.WriteStartElement("ns3", "IE815Struktur", "urn:oio:skat:emcs:ws:1.0.1");
      writer.WriteRaw(ReadXmlAndOmitHeader(DocumentPath));
      writer.WriteEndElement(); // IE815Struktur
      writer.WriteEndElement(); // OIOLedsageDokumentOpret_I
    }

    public static string ReadXmlAndOmitHeader(string filePath)
    {
      StringBuilder output = new StringBuilder();

      XmlWriterSettings writerSettings = new XmlWriterSettings
      {
        OmitXmlDeclaration = true,
        Indent = true // Optional: preserves or formats line breaks nicely
      };

      using (XmlReader reader = XmlReader.Create(filePath))
      using (XmlWriter writer = XmlWriter.Create(output, writerSettings))
      {
        reader.MoveToContent();
        writer.WriteNode(reader, defattr: true);
      }
      return output.ToString();
    }

    private string SENummer;

    private string AfgiftOperatoerPunktAfgiftIdentifikator;

    private string DocumentPath;

  }
}
