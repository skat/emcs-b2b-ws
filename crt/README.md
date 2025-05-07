# Certificates

## Transport Layer Security (TLS)

Issuer certificates for both **TEST** and **PRODUCTION**:

* [GlobalSign RSA OV SSL CA 2018](/crt/GlobalSign-RSA-OV-SSL-CA-2018.pem)
* [GlobalSign](/crt/GlobalSign.pem)

### Do I have to install or update these certificates in my system?

It depends on your system and/or your strategy:

|   | Trust by installing                  | Update when                     |
|---|--------------------------------------|---------------------------------|
| A | Server TLS certificate only/directly | Certificate is renewed          |
| B | Issuer certificates                  | Issuer certificates are renewed |
| C | Full chain                           | Do both (A) and (B)             |

Option **B** will void updates to the client system everytime the TLS server certificate is renewed.

If option **A** see contents of [tls](/tls) folder.
    
## WS-Security

The following certificates are for **Web Service Security** to ensure **non-repudiation** (signing) when exchanging 
messages:

* [TEST System](/crt/emcs-b2b-server-test-2023-04-11.pem) (**Note**: Expires on April 10, 2026)

* [PRODUCTION System](/crt/emcs-b2b-server-prod-2023-04-27.pem) (**Note**: Expires on April 27, 2026)

**IMPORTANT**: Please revisit this page to check updates to the schedule.

These certificates **CANNOT** be used for **Transport Layer Security**
