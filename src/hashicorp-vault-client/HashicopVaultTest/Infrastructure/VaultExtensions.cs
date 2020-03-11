using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.AppRole;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace HashicopVaultTest.Infrastructure
{
	public static class VaultExtensions
	{
        private const string VaultServerUri = "http://127.0.0.1:8200";
        private const string VaultRoleId = "";
        private const string VaultSecretId = "";
        private const string VaultAccessToken = "";

        public static IConfigurationBuilder AddVault(this IConfigurationBuilder builder)
        {
            IConfigurationRoot buildConfig = builder.Build();

            //IAuthMethodInfo authenticationInfo = new TokenAuthMethodInfo(VaultAccessToken);
            IAuthMethodInfo authenticationInfo = new AppRoleAuthMethodInfo(VaultRoleId, VaultSecretId);

            VaultClientSettings vaultClientSettings = new VaultClientSettings(VaultServerUri, authenticationInfo);
            IVaultClient client = new VaultClient(vaultClientSettings);

            SecretData appSecrets = client.V1.Secrets.KeyValue.V2.ReadSecretAsync("applications/vault-test").GetAwaiter().GetResult().Data;
            IEnumerable<KeyValuePair<string, string>> secretsForConfiguration = appSecrets.Data.Select(x => new KeyValuePair<string, string>($"vault-startup:{x.Key}", x.Value.ToString()));

            return builder.AddInMemoryCollection(secretsForConfiguration);
        }
    }
}
