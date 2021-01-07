using KNet.Web.Areas.Identity.Data;
using KNet.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KNet.Web.Controllers
{
    public class AdvertController : Controller
    {
        HttpClient Http;
        public AdvertController(IHttpClientFactory factory)
        {
            this.Http = factory.CreateClient("knetAPIClient");
        }

        public async Task<List<AdvertModel>> GetAdvertsByUserId(Guid userId)
        {
            List<AdvertModel> advertsList = new List<AdvertModel>();

            try
            {
                advertsList = await Http.GetFromJsonAsync<List<AdvertModel>>
                (@"Advert/userId?id=" + userId);
            }
            catch (Exception e)
            {
                Console.WriteLine($"GetAdvertsList: BadRequest. {e}");
            }

            return advertsList;
        }

        public async Task<List<AdvertModel>> GetAdverts()
        {
            List<AdvertModel> advertsList = new List<AdvertModel>();

            try
            {
                advertsList = await Http.GetFromJsonAsync<List<AdvertModel>>
                (@"Advert/list");
            }
            catch (Exception e)
            {
                Console.WriteLine($"GetAdvertsList: BadRequest. {e}");
            }

            return advertsList;
        }

        //Untested
        public async Task<IActionResult> PostAdvert(AdvertModel advert)
        {
            if (advert.UserId == Guid.Empty) return BadRequest();
            
            var responseMessage = await Http.PostAsJsonAsync<AdvertModel>(@"Advert", advert);

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return BadRequest();
            }

            return Ok(advert);
        }

        //Untested
        public async Task UpdateAdvert(AdvertModel advert)
        {
            await Http.PutAsJsonAsync<AdvertModel>(@"Advert", advert);
        }

        public async Task DeleteAdvert(Guid advertId)
        {
            await Http.DeleteAsync(@"Advert?id=" + advertId);
        }
    }
}
