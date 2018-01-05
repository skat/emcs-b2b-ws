# Ændringslog for EMCS’ B2B implementeringsvejledning

Brief summary in English: This document is changelog for EMCS B2B Web Services.

### V3.14 til v3.15 Januar 2018 

* Opgraderet .NET-klienten til .NET 4.6.1 og WCF (den gamle baseret på WSE 3.0 vil stadig være tilgængelig)

### V3.13 til v3.14 November 2017 

* Migreret teknisk dokument "Beskrivelse af SKATs Business-2-Business Gateway Webservicekald via B2B Gateway på SKATs Infrastruktur Platform" (B2B vejledning v1.1.pdf) til GitHub
* Migreret teknisk dokument "Produktionsinformation - certifikater og WSDL filer v1.3.pdf" til GitHub

### V3.12 til v3.13 April 2017 

* Opgraderet Java-klienten til Java 8 med brug af open source.
* Migreret kildekode (Java og .NET) samt teknisk dokumentation til GitHub
* Dokumentet ”Oversigt over funktionelle beskeder, webservices og beskrivelse af scenarier” er opdateret. Se ændringerne inde i dokumentets versionsstyringstabel.
* Dokumentet ”Tilgængelige testvirksomheder til tests når der anvendes DanId testcertifikat v1.1” er opdateret med link til OCES II virksomhedstestcertifikat.
* Dokumentet ”Beskrivelse af struktur og design af de funktionelle beskeder v1.2” er opdateret med nyt link til Unicode 6.1.0.

### V3.11 til v3.12 11/02/2016

* I starten af 2016 (medio februar) lanceres FS3.2 af EMCS systemet. Dette betyder, at de nuværende beskeder vil blive opdateret, og et nyt sæt af EU XSD-filer skal anvendes til at generere de beskeder, som systemet forventer at modtage, når FS3.2 bliver lanceret. Udover versionsændringerne til XSD’erne er der følgende strukturændringer:
    * IE871: Det er nu et krav, at en af de to følgende strukturer skal være til stede ANALYSIS og F38. Rule068 erstattes af Rule232 på felt ”Body Record Unique Reference”
    * Alle nye XSD’er kan findes i ”emcs_B2B_xsd_FS3.2_v1.0.zip” pakken
* Følgende dokumenter er tilføjet som FS3.2 version:
    * Dokumentet ”Oversigt over beskedstruktur” er kommet i en FS3.2 version ved navnet ”Oversigt over beskedstruktur for FS3.2 v1.0.xls”
    * Pakken med XSD filer til at generere IE beskeder er kommet i en FS3.2 version ved navnet ”emcs_B2B_xsd_FS3.2_v1.0.zip”.
    * Dokumentet med tekniske kodelister er kommet i en FS3.2 version ved navnet ” ECP3-FITSDEV3-SC01-DDNEA_P3_APP_B_177-EN.doc”
    * Dokumentet med forretningskodelister er kommet i en FS3.2 version ved navnet ”FESS 3.41 - APPENDIX B LIST OF CODES.doc”
    * Både DDNEA’en og FESS’en er nu tilgængelig i den version som er gældende for FS3.2. For DDNEA’en er dette v1.77 og for FESS’en er det v.3.65
* Information om testdata kan findes i dokumentet ”Tilgængelig test virksomheder for DanIds testcertifikat FS3.2 v1.0”. Dokumentet er en opdatering af ”Tilgængelig test virksomheder for DanIds testcertifikat FS3.2 v1.0”.

### V3.10 til v3.11 13/02/2014

