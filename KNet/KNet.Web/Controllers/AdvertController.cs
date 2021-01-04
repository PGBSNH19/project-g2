using KNet.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KNet.Web.Controllers
{
    public class AdvertController : Controller
    {
        HttpClient Http;
        public AdvertController(HttpClient http)
        {
            Http = http;
        }

        public async Task GetAdvertsByUserId(Guid userId)
        {
            var bla = await Http.GetAsync(
            @"http://g2api-development-run9.westus.azurecontainer.io/api/v1/Advert/userId=34fcceb5-6f4a-4a7e-c100-08d8ab3d64f4");

            var deserialize = bla.Content.ReadAsStreamAsync().Result;
            

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
