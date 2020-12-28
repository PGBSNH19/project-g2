using KNet.API.Models;
using KNet.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var adverts = await _advertRepository.GetAllAdverts();

            if (adverts is null)
                return BadRequest();

            return Ok(adverts);
        }

        [HttpGet("userId")]
        public async Task<IActionResult> GetAdvertsByUserId(Guid id)
        {
            var adverts = await _advertRepository.GetAdvertsByUserId(id);

            if (adverts is null)
                return BadRequest();

            return Ok(adverts);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var advert = await _advertRepository.GetAdvertById(id);
            await _advertRepository.Delete(advert);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateAdvertModel request)
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

        [HttpPost]
        public async Task<IActionResult> Post(CreateAdvertModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var advert = new AdvertModel
            {
                CategoryId = request.CategoryId,
                Heading = request.Heading,
                Content = request.Content,
                Location = request.Location,
                Price = request.Price,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };
            await _advertRepository.Add(advert);
            return Ok(advert);
        }

    }
}
