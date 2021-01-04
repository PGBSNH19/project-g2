using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace KNet.Web.Data
{
    public class AdvertService
    {
        private readonly HttpClient httpClient;

        public AdvertService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async void GetAdvertsByUserId()
        {
            var bla = await httpClient.GetAsync("Advert/userId=34fcceb5-6f4a-4a7e-c100-08d8ab3d64f4");
           
        }
    }
}
