using KNet.API.Models;
using KNet.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertRepository _advertRepository;
        
        public AdvertController(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }
        
        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var advert = await _advertRepository.GetAdvertById(id);

            if (advert is null)
                return BadRequest();

            return Ok(advert);
        }

        [HttpDelete]
        public async Task <IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var advert = await _advertRepository.GetAdvertById(id);
            advert.IsDeleted = true;
            await _advertRepository.Delete(advert);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Advert request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var advert = await _advertRepository.GetAdvertById(request.Id);

            if (advert is null)
                return BadRequest();

            advert.CategoryId = request.CategoryId;
            advert.Heading = request.Heading;
            advert.Content = request.Content;
            advert.Location = request.Location;
            advert.Price = request.Price;
            advert.StartDate = request.StartDate;
            advert.EndDate = request.EndDate;

            await _advertRepository.Update(advert);
            return Ok();
        }
    }
}