* I starten af 2014 (medio februar) lanceres FS3.1 af EMCS systemet. Dette betyder, at de nuværende beskeder vil blive opdateret, og et nyt sæt af EU XSD-filer skal anvendes til at generere de beskeder, som systemet forventer at modtage, når FS3.1 bliver lanceret. Udover versionsændringerne til XSD’erne er der følgende strukturændringer:
* IE813: elementet ”ComplementaryInformation” er tilføjet
* IE815: for elementet ”ReferenceOfTaxWarehouse” er typen ændret
* IE815: for elementet ”Package” er betingelsen ændret
* IE825: elementerne ”AlcoholicStrength", ”DegreePlato" og "SizeOfProducer" er fjernet
Alle nye XSD’er kan findes i ”emcs_B2B_xsd_FS3.1_v1.0.zip” pakken
* Følgende dokumenter er tilføjet som FS3.1 version:
    * Dokumentet ”Oversigt over beskedstruktur” er kommet i en FS3.1 version ved navnet ”Oversigt over beskedstruktur for FS3.1 v1.0.xls”
    * Pakken med XSD filer til at generere IE beskeder er kommet i en FS3.1 version ved navnet ”emcs_B2B_xsd_FS3.1_v1.0.zip”.
    * Dokumentet med tekniske kodelister er kommet i en FS3.1 version ved navnet ”DDNEA 1.71 (Phase 3) - APPENDIX B CODELISTS.doc”
    * Dokumentet med forretningskodelister er kommet i en FS3.1 version ved navnet ”FESS 3.61- APPENDIX B LIST OF CODES.doc”
    * Både DDNEA’en og FESS’en er nu tilgængelig i den version som er gældende for FS3.1. For DDNEA’en er dette v1.71 (Phase 3) og for FESS’en er det v.3.61.
    * Information om testdata kan findes i dokumentet ”Tilgængelig test virksomheder for DanIds testcertifikat FS3.1 v1.0”. Dokumentet er en opdatering af ”Tilgængelig test virksomheder for DanIds testcertifikat FS2 v1.1”.

### v3.09 til v3.10 11/01/2012

* Mindre rettelse i dokumentet ”Oversigt beskeder og scenarier for EMCS”. Det er gået fra version v3.2 til v3.3.
* Zip filen med alle dokumenterne er gået fra version v3.6 til v3.7 for at reflektere ændringerne i de andre dokumenter.

### v3.08 til v3.09 03/01/2012

* EMCS' B2B løsning er nu i produktion med alle 22 webservices som er en del af FS2 løsningen.
* Dokumentet ”emcs-b2b-fejlkoder” er opdateret med nye fejlkoder som kan modtages i HovedOplysningSvar. Dokument er gået fra version v2.0 til v2.1.
* Alle FS1 dokumenter er blevet fjernet fra vejledningen da disse ikke er relevante længere.
* Zip filen med alle dokumenterne er gået fra version v3.5 til v3.6 for at reflektere ændringerne i de andre dokumenter.

### v3.07 til v3.08 21/12/2011

* Alle WSDL-filerne til produktion for FS2 er nu tilgængelige. Dette er inklusiv de 8 nye services som kommer i FS2. Bemærk at alle services fra FS1 kan findes på samme adresse når der skiftes til FS2. Filen ”emcs-b2b-produktion-wsdl” er gået fra version v2.1 til v3.0.
* Der gøres opmærksom på følgende nyhedsbrev omkring EMCS’ nedetid henover nytår: http://www.skat.dk/SKAT.aspx?oId=1976949&vId=0.
* Zip filen med alle dokumenterne er gået fra version v3.4 til v3.5 for at reflektere ændringerne i de andre dokumenter.

### v3.06 til v3.07 01/12/2011

* Servicen OIOLedsageDokumentOpsplitningOpret (send IE825) er nu klar til tests. Desuden er de to ekstra services OIOEksportGodkendelseSamlingHent og OIOEksportAfvisningSamlingHent til at hente og modtage henholdsvis IE829 og IE839 nu også tilgængelige i testmiljøet. Pakken med test WSDL ”emcs-b2b-test-wsdl” er gået fra v3.0 til v3.1. 
* Mindre rettelser til ”Oversigt over beskedstruktur for FS2” (dokumentet er gået fra v1.5 til v1.6): 


*Modtageren på IE815 til eksport er altid et dansk ekspeditionssted og ikke en specifik virksomhed eller et andet lands ekspeditionssted. Det skyldes at den faktiske modtager vil stå på udførselsangivelsen og derfor er ledsagedokumentet kun et dokument gældende fra afsenderens lokation frem til ekspeditionsstedet. I praksis betyder det:*
* *at DeliveryPlaceCustomsOffice skal være et dansk ekspeditionssted i en IE815 til eksport.*
* *at man ikke skal udfylde ConsigneeTrader informationen i en IE815 til eksport. Denne vil system automatisk udfylde med adressen på det danske ekspeditionssted angivet i DeliveryPlaceCustomsOffice.*
*Når der udføres en ændring af destination hvor DestinationTypeCode=6, må DeliveryPlaceCustomsOffice godt være et ekspeditionssted i et andet land da det er muligt for forsendelsen at være fysisk til stede i et andet land end Danmark.*


