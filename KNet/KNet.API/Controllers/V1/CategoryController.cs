using KNet.API.Models;
using KNet.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KNet.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var category = await _categoryRepository.GetCategoryById(id);

            if (category is null)
                return BadRequest();

            return Ok(category);
        }

        [HttpGet("name")]
        public async Task<IActionResult> Get(string name)
        {
            if (name == string.Empty)
                return BadRequest();

            var category = await _categoryRepository.GetCategoryByName(name);

            if (category is null)
                return BadRequest();

            return Ok(category);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var categories = await _categoryRepository.GetAllCategories();

            if (categories is null)
                return BadRequest();

            return Ok(categories);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var category = await _categoryRepository.GetCategoryById(id);
            await _categoryRepository.Delete(category);

            return Ok();
        }

        [HttpDelete("name")]
        public async Task<IActionResult> Delete(string name)
        {
            if (name == string.Empty)
                return BadRequest();

            var category = await _categoryRepository.GetCategoryByName(name);
            await _categoryRepository.Delete(category);

            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(UpdateCategoryModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = await _categoryRepository.GetCategoryById(request.Id);

            category.Name = request.Name;

            await _categoryRepository.Update(category);
            return Ok();
        }
    }
}
