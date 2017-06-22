# Asp.net-core-client-side-encryption
A asp.net core application (authentication-authorization) implemented with client-side encryption using the SJCL

The objectives of this project are to provide the user with:
1. Access to the platform: Access to the portal must be via username and password to identify the connected user and display the only data and pages that he has permission to see.

2. Confidentiality of the data entered by the users: The data entered by the user are confidential, only those who have a certain password must be able to see them, so it is imperative that at no time can the data be read clearly by administrators and system administrators.

To do this:
1. You have used 'Identity' by implementing the permissions through the Microsoft.AspNetCore.Authorization package, so that through Identity, centralized user management and a lightweight and reliable authentication system are guaranteed, while the Authorization package sets permissions for Every resource.

2. Client side has implemented a cryptography and decryption system using the Stanford Javascript Crypto Library.