* Zip filen med alle dokumenterne er gået fra version v3.3 til v3.4 for at reflektere ændringerne i de andre dokumenter.

### v3.05 til v3.06 17/11/2011

* Dokumentet ”Oversigt beskeder og scenarier for” er opdateret fra v3.1 til v3.2 og indeholder nu information om to nye beskeder på B2B-løsninge: IE829 og IE839. Der er også tilføjet ekstra information om HovedOplysning elementet for at tydeliggøre at man modtager et HovedOplysningSvar i alle output elementer på alle services.
* Tilføjet IE829 og IE839 til ”Oversigt over beskedstruktur for FS2”. Dokumentet er gået fra version v1.4 til v1.5.
* Dokument ”emcs-b2b-fejlkoder” er opdateret med nye fejlkoder som kan modtages i HovedOplysningSvar. Dokument er gået fra version v1.0 til v2.0.
* Tilføjet præcisering om at der er OCES I certifikat som skal hentes på DanIds hjemmeside i dokumentet ” Tilgængelig test virksomheder for DanIds testcertifikat FS2”. Dokument er gået fra version v1.0 til v1.1.
* Zip filen med alle dokumenterne er gået fra version v3.2 til v3.3 for at reflektere ændringerne i de andre dokumenter.

### v3.04 til v3.05 03/11/2011

* Alle FS2 services er tilgængelig til test fra 04. november som tidligere annonceret. WSDL-filerne kan findes i zip filen ”emcs-b2b-test-wsdl v3.0.zip”. Dog har der Skats interne test vist sig at være nogle udfordringer med den service som skal håndtere en opsplitning og derfor er denne ene service desværre ikke fuldt operationel på nuværende tidspunkt men der arbejdes på sagen.
* I produktion er B2B serverens certifikat blevet skiftet. Derfor er produktions WSDL pakken opdateret med den nye offentlige nøgle. Pakken ”emcs-b2b-produktion-wsdl” er gået fra version 2.0 til 2.1.
* Zip filen med alle dokumenterne er gået fra v3.1 til v3.2 for at reflektere ændringerne i de andre dokumenter.

### v3.03 til v3.04 27/10/2011

* Information om testdata for test af FS2 B2B services er nu tilgængelig. Information kan findes i dokumentet ”Tilgængelig test virksomheder for DanIds testcertifikat FS2 v1.0”
* Mindre rettelser til ”Oversigt over beskedstruktur for FS2”. Tilføjet ny information om at type 2 i feltet ”SubmissionMessageType” i en IE815 besked ikke kan anvendes i Danmark. Bemærk at type 2 ikke handler om almindelig eksport men ”eksport under en hjemstedsordning”. Almindelig eksport er selvfølgelig stadig mulig. Dokumentet er gået fra version v1.3 til v1.4.
* Information om strukturen ”SøgeParametreStruktur” i Dokumentet ”Oversigt over beskedstruktur” er rettet. Dette kan også ses i dokumentets versionsstyring. Dokumentet er gået fra version v3.0 til v3.1.
* Zip filen med alle dokumenterne er gået fra v3.0 til v3.1 for at reflektere ændringerne i de andre dokumenter.

### v3.02 til v3.03 10/10/2011

* Information om hvornår FS2 kan testes er tilføjet til siden.
* Rettelse af mindre fejl i ”Oversigt over beskedstruktur for FS2”. Flere markering på ændring mellem FS1 og FS2 er tilføjet til IE818. Dokumentet er gået fra version v1.2 til v1.3.
* Zip filen med alle dokumenterne er gået fra v2.9 til v3.0 for at reflektere ændringerne i de andre dokumenter.

### v3.01 til v3.02, 27/09/2011

* Rettelse af manglende felt (Downstream ARC) i IE803 i ”Oversigt over beskedstruktur for FS2”. Dokumentet er gået fra version v1.1 til v1.2.
* Zip filen med alle dokumenterne er gået fra v2.8 til v2.9 for at reflektere ændringerne i de andre dokumenter.

### v3.00 til v3.01, 15/09/2011

