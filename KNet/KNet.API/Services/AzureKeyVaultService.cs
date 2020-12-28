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
        public string GetKeyVaultSecret(string secretName)
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVault = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = keyVault.GetSecretAsync(secretName).Result;


            //KeyVaultClient kvc = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            //SecretBundle secret = kvc.GetSecretAsync("https://knetkeys.vault.azure.net/secrets/knet-data-connectionstring/6ce69867b40d494fa0139270a1a9b1a6").Result;
            //Console.WriteLine(secret.Value);

            return secret.Value;
        }
    }
}
