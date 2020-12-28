using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Services
{
    public class AzureKeyVaultService
    {
        public async Task<string> GetKeyVaultSecret()
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVault = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = await keyVault.GetSecretAsync("https://knetkeys.vault.azure.net/", "ConnectionString-Knet-Data").ConfigureAwait(false);

            return secret.Value;
        }
    }
}
