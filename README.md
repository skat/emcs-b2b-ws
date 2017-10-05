# Artefacts and information in relation to SKAT's EMCS B2B Web Services Gateway 

Repository with relevant artefacts and information in relation to SKAT's EMCS B2B Web Service Gateway 

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

## WS Security Requirements

The following sections document which security elements that must be embedded in the **wsse:Security** header in
the request and what will be received in the response.

### Namespace definitions

* `xmlns:enc="http://www.w3.org/2001/04/xmlenc#"`
* `xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"`
* `xmlns:dsig="http://www.w3.org/2000/09/xmldsig#"`
* `xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"`

### Inbound to SKAT (request)

The following **wsse:Security** headers **must** be sent in request:

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
    * The `wsu:Timestamp` header cannot exceed a 60 sec validity window. That is `wsu:Expires` cannot be 60 seconds later than `wsu:Created` 

See the following sample [request](/sample/request-test-system.xml) for a complete SOAP Envelope that fulfills
the above requirements.

**IMPORTANT**: 

* The services do not support Inclusive Prefix List as a CanonicalizationMethod. This has to be deactivated
in the client software.

### Outbound (response)

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

## Server Certificate

Server certificates available for environments:

* [Test System](/crt/emcs-b2b-server-test.crt) (**Note**: Expires on September 19, 2020)
* [Production System](/crt/emcs-b2b-server-prod.crt) (**Note**: Expires on October 26, 2017)

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
