# Artefacts and information in relation to SKAT's EMCS B2B Web Services Gateway 

This repository provides relevant artefacts and information in relation to SKAT's EMCS B2B Web Service Gateway.

The SKAT's Web Service Gateway for Excise movement and Control System (EMCS) provides 22 SOAP Web Services (in total) that legal
entities may consume in ERP systems for fully automated submitting and receiving EMCS documents (XML documents). 

## Service WSDLs

The EMCS B2B Web Service Gateway provides 22 services defined by these Web Service definitions:

* [OIOBeskedAfvisningSamlingHent](wsdl/OIOBeskedAfvisningSamlingHent/OIOBeskedAfvisningSamlingHent.wsdl)
* [OIOEksportAfvisningSamlingHent](wsdl/OIOEksportAfvisningSamlingHent/OIOEksportAfvisningSamlingHent.wsdl)
* [OIOEksportGodkendelseSamlingHent](wsdl/OIOEksportGodkendelseSamlingHent/OIOEksportGodkendelseSamlingHent.wsdl)
* [OIOEUReferenceDataAnmod](wsdl/OIOEUReferenceDataAnmod/OIOEUReferenceDataAnmod.wsdl)
* [OIOEUReferenceDataHent](wsdl/OIOEUReferenceDataHent/OIOEUReferenceDataHent.wsdl)
* [OIOForsendelseAfbrydelseBeskedSamlingHent](wsdl/OIOForsendelseAfbrydelseBeskedSamlingHent/OIOForsendelseAfbrydelseBeskedSamlingHent.wsdl)
* [OIOForsinkelseForklaringOpret](wsdl/OIOForsinkelseForklaringOpret/OIOForsinkelseForklaringOpret.wsdl)
* [OIOHaendelseRapportSamlingHent](wsdl/OIOHaendelseRapportSamlingHent/OIOHaendelseRapportSamlingHent.wsdl)
* [OIOKvitteringAfvigelseBegrundelseOpret](wsdl/OIOKvitteringAfvigelseBegrundelseOpret/OIOKvitteringAfvigelseBegrundelseOpret.wsdl)
* [OIOKvitteringOpret](wsdl/OIOKvitteringOpret/OIOKvitteringOpret.wsdl)
* [OIOKvitteringSamlingHent](wsdl/OIOKvitteringSamlingHent/OIOKvitteringSamlingHent.wsdl)
* [OIOLedsageDokumentAnnulleringOpret](wsdl/OIOLedsageDokumentAnnulleringOpret/OIOLedsageDokumentAnnulleringOpret.wsdl)
* [OIOLedsageDokumentAnnulleringSamlingHent](wsdl/OIOLedsageDokumentAnnulleringSamlingHent/OIOLedsageDokumentAnnulleringSamlingHent.wsdl)
* [OIOLedsageDokumentDestinationSkiftOpret](wsdl/OIOLedsageDokumentDestinationSkiftOpret/OIOLedsageDokumentDestinationSkiftOpret.wsdl)
* [OIOLedsageDokumentDestinationSkiftSamlingHent](wsdl/OIOLedsageDokumentDestinationSkiftSamlingHent/OIOLedsageDokumentDestinationSkiftSamlingHent.wsdl)
* [OIOLedsageDokumentNotifikationOpret](wsdl/OIOLedsageDokumentNotifikationOpret/OIOLedsageDokumentNotifikationOpret.wsdl)
* [OIOLedsageDokumentNotifikationSamlingHent](wsdl/OIOLedsageDokumentNotifikationSamlingHent/OIOLedsageDokumentNotifikationSamlingHent.wsdl)
* [OIOLedsageDokumentOmdirigeretAdvisSamlingHent](wsdl/OIOLedsageDokumentOmdirigeretAdvisSamlingHent/.wsdl)
* [OIOLedsageDokumentOpret](wsdl/OIOLedsageDokumentOpret/OIOLedsageDokumentOpret.wsdl)
* [OIOLedsageDokumentOpsplitningOpret](wsdl/OIOLedsageDokumentOpsplitningOpret/OIOLedsageDokumentOpsplitningOpret.wsdl)
* [OIOLedsageDokumentSamlingHent](wsdl/OIOLedsageDokumentSamlingHent/OIOLedsageDokumentSamlingHent.wsdl)
* [OIOPaamindelseSamlingHent](wsdl/OIOPaamindelseSamlingHent/OIOPaamindelseSamlingHent.wsdl)

