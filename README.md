# Starting the Hashicorp Vault server

`cd .\src\hashicorp-vault-server`

`docker-compose up`

You can switch from file storage or MSSQL storage by modifying the `storage` configuration in the `docker-compose.yml`:

## File storage:
`"storage": { "file": { "path": "/vault/data" } }`

## MSSQL storage
`"storage": { "mssql": { "server": "10.23.94.7", "username": "", "password": "", "database": "Vault", "table": "vault", "appname": "vault" } }`

You will need to replace `server`, `username` and `password` with ones that you have configured.


# Starting the Hashicorp Vault client

Open in Visual Studio and replace the following in `VaultExtensions.cs`:
- `VaultServerUri` - should be URI and port number
- `VaultAccessToken` - with the root access token (or approle token)

Note: Also make sure that the path in the `ReadSecretAsync` call actually exists in vault.

You can switch to using approles instead of access tokens:
- `VaultRoleId` - should be the value for the role ID, created in Vault
- `VaultSecretId` - should be the value for the role's secret ID, created in Vault
