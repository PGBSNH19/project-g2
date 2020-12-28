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
        public async Task<string> GetKeyVaultSecret(string secretName)
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVault = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = await keyVault.GetSecretAsync("https://knetkeys.vault.azure.net/", "knet-data-connectionstring").ConfigureAwait(false);

            return secret.Value;
        }


        //public async System.Threading.Tasks.Task<ActionResult> Privacy()
        //{
        //    // Instantiate a new KeyVaultClient object, with an access token to Key Vault
        //    var azureServiceTokenProvider1 = new AzureServiceTokenProvider();
        //    var azureServiceTokenProvider2 = new AzureServiceTokenProvider("RunAs=App;AppId=<Application ID>");
        //    // var azureServiceTokenProvider2 = new AzureServiceTokenProvider();
        //    // string accessToken = await azureServiceTokenProvider2.GetAccessTokenAsync("https://management.azure.com/").ConfigureAwait(false);
        //    // var azureServiceTokenProvider1 = new AzureServiceTokenProvider("RunAs=App;AppId=<Application ID>;TenantId=<Tenant Name>.onmicrosoft.com;AppKey=<Application Secret>");
        //    try
        //    {
        //        var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider1.KeyVaultTokenCallback));
        //        var secret = await kv.GetSecretAsync("https://blogkv123.vault.azure.net", "SQLPassword").ConfigureAwait(false);
        //        ViewBag.Secret = $"Secret: {secret.Value}";
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = $"Something went wrong: {ex.Message}";
        //        Debug.WriteLine(ex.Message);
        //    }
        //    ViewBag.Principal = azureServiceTokenProvider1.PrincipalUsed != null ? $"Principal Used: {azureServiceTokenProvider1.PrincipalUsed}" : string.Empty;

        //    try
        //    {
        //        string accessToken = await azureServiceTokenProvider2.GetAccessTokenAsync("https://vault.azure.net").ConfigureAwait(false);
        //        ViewBag.AccessToken = $"Access Token: {accessToken}";
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.Message);
        //    }
        //    // Debug.WriteLine(ToString());
        //    return View();
        //}

    }
}
