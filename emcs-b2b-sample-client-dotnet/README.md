# EMCS B2B Sample Client - .NET Core Sample

> **IMPORTANT NOTICE**: UFST does not provide any kind of support for the code in this repository.
> This client is just one example of how a B2B web service can be accessed. The client must not be 
> perceived as a piece of production code but more as an example one can take inspiration from and can use
> to quickly get started to test whether your company can implement a successful call to one of the B2B web 
> service using the company's digital signature. UFST can not be held responsible if a company uses this client
> or parts of it in their own systems. 

> **VIGTIG MEDDELELSE**: UFST yder ikke support på kildekoden i nærværende kodebibliotek.
> Denne klient er kun et eksempel på hvordan B2B webservicene kan tilgås. Klienten skal således ikke 
> opfattes som et stykke produktionskode men mere som en eksempel man kan lade sig inspirere af og kan bruge 
> til hurtigt at komme i gang og få afprøvet om ens virksomhed kan gennemføre et succesfuldt kald til en af 
> B2B webservicene ved at bruge virksomhedens digitale signatur. UFST kan ikke stå til ansvar hvis en virksomhed
> anvender klienten eller dele af denne i deres egne systemer. 

## Configure

1. Download the client certificate for test from this location:

https://github.com/skat/emcs-b2b-ws-sample-client-java/blob/master/p12/DinoVinoImport_System_Integrationstest_S1.p12

and place the file in the root of this project (keep the exact filename)

2. Download the server certificate for the test environment as explained in the Systems Integrator (SI) package (see file `CERTIFICATES.md`) and save the contents in this file in the root of this project:

```
server.pem
```

3. From the Systems Integrator (SI) package copy the file 

```
emcs-b2b-sample-client-dotnet/appsettings.json
```

to the root of this project (replace the existing `appsettings.json`) file.

## Build and run

Build:

```
$ dotnet build
```

Run application, e.g.:

```
$ dotnet run OIOLedsageDokumentOpret
```

or

```
$ dotnet run OIOLedsageDokumentSamlingHent
```
