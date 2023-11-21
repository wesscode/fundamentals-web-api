# Fundamentos API AspNetCore
- dotnet 8.0
- API
- Convenções
- Analisadores
- JWT
- Autenticação e Autorização
- Boas práticas


## AspNetIdentity
        * dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 8.0.0

**Sobre:**
    - Identity.Core: Biblioteca central do identity
    - Identity.Store:  Biblioteca que realiza a integração do EFCore com Identity.
    - Identity.Option: Algumas Extensões

## JWT (Json Web Token)
*Definido pela RFC: 7519*

**Composição:** 
        - Header: especifica o algoritmo e o tipo. 
        - Payload: informações e **iat** define quando foi emitido.
        - Signature: senha de assinatura do token(segredo).

                * dotnet add package Microsoft.AspNetCore Authentication.JwtBearer               
