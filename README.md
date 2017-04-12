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

## Service Endpoints

Service endpoints for both the test environment and production are provided by SKAT Help Desk.

## EMCS Document Schemas (XSD)

Located in the [schema](schema) directory.

Current schema version: **1.76**

## Error Codes

### EMCS Application

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