Current WSDL version: **1.0.1**

---

**IMPORTANT NOTE**: The above service definitions include schemas for documents to be sent or received in the SOAP Body and
none of the schemas defines the EMCS Functional Messages directly. That is, EMCS Functional Messages cannot
be sent in the SOAP Body part directly, but must be embedded in documents defined for the relevant services. 
See also below regarding *Schemas (XSD) for EMCS Functional Messages*.

---

### Transaction Ids

Each request must include a section named `HovedOplysninger` that must include the following values:

1. Transaction id (element: `TransaktionIdentifikator`) that is unique string for all transactions. That is, the transaction id **cannot** be reused in other requests.
2. Transaction time (element: `TransaktionTid`)

**Example:**

```xml
<urn:OIOLedsageDokumentOpret_I 
    xmlns:ns="http://rep.oio.dk/skat.dk/basis/kontekst/xml/schemas/2006/09/01/"
    xmlns:urn="urn:oio:skat:emcs:ws:1.0.1">
    <ns:HovedOplysninger>
        <TransaktionIdentifikator>81ADB49B-8B65-411F-9C50-76BB6DEFCBEB</TransaktionIdentifikator>
        <TransaktionTid>2017-03-14T08:47:27Z</TransaktionTid>
    </ns:HovedOplysninger>
    <urn:VirksomhedIdentifikationStruktur>
        <Indberetter>
            <VirksomhedSENummerIdentifikator>12345678</VirksomhedSENummerIdentifikator>
        </Indberetter>
        <AfgiftOperatoerPunktAfgiftIdentifikator>DK12345678303</AfgiftOperatoerPunktAfgiftIdentifikator>
    </urn:VirksomhedIdentifikationStruktur>
    <urn:IE815Struktur>
        <IE815>
        ...
        </IE815>
    </urn:IE815Struktur>
</urn:OIOLedsageDokumentOpret_I>
```

In the event of a resubmission of an IE815 using a new transaction id in `TransaktionIdentifikator` the 
semantics of the EMCS system is a follows: EMCS system will check the `LocalReferenceNumber field` in the IE815 
and if it’s already used, EMCS will respond with a message stating it’s already used. That means that it’s safe 
to retry submission of IE815 several times (until it’s succesful) given that you don’t alter the LRN.

## Service Endpoints

Service endpoints for both the test environment and production are provided by SKAT Help Desk.

## Schemas (XSD) for EMCS Functional Messages

Some of the above 22 services must embed EMCS Functional Messages as part of the SOAP request and these documents
are defined by schemas (or XSD files) located in the [schema](schema) directory.

Current schema version: **1.76**

## Service invocation intervals: Terms of use 

* Services for **submitting** IE documents must be invoked 3 seconds apart.
* Services for **receiving** IE documents must be invoked 5 minutes (300 seconds) apart. Companies may decided to increase the interval.

Concurrent calls are not permitted.

## Security