* IE813 XSD-filen har været i en forkert version i ” emcs_B2B_xsd_FS2_v1.0.zip” pakken. Den rigtige version er nu tilføjet og pakken er ændret til version v1.1.
* IE813 XSD-filen har manglet i DDNEA’en for FS2. Den er nu tilføjet.
* Rettelse af mindre fejl i ”Oversigt over beskedstruktur for FS2”. Dokumentet er gået fra version v1.0 til v1.1.
* Zip filen med alle dokumenterne er gået fra v2.7 til v2.8 for at reflektere ændringerne i de andre dokumenter.

### v2.60 til v3.00, 02/09/2011

* I starten af 2012 lanceres FS2 (Phase 3) af EMCS systemet. Dette har også en betydning for B2B integrationen, hvor de nuværende beskeder vil blive opdateret, og nye beskeder vil blive tilføjet. Helt konkret betyder det, at et nyt sæt af EU XSD-filer skal anvendes til at generere de beskeder, som systemet forventer at modtage, når FS2 bliver lanceret. Bemærk at alle beskeder har fået en ny XSD-fil fra FS2 af, og at systemet vil afvise modtagelse af de gamle FS1 beskeder, når FS2 er i luften. Implementeringsvejledningen er blevet opdateret, så den nu indeholder information om FS2 funktionaliteten. Siden FS0/FS1 funktionalitet stadig er kørende frem til 2012, vil det nu for flere dokumenter findes både en FS0/FS1 og en FS2 version. Følgende dokumenter er tilføjet som FS2 version:
    * Dokumentet ”Oversigt over beskedstruktur” er kommet i en FS2 version ved navnet ”Oversigt over beskedstruktur for FS2 v1.0.xls”
    * Pakken med XSD filer til at generere IE beskeder er kommet i en FS2 version ved navnet ”emcs_B2B_xsd_FS2_v1.0.zip”. FS1 version hedder nu ”emcs_B2B_xsd_FS1_v2.1.zip”
    * Dokumentet med tekniske kodelister er kommet i en FS2 version ved navnet ”DDNEA 1.51 FS2 (Phase 3) - APPENDIX B CODELISTS.doc”
    * Dokumentet med forretningskodelister er kommet i en FS2 version ved navnet ”FESS 3.41 - APPENDIX B LIST OF CODES.doc”
    * Både DDNEA’en og FESS’en er nu tilgængelig i den version som er gældende for FS2. For DDNEA’en er dette v1.51 (Phase 3) og for FESS’en er det v.3.41
* Dokumentet ”Oversigt beskeder og scenarier for” er opdateret fra v2.5 til v3.0 og indeholder nu information om de nye FS2 beskeder, scenarier og services. 
* Dokument ”Produktionsinformation - certifikater og WSDL filer” er opdateret fra v1.2 til v1.3. Mindre rettelser er foretaget i dokumentet, uden selve indholdet er ændret.
* Zip filen med alle dokumenterne er gået fra v2.6 til v2.7 for at reflektere ændringerne i de andre dokumenter. Den indeholder dokumenter i både deres FS0/FS1 version og FS2 version.

### v2.51 til v2.60, 14/06/2011

* Alle 14 B2B services er nu i produktion. Et link til en WSDL pakke med produktions WSDL’erne kan nu findes på siden. Navnet på filen er ”emcs-b2b-produktion-wsdl v2.0.zip”.
* Zip filen med alle dokumenterne er gået fra v2.5 til v2.6 for at reflektere ændringerne i de andre dokumenter.

### v2.50 til v2.51, 25/05/2011

* Alle de 14 webservices i EMCS’ B2B løsning er nu tilgængelige til tests. WSDL-filerne kan findes i zip filen ”emcs-b2b-test-wsdl v2.0.zip”.
* Dokumentet ”Oversigt over beskedstruktur” er opdateret fra v2.6 til v2.7.
* Dokument ”Produktionsinformation - certifikater og WSDL filer” er opdateret fra v1.1 til v1.2. Det indeholder nu et trin for trin eksempel på hvordan man opretter en systembruger i TastSelv Erhverv.
* Zip filen med alle dokumenterne er gået fra v2.4 til v2.5 for at reflektere ændringerne i de andre dokumenter.

