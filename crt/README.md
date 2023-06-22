# Certificates

## Transport Layer Security (TLS)

The following certificates are for **Transport Layer Security** only.

* [TEST System](/crt/emcstest-skat-dk-2022-12-01.pem) with the following details:

```
Owner: CN=*.skat.dk, O=Skatteforvaltningen, L=Herning, ST=Herning, C=DK
Issuer: CN=GlobalSign RSA OV SSL CA 2018, O=GlobalSign nv-sa, C=BE
Serial number: 520918b4e8e48842ca30f22b
Valid from: Thu Dec 01 21:21:02 CET 2022 until: Tue Jan 02 21:21:01 CET 2024
Certificate fingerprints:
	 MD5:  1C:0C:D8:FC:8C:AF:54:D4:9B:90:BE:6E:00:96:10:7C
	 SHA1: 12:E6:4C:02:A5:AB:FB:BD:6D:A8:EC:2F:D4:8D:BF:E7:02:DC:0A:40
	 SHA256: 22:52:90:32:C0:E7:B0:AC:FF:70:AD:19:A4:99:04:7B:59:5B:12:BC:95:D8:E3:69:1E:CC:52:66:A5:15:30:D2
```

* [PRODUCTION System](/crt/b2b-skat-dk-2022-12-01.pem) with the following details:

```
Owner: CN=b2b.skat.dk, O=Skatteforvaltningen, L=Herning, ST=Herning, C=DK
Issuer: CN=GlobalSign RSA OV SSL CA 2018, O=GlobalSign nv-sa, C=BE
Serial number: 3fd7c166c5e0a50ddc393dc0
Valid from: Thu Dec 01 21:16:05 CET 2022 until: Tue Jan 02 21:16:04 CET 2024
Certificate fingerprints:
	 MD5:  2B:7F:56:94:AD:E0:91:E2:60:08:0E:BC:E0:99:37:08
	 SHA1: 4F:1B:C0:29:0C:C9:06:4F:AB:6A:D9:F8:7A:02:D8:4A:EA:5C:AE:14
	 SHA256: 5D:2B:C6:41:05:2F:EB:4F:98:A3:E6:53:FF:18:F5:67:48:E6:71:9D:47:8F:70:76:D7:9E:C6:33:B4:76:E5:01
```

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
    
## WS-Security

The following certificates are for **Web Service Security** to ensure **non-repudiation** (signing) when exchanging 
messages:

* [TEST System](/crt/emcs-b2b-server-test-2023-04-11.pem) (**Note**: Expires on April 10, 2026)

* [PRODUCTION System](/crt/emcs-b2b-server-prod-2020-08-26.pem) (**Note**: Expires on September 16, 2023).

**IMPORTANT**: PRODUCTION will switch to the following certificate on 23. June 2023 at 0700 hours CET:

* [PRODUCTION System](/crt/emcs-b2b-server-prod-2023-04-27.pem) (**Note**: Expires on April 27, 2026)

**IMPORTANT**: Please revisit this page to check updates to the schedule.

These certificates **CANNOT** be used for **Transport Layer Security**