All services are accessible via the Internet using the secure transport protocol **HTTPS** and configured with
Web Services Security requiring authentication, signing, and 
encryption using x.509 certificates issued by [NemID](https://www.nemid.nu) (Certificate Authority) of type OCESII 
(In Danish: *Offentlige Certifikater til Elektronisk Service II*). The Web Services Security is based on [Web Services Security: SOAP Message Security 1.0 WS-Security 2004 - OASIS Standard 200401, March 2004 ](https://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0.pdf)

There are two parties in the communication:

1. **Client** - The software client of the company (legal entity) consuming services on the Web Service Gateway for EMCS.
2. **Service** - The Web Service Gateway for EMCS provided by SKAT

Both parties have OCESII certificates:

* **Client(OCESII, Certificate)** - OCESII Certificate identifying the company (legal entity)
* **Service(OCESII, Certificate)** - OCESII Certificate identifying the Web Service Gateway for EMCS

The **Client(OCESII, Certificate)** *must* be of type **VOCES** that identify a legal entity. **Service(OCESII, Certificate)** is a VOCES type
certficate. For more details on **VOCES** see [here](https://www.nemid.nu/dk-da/om-nemid/historien_om_nemid/oces-standarden/oces-certifikatpolitikker/VOCES_Certifikatpolitik_version_4_Eng.pdf)
*NOTE*: OCESII certificates are also provided as types MOCES, POCES, and FOCES. None of these are supported
by the Web Service Gateway for EMCS.

In addition, the Web Service Gateway for EMCS presents a SSL certificate for the secure transport (HTTPS). 
*NOTE*: This SSL certificate is **NOT** identical with the **Service(OCESII, Certificate)** certificate.

The **Client** should always check (strongly recommended) if **Service(OCESII)** is still valid or and not revoked by NemID.
In addition, **Service(OCESII, Certificate)** must be trusted by the **Client**. This may be done by adding **Service(OCESII)** to a keystore 
(or similar type of secure wallet) in the **Client** installation or have the **Client** extract **Service(OCESII, Certificate)** 
from the service WSDL and runtime check the certificate chain (to the Root CA).

**Service(OCESII, Certificate)** is found [below](#server-certificate)

### Provision Client(OCESII, Certificate) in SKAT's IAM

The **Client(OCESII, Certificate)** must be provisioned in SKAT's IAM prior to any service invocations against
the Web Service Gateway for EMCS.

**IMPORTANT: The EMCS B2B Web Service Gateway is only available to legal entities registered in the [The Central Business Register](https://datacvr.virk.dk/data/?language=en-gb&).**

**STEP 1:** First, the legal entity may use an existing VOCES certificate or may have to order a now or another VOCES 
certificate from [nets.eu](https://www.nets.eu/dk-da/l%C3%B8sninger/nemid/virksomhedssignatur). 

* VOCES certificates is a self-service process and requires another certificate with administrative privileges designated: *MOCES with LRA*.
    * *MOCES with LRA* certificates are ordered from [nets.eu](https://www.nets.eu/dk-da/l%C3%B8sninger/nemid/medarbejdersignatur) (a legal entity may already have a *MOCES with LRA* certificate).
* NETS.eu provide both **TEST** and **PRODUCTION** certificates. 
    * **TEST** certificates are not permitted in the production system of EMCS B2B Web Service Gateway
    * **PRODUCTION** certificates are not permitted in the test system.
* If the legal entity (A) is under obligation to use the EMCS system and (A) has delegated the task comply with this
obligation to another legal entity (B), e.g. as data broker, it's the **Client(OCESII, Certificate)** of (B) that must be 
provisioned in SKAT's IAM. Not (A), but (A) must authorize (B) in SKAT's IAM.

**The following steps can only be completed using a *MOCES with LRA* certificate**

**STEP 2:** Identify id of **Client(OCESII, Certificate)**

Display the certificate of using the the `keytool` command (part of Java/JDK) and locate the `UID:xxxxxx` value. The 
`xxxxxx` part is the id of **Client(OCESII, Certificate)**

Example where id = `1282309369161`: 

```
$ keytool -list -v -keystore VOCES_XYZ.pkcs12 -storetype PKCS12
Enter keystore password:  *******
Keystore type: PKCS12
Keystore provider: SunJSSE

Your keystore contains 1 entry

Alias name: VOCES_ALIAS
Creation date: 2017-10-01
Entry type: keyEntry
Certificate chain length: 2
Certificate[1]:
Owner: SERIALNUMBER=CVR:123456789-UID:1282309369161 + CN=VOCESFORB2B, O=COMPANY_XYZ // CVR:12345678, C=DK
...
```

**STEP 3:** Login using *MOCES with LRA* on [skat.dk](http://www.skat.dk/). Navigate as follows (menu items in Danish):

* Menu item **Rettigheder til selvbetjening**
* Menu item **Gruppér rettigheder (roller)**

![asset-navigate](/assets/navigate.png)

**STEP 4:** Create **system role** by selecting the button **Ny rolle**.

![asset-newrole](/assets/newrole.jpg)

Select **Domæne** = *EMCS* and **Indberetningsområde** = *Alle*.

![asset-setdomain](/assets/setdomain.png)

**Hint**: It's also on this screen legal entity (B) selects legal entity (A) as client.

Selecting business area **Alle** ensures that the certificate being provisioned is permitted to do transactions
for all business areas and it also ensures that the **EMCS_B2B_SECURITY_PRG** authorization is part of the role 
by default.  **EMCS_B2B_SECURITY_PRG** is the authorization that enables the certificate being provisioned to 
communicate with the Web Service Gateway for EMCS.

When done, select **Gem**

You should now see user defined role:

![asset-seeudr](/assets/seeudr.png)

**STEP 5:** Create system user and map certificate

Nagivate as follows:

* Menu item **Tildel medarbejder rettigheder (roller)**
* Link item **Tildel/fjern rettigheder der anvendes i system-til-system løsninger**

![asset-createsys](/assets/createsys.png)

Choose **Ny systembruger**

![asset-createsys_button](/assets/createsys_button.jpg)

Enter the **UID** value identified in **Step 2** above and choose **Gem**

![asset-enter_uid](/assets/enter_uid.png)

The system user is now created and mapped to the **VOCES** certificate.

![asset-user_created](/assets/user_created.jpg)

**STEP 6**: Assign **system role** to system user

Choose **Rettigheder**

![asset-sys_roles](/assets/sys_roles.jpg)

Then select the role defined in **STEP 4** to system user and the choose **Vælg rettighed**.

![asset-save_role](/assets/assign_role.png)

**IMPORTANT**: If you did not select **Indberetningsområde** = *Alle* in **STEP 4** then you will
have to assign **Adgang til EMCS B2B Systembruger** too.

Finally, choose **Gem**

![asset-assign_role](/assets/assigned_roles.png)

Done. **The certificate is now provisioned and ready for use.**

## Brief security perspective on service consumption - step-by-step

Given the **Client** trusts **Service(OCESII, Certificate)** and the **Client** has produced a **Request** the process is as follows:

1. The **Client** initiates a connection (using HTTPS) with the Web Services Gateway for EMCS.
2. The **Client** adds a timestamp, signs the **Request** with **Client(OCESII, Private Key)**, encrypts the request 
with **Server(OCESII, Public Key)**, and adds **Client(OCESII, Certificate)** as security token to the **Request**
3. The **Service** authenticates the request based on the **Client(OCESII, Certificate)** security token in SKAT's IAM.
Authentication includes checking validity, revocation status of **Client(OCESII, Certificate)**, and finally if
**Client(OCESII, Certificate)** has been authorized in the SKAT's IAM for the called endpoint.
4. The **Service** decrypts the request using **Service(OCESII, Private Key)** and checks the signature using
**Client(OCESII, Public Key)** (that is, if it was signed by **Client(OCESII, Private Key)**).
5. Following successful completion of steps 3. and 4. the request is forwarded to the EMCS system.
6. The **Service** will always provide a **Response** for all calls. This **Response** is signed with **Service(OCESII, Private Key)** 
and encrypted using **Client(OCESII, Certificate)**.
7. The **Client** receives the **Response** and must decrypt it using **Client(OCESII, Private Key)**, verify the signature 
using the **Service(OCESII, Certificate)**, and finally check the timestamp. If successful, the client has a valid response.

## WS Security Policy Requirements

The following sections document which security elements that must be embedded in the **wsse:Security** header in
the request and what will be received in the response.

### Namespace definitions

* `xmlns:enc="http://www.w3.org/2001/04/xmlenc#"`
* `xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"`
* `xmlns:dsig="http://www.w3.org/2000/09/xmldsig#"`
* `xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"`

### Inbound to from Client to Service (request)

The following **wsse:Security** headers **must** be sent in request:

* `wsse:BinarySecurityToken`. This token is the OCESII certificate that carry the identity of the caller.
* `enc:EncryptedKey` using this configuration:
    * Security Token Reference = Key Identifier
    * Transport Algorithm: `http://www.w3.org/2001/04/xmlenc#rsa-1_5`
    * Symmetric Encryption Algorithm: `http://www.w3.org/2001/04/xmlenc#tripledes-cbc`
    * Parts to Encrypt:
        * `soap:Body`
* `dsig:Signature` using this configuration:
    * Security Token Reference = Direct Reference
    * Signature algorithm = `http://www.w3.org/2000/09/xmldsig#rsa-sha1`
    * Parts to Sign:
        * `soap:Body` 
        * `wsse:BinarySecurityToken` (part of `soap:Header/wsse:Security`). This token is the OCESII certificate that carry the identity of the caller.
        * `wsu:Timestamp` (part of `soap:Header/wsse:Security`)
* `wsu:Timestamp` using this configuration:
    * Must have `wsu:Created` field set.
    * Must have `wsu:Expires` field set.
    * The `wsu:Timestamp` header cannot exceed a 60 sec validity window. That is, `wsu:Expires` cannot be 60 seconds later than `wsu:Created` 

See the following sample [request](/sample/request-test-system.xml) for a complete SOAP Envelope that fulfills
the above requirements.

**IMPORTANT**: 

* The services do not support Inclusive Prefix List as a CanonicalizationMethod. This has to be deactivated
in the client software.

### Outbound from Service to Client (response)

The following **wsse:Security** headers **will** be returned in response:

* `enc:EncryptedKey` using this configuration:
    * Security Token Reference = Key Identifier
    * Transport Algorithm: `http://www.w3.org/2001/04/xmlenc#rsa-1_5`
    * Symmetric Encryption Algorithm: `http://www.w3.org/2001/04/xmlenc#tripledes-cbc`
    * Parts encrypted:
        * `soap:Body` 
* `wsse:BinarySecurityToken` 
* `dsig:Signature`        
    * Security Token Reference = Direct Reference
    * Signature algorithm = `http://www.w3.org/2000/09/xmldsig#rsa-sha1`
    * Parts signed:
        * `soap:Body` 
        * `wsse:BinarySecurityToken` (part of `soap:Header/wsse:Security`). This token is the OCESII certificate used to sign the response.
        * `wsu:Timestamp` (part of `soap:Header/wsse:Security`)
* `wsu:Timestamp` using same configuration as inbound (*see* above).

See the following sample [response](/sample/response-test-system.xml) for a complete SOAP Envelope that fulfills
the above requirements.

## Server Certificates

Server certificates available for environments:

* [Test System](/crt/emcs-b2b-server-test.crt) (**Note**: Expires on September 19, 2020)
* [Production System](/crt/emcs-b2b-server-prod.crt) (**Note**: Expires on October 30, 2017)
* [Production System](/crt/emcs-b2b-server-prod-as-of-20171026.crt) (**Note**: Valid from October 26,  2017. Expires on September 19, 2020)

In brief, this certificate is used for inbound (client side) encryption of payload and outbound signing (server side)
of payload as explained above.

## Error Codes

The EMCS B2B Web Services always return a `HovedOplysningerSvar` part with same `TransaktionIdentifikator` that was
provided in the request. The `HovedOplysningerSvar` element may also include an error that includes:
 
* error code
* error texts

**Example**: Response with error code 2000.

```xml
<urn:OIOLedsageDokumentOpret_O xmlns:urn="urn:oio:skat:emcs:ws:1.0.1">
    <ns:HovedOplysningerSvar 
        xmlns:ns="http://rep.oio.dk/skat.dk/basis/kontekst/xml/schemas/2006/09/01/">
        <ns:TransaktionIdentifikator>81ADB49B-8B65-411F-9C50-76BB6DEFCBEB</ns:TransaktionIdentifikator>
        <ns:ServiceIdentifikator>OIOLedsageDokumentOpretService</ns:ServiceIdentifikator>
        <ns:TransaktionTid>2017-03-14T08:47:27Z</ns:TransaktionTid>
        <ns:SvarStruktur>
            <ns:FejlStruktur>
                <ns:FejlIdentifikator>2000</ns:FejlIdentifikator>
                <ns:FejlTekst>Denne service er midlertidigt ude af drift.</ns:FejlTekst>
            </ns:FejlStruktur>
        </ns:SvarStruktur>
    </ns:HovedOplysningerSvar>
</urn:OIOLedsageDokumentOpret_O>
```

### EMCS Application

The following table lists the error codes generated by the EMCS System:

| Error Code | Error description                                                                                                                                                                                                 |
| -----------| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 130 |	Der blev ikke fundet nogen beskeder som matcher de indikeret søgeparametre                                                                                                                                               |
| 132 |	Beskeden er modtaget men et ARC-nummer er ikke returneret. Den afventer nu godkendelse fra en myndighedsperson. Siden forsendelse har afhentningssted sat til "Import" skal den først godkendes af en myndighedsperson.  |
| 400 |	Beskedens format er ikke gyldig                                                                                                                                                                                          |
| 401 |	Message Recipient i IE beskeden er ikke gyldig                                                                                                                                                                           |
| 402 |	Markering for udsat indsendelse (deferred submission flag) er påkrævet i denne besked. Hvis datoen for forsendelsen ikke er i dag skal markering for udsat indsendelse være sat til.                                     |
| 410 |	Den angivet vareafsender (consignor) har ikke tilladelse til at oprette ledsagdokumenter                                                                                                                                 |
| 411 |	Den angivet varemodtager (consignee) har ikke tilladelse til at oprette kvitteringer                                                                                                                                     |
| 412 |	Den angivet økonomiske operatør kan ikke oprette forklaring på forsinkelser                                                                                                                                              |
| 413 |	Den angivet økonomiske operatør kan ikke oprette destinationsskift                                                                                                                                                       |
| 414 |	Den angivet økonomiske operatør kan ikke oprette annulleringer                                                                                                                                                           |
| 415 |	Den angivet økonomiske operatør kan ikke oprette anmodelser om reference data                                                                                                                                            |
| 420 |	Den angivet vareafsender (consignor) har ikke tilladelse til at oprette ledsagdokumenter på en eller flere af de angivende produkt koder                                                                                 |
| 421 |	Den angivet vareafsender (consignee) har ikke tilladelse til at oprette ledsagdokumenter på en eller flere af de angivende produkt koder                                                                                 |
| 422 |	Varemodtageren mangler                                                                                                                                                                                                   |
| 423 |	Den angivet varemodtager (consignee) har ikke en rolle som er mulig i forhold til den indikeret kode for destinationstype (destination type code)                                                                        |
| 424 |	Den angivet varemodtager (consignee) har ikke den påkrævet rolle                                                                                                                                                         |
| 425 |	Operationen er ikke tilladt da den angivet virksomhed i AfgiftOperatoerPunktAfgiftIdentifikator i VirksomhedIdentifikationStruktur ikke har en relation til forsendelsen                                                 |
| 426 |	Invalid customs office                                                                                                                                                                                                   |
| 427 |	IE818 is set to status Pending                                                                                                                                                                                           |
| 491 |	Den indsendte IE besked har resulteret i en forretningsfejl IE704                                                                                                                                                        |
| 490 |	Det er sket en teknisk fejl                                                                                                                                                                                              |
| 494 |	Message identifier has been already used                                                                                                                                                                                 |
| 496 |	MSA of Split constraint                                                                                                                                                                                                  |
| 495 |	LRN is already used                                                                                                                                                                                                      |

### EMCS B2B Gateway

The following table lists the error codes generated by the EMCS Web Services. That is, these are errors
generated before the request has reached the EMCS system.

| Error Code | Error description                                                                                                                                                                                                 |
| -----------| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 300        | SE nummeret {0} har ingen tilhoersforhold til det anvendte certifikat                                                                                                                          |
| 301        | Punktafgiftnummeret angivet i AfgiftOperatoerPunktAfgiftIdentifikator er ikke et gyldigt punktafgiftnummer                                                                                     |
| 302        | Den angivet afgift operatoer har enten ikke tillades til at udfoere denne operation eller har ikke delegeret sine rettigheder til det firma hvis certifikat er anvendt i kaldet af webservicen |
| 100        | Feltet 'VirksomhedSENummerIdentifikator' skal udfyldes                                                                                                                                         |
| 101        | Feltet 'AfgiftOperatoerPunktAfgiftIdentifikator' skal udfyldes                                                                                                                                 |
| 102        | Feltet 'AfgiftOperatoerPunktAfgiftIdentifikator' er ikke korrekt opbygget                                                                                                                      |
| 103        | Feltet 'TraderExciseNumber' er ikke udfyldt i IE-beskeden                                                                                                                                      |
| 103        | Feltet 'TraderId' er ikke udfyldt i IE-beskeden                                                                                                                                                |
| 104        | Den angivet afgift operatoer stemmer ikke overens med vareafsender (consignor) i IE815 beskeden                                                                                                |
| 104        | Den angivet afgift operatoer stemmer ikke overens med varemodtager (consignee) i IE818 beskeden                                                                                                |
| 105        | IE818-besked mangler                                                                                                                                                                           |
| 105        | IE815-besked mangler                                                                                                                                                                           |
| 500        | Det anvendte transaktions-ID er allerede benyttet i et tidligere kald                                                                                                                          |
| 1000       | Der er sket en teknisk fejl i denne B2B-service. Kontakt venligst SKAT                                                                                                                         |
| 2000       | Denne service er midlertidigt ude af drift                                                                                                                                                     |

## Test Data

See [test data repository](https://github.com/skat/emcs-b2b-ws-test-data)

## Sample Web Service Clients

* [Java](https://github.com/skat/emcs-b2b-ws-sample-client-java)
* [.NET](https://github.com/skat/emcs-b2b-ws-sample-client-dotnet)

**NOTE**: Please note that the .NET client is currently being upgraded to the latest .NET version and frameworks.

## Useful tools

* [Certificate Decoder](https://www.sslshopper.com/certificate-decoder.html) - Use this tool to decode certificates
if `openssl` or `keytool` is not an option.