### v2.00 til v2.50, 10/05/2011

* Dokumentet ”Oversigt over beskedstruktur” er opdateret fra v2.5 til v2.6. Beskrivelsen af enkelte felter er blevet opdateret.
* Implementeringsvejledningen indeholder nu en liste over de fejl som kan blive returneret i HovedOplysningSvar delen. Excel-arket hedder ”emcs-b2b-fejlkoder v1.0.xls.
* Implementeringsvejledningen indeholder nu et eksempel på en valid SOAP request. Den kan findes i zip filen ”emcs-b2b-valid-SOAP-request v1.0.zip”.
* Implementeringsvejledningen indeholder nu en pakke med syv WSDL-filer. WSDL-filerne er til syv services som kan anvendes til at teste om ens system kan overholder de sikkerhedspolitiker som findes på alle webservices i løsningen. De kan findes i zip filen ”emcs-b2b-policy-test-services v1.0.zip”.
* Den tilgængelig Java klient er blevet lavet helt om. Den indeholder nu et eksempel på hvordan man kalder testservicen LedsageDokumentOpret og testservicen LedsageDokumentSamlingHent. Klienten findes i filen ”EMCS WebService Client v2.0.zip”.
* Der er rette i quick start guiden som findes inde i den tilgængelig .NET klient. Klient findes i filen ”emcs-b2b-dot-net-example v1.1.zip”.
* Dokument ”Produktionsinformation - certifikater og WSDL filer” er opdateret fra v1.0 til v1.1.
* Zip filen med alle dokumenterne er gået fra v2.3 til v2.4 for at reflektere ændringerne i de andre dokumenter.

### v1.07 til v2.00, 21/02/11

* B2B servicerne er nu i produktion. Et link til en WSDL pakke men produktions WSDL’erne kan nu findes på siden.
* Dokument ”Produktionsinformation - certifikater og WSDL filer” er tilføjet til siden. Denne indeholder vigtig information om de certifikater som skal anvendes i produktion, hvordan man opsætter disse i TastSelv Erhverv samt hvordan man skal anvende WSDL-pakken.
* En sample klient i .NET WSE 3.0 er nu også tilgængelig. Denne er kun et eksempel på hvordan det kan gøres og det er ikke en klient som SKAT ydere support på.
* Link til samt afsnittet om ”hule igennem” servicen er nu fjernet da de andre test services nu er tilgængelige i en samlet pakke.
* Zip filen med alle dokumenterne er gået fra v2.2 til v2.3 for at reflektere ændringerne i de andre dokumenter.

### v1.06 til v1.07, 02/02/11

* Den første test service er nu tilgængelig. WSDL filen kan findes på siden.
* Dokumentet ”Oversigt beskeder og scenarier for EMCS” er opdateret fra v2.5 til v2.6. Se ændringerne inde i dokuments versionsstyrings tabel.
* Dokumentet ” Oversigt over beskedstruktur” er opdateret fra v2.0 til v2.5. Beskrivelsen af de enkelte felter er blevet opdateret.
* Zip filen med alle dokumenterne er gået fra v2.1 til v2.2 for at reflektere ændringerne i de andre dokumenter. Zip filen indeholder ikke længere test applikationen. Test applikationen kan dog stadig hentes individuelt.

### v1.05 til v1.06, 24/11/10

* Den tilgængelige version af DDNEA’en er opdateret fra version 3.00 til 3.02
* Dokumentet ”Funktional Excise System Specifications” (FESS) i version 3.32 er nu også tilgængeligt på implementeringsvejledningen.

### v1.00 til v1.05, 29/10/10

* Implementeringsvejledningen har nu en ændringslog som er dette dokument.
* Link til WSDL fil af test B2B webservice er nu aktivt.
* Dokumentet ”Oversigt beskeder og scenarier for EMCS” er opdateret fra v2.0 til v2.5. Se ændringerne inde i dokuments versionsstyrings tabel.
* Klientapplikationen er opdateret så den er sat op til test B2B webservicen.
* Dokumentet ”Anvendelse af klientapplikationen” er opdateret fra v1.0 til v1.1. Se ændringerne inde i dokuments versionsstyrings tabel.
* Zip filen med alle dokumenterne er gået fra v2.0 til v2.1 for at reflektere ændringerne i de andre dokumenter.
