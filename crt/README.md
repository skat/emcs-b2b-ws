# Certificates

## WS-Security

The following certificates are for **Web Service Security** to ensure **non-repudiation** (signing) when exchanging 
messages:

**NOTE** **AFTER** May 27th. 2025 at 13:40 CET the certificates in use:

* [TEST System](/crt/emcs-b2b-server-test-2024-11-13.pem) (**Note**: Expires on November 13, 2027)

* [PROD System](/crt/emcs-b2b-server-prod-2025-02-24.pem) (**Note**: Expires on February 24, 2028)

Until May 26th. 2025 at 17:00 CET these certificates are in use: 

* [TEST System](/crt/emcs-b2b-server-test-2023-04-11.pem) (**Note**: Expires on April 10, 2026)

* [PRODUCTION System](/crt/emcs-b2b-server-prod-2023-04-27.pem) (**Note**: Expires on April 27, 2026)

**IMPORTANT**: Please revisit this page to check updates to the schedule.

These certificates **CANNOT** be used for **Transport Layer Security**. Instead, see below.

## Transport Layer Security (TLS)

Issuer certificates for both **TEST** and **PRODUCTION**:

* [GlobalSign RSA OV SSL CA 2018](/crt/GlobalSign-RSA-OV-SSL-CA-2018.pem)
* [GlobalSign](/crt/GlobalSign.pem)

**NOTE** **AFTER** May 27th. 2025 at 13:40 CET the new TLS cert. in use for **PROD** will be the certificate in file:

* [emcs.skat.dk.pem](/crt/tls/emcs.skat.dk.pem)

### Do I have to install or update these certificates in my system?

It depends on your system and/or your strategy:

|   | Trust by installing                  | Update when                     |
|---|--------------------------------------|---------------------------------|
| A | Server TLS certificate only/directly | Certificate is renewed          |
| B | Issuer certificates                  | Issuer certificates are renewed |
| C | Full chain                           | Do both (A) and (B)             |

Option **B** will void updates to the client system everytime the TLS server certificate is renewed.

If option **A** see contents of [tls](/tls) folder.
