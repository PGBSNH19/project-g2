using KNet.Web.Areas.Identity.Data;
using KNet.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KNet.Web.Controllers
{
    public class UserController : Controller
    {
        private HttpClient _client;
        IHttpContextAccessor _accessor;
        public UserController(IHttpClientFactory factory, IHttpContextAccessor accessor)
        {
            _client = factory.CreateClient("knetAPIClient");
            _accessor = accessor;
        }

        public async Task<UserModel> GetUserByEmail()
        {
            var userModel = new UserModel();

            try
            {
                HttpContext currentContext = _accessor.HttpContext;
                string userName = currentContext.User.Identity.Name;


                //if (User.Identity.IsAuthenticated)
                //{
                //    {
                //        try
                //        {
                //            userModel = await _client.GetFromJsonAsync<UserModel>
                //                (@"User/email?email=" + User.Identity.Name);
                //        }
                //        catch (Exception e)
                //        {
                //            Console.WriteLine($"GetAdvertsList: BadRequest. {e}");
                //        }
                //    }
                //}

            }
            catch (Exception)
            {
            }


            return userModel;
        }

        async Task GetUser()
        {
            var authToken = _accessor.HttpContext.Request.Cookies[".AspNetCore.Cookies"];
            if (authToken != null)
            {
                Guid userId = Guid.Parse(_accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
        }


    }
}
