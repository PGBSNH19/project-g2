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
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Please enter a valid category id.");

            var category = await _categoryRepository.GetEntityById<CategoryModel>(id);

            if (category is null)
                return NotFound($"A category with id '{id}' could not be found.");

            return Ok(category);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            if (name == string.Empty)
                return BadRequest("Please enter a valid category name.");

            var category = await _categoryRepository.GetCategoryByName(name);

            if (category is null)
                return NotFound($"A category with the name '{name}' could not be found.");

            return Ok(category);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllEntities<CategoryModel>();

            return Ok(categories);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCategoryById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Please enter a valid category id.");

            var category = await _categoryRepository.GetEntityById<CategoryModel>(id);

            if (category is null)
                return NotFound($"A category with id '{id}' could not be found.");

            await _categoryRepository.Delete(category);

            return NoContent();
        }

        [HttpDelete("name")]
        public async Task<IActionResult> DeleteCategoryByName(string name)
        {
            if (name == string.Empty)
                return BadRequest("Please enter a valid category name.");

            var category = await _categoryRepository.GetCategoryByName(name);

            if (category is null)
                return NotFound($"A category with the name '{name}' could not be found.");

            await _categoryRepository.Delete(category);

            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = await _categoryRepository.GetEntityById<CategoryModel>(request.Id);

            if (category is null)
                return NotFound($"A category with id '{request.Id}' could not be found.");

            category.Name = request.Name;

            await _categoryRepository.Update(category);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(CreateCategoryModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = new CategoryModel
            {
                Name = request.Name
            };

            await _categoryRepository.Add(category);
            return Ok();
        }
    }
}
