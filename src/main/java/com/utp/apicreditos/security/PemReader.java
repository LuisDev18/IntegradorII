package com.utp.apicreditos.security;

import org.springframework.stereotype.Component;

import java.security.KeyFactory;
import java.security.NoSuchAlgorithmException;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.security.spec.InvalidKeySpecException;
import java.security.spec.PKCS8EncodedKeySpec;
import java.security.spec.X509EncodedKeySpec;
import java.util.Base64;

@Component
public class PemReader {
    private static final String PRIVATE_KEY = "JWT_RS512_PRIVATE_KEY";
    private static final String PUBLIC_KEY = "JWT_RS512_PUBLIC_KEY";

    public PrivateKey getPrivateKey() {
    	String privatePemKey ="MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCLyC8bsFQxn/qqQHZq2irZ9V5mwrj9GZXufFViUZFZE/JjBcv7WD8HwzcILPYFN+FyTTTH8WEWIhHFzLeTBbwO4Q5EmhxzvUK9rWFsYBerpkRryqtm4uRVO9aUidAXM/qiX4B6B1rW/sdHM3bveeWj5AiHHYS2U4gIJdmbDpBQ5enQKxjoXMgbmjUURR5/NSmL0V4hGXLMrW7lN92zV5PiZPt4OIKPR4nGn/P8Oc3u8fLBJVtdYkgGqPUZV+kuepiYqBsT5j3PKLXTA8Jpje9vL6KH+eha2jTVrTRIpBg4KiEv1w63aEwHGT355RCY8lV7W5ItVDpuerYelfX1BOEpAgMBAAECggEAEGb94iOjiYwye4pjat/tYdSZTnkggHChZ5H26fnU0q1UxrpeKID/Km/FlCPEfbHENmepXyHrqM94IuwGCY5FdkCB7lpgJtOpUn0XHsK63FU/F5/5U3Ih5X+HSzhNrv9WNHn85zTYO7y7URdQqEK3R+9A8evskAGGx5/7ZCbGF/vqNmb5wsrCMGQ5ozmOe1SF8Zc+p5yy1BPNdQ1Izw+jkMyM0s8PG+NW0VVUG29CSqUiDAS4dPEIVUnHkopUb31foV8Dv+VSgyT7BlyiASK7AO+TXQvS/3KLRcxTHOMts7UDqzoL+3woW6WHQR5I/X8FAQF1xP9HUxUHe4ER4T3+dQKBgQDB7nzSs/Y0BZ6eWKaCaL5O4YpKAxQpz8mizA40EpIueupYDZidAGC0VG4CMMMFCw6ozM6w2+OUF9r0dkWIoCgs/Gfq+xrWxtweNZ45Vi45KaOxVHsvXbQxRKU+oguMv65K3m8gsa1oYcRflcFqmelPDceL5DUk8jzJKWqWW83kJQKBgQC4hQXtQ7RiMowpWwRb08lTndimr0xeAklebs6a/o5VAM/tw35E8wczTGQDVEtPafHc78K/Y6S57kjzjViARQaxQl2pQ1w+3LUlpa4o3sDAuiew5kqy69Y88fk1DP29d0+5pfG9Jzjq/heDIhFaQS4TXkZcVsBqjSp1MQEmeyJXtQKBgQCWZabGHSyd0ZHeyW9wiVy1ffIqTdLwTiXYrBmDxrc5dreQzBKEB8v3bdbWugw0OAwJWrQcspr+ubVjiumH+HTP1nuc31pEIHqKrxhi7PPx/tnk51iVNj1NTCg+t5rvb6PyiihymXibD98kJdaXHn+ygEQ1uCiC253Kf+UacF3vRQKBgFKM8MHdcG4ePyahWanbbk7CZ5LrCjdkvn5JBJXDHNpaqqussmkWcTo6CuSSab71nwdBHNeTNLcaK/kKW3XHa98R2eVIBZT6GPDm1qviPEn8/pTd8r1pVUee2ecqELsbDcf4vdXqHkTDuLEqJKlET+DKZKAbD6qbzUrwyZr1q7+hAoGAMEdeS26w8jHCUJCLkIYVqOWEH1SvtUd5q0EERbfKWA3NXYyncFky6mQytGlj3OsWckRS3P8lqdkVx4QGnOFe1253rmp04V5Ja35J0tDHTN34lDKXpRkmJNII79xkdOkZh/ABZejJCE6YR3MpR99p77k5QLcvK5qPgpnkaoL/u8s=";
        /*String privatePemKey =
                System.getenv(PRIVATE_KEY)
                        .replace("-----BEGIN PRIVATE KEY-----", "")
                        .replace("-----END PRIVATE KEY-----", "")
                        .replaceAll("\\s", "");
         */
        byte[] binaryEncoded = Base64.getDecoder().decode(privatePemKey);

        try {
            KeyFactory keyFactory = KeyFactory.getInstance("RSA");
            PKCS8EncodedKeySpec spec = new PKCS8EncodedKeySpec(binaryEncoded);
            return keyFactory.generatePrivate(spec);

        } catch (NoSuchAlgorithmException | InvalidKeySpecException e) {
            throw new RuntimeException(e);
        }
    }

    public PublicKey getPublicKey() {
    	String publicPemKey ="MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAi8gvG7BUMZ/6qkB2atoq2fVeZsK4/RmV7nxVYlGRWRPyYwXL+1g/B8M3CCz2BTfhck00x/FhFiIRxcy3kwW8DuEORJocc71Cva1hbGAXq6ZEa8qrZuLkVTvWlInQFzP6ol+Aegda1v7HRzN273nlo+QIhx2EtlOICCXZmw6QUOXp0CsY6FzIG5o1FEUefzUpi9FeIRlyzK1u5Tfds1eT4mT7eDiCj0eJxp/z/DnN7vHywSVbXWJIBqj1GVfpLnqYmKgbE+Y9zyi10wPCaY3vby+ih/noWto01a00SKQYOCohL9cOt2hMBxk9+eUQmPJVe1uSLVQ6bnq2HpX19QThKQIDAQAB";
        /*String publicPemKey =
                System.getenv(PUBLIC_KEY)
                        .replace("-----BEGIN PUBLIC KEY-----", "")
                        .replace("-----END PUBLIC KEY-----", "")
                        .replaceAll("\\s", "");
         */
        byte[] binaryEncoded = Base64.getDecoder().decode(publicPemKey);

        try {
            KeyFactory keyFactory = KeyFactory.getInstance("RSA");
            X509EncodedKeySpec spec = new X509EncodedKeySpec(binaryEncoded);
            return keyFactory.generatePublic(spec);

        } catch (NoSuchAlgorithmException | InvalidKeySpecException e) {
            throw new RuntimeException(e);
        }
    }
}
