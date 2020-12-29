using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System.Threading.Tasks;

namespace KNet.API.Services
{
    public class AzureKeyVaultService
    {
        public async Task<string> GetKeyVaultSecret()
        {
#if DEBUG
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVault = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = await keyVault.GetSecretAsync("https://knetkeys.vault.azure.net/", "ConnectionString-Knet-Data").ConfigureAwait(false);
#else
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVault = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = await keyVault.GetSecretAsync("https://knetkeys.vault.azure.net/", "knet-data-prod").ConfigureAwait(false);
#endif
            return secret.Value;
        }
    }
}
