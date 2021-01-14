using KNet.API.Models;
using KNet.API.Repositories;
using Microsoft.AspNetCore.Http;
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

        //If we use {id} instead of id the address will be more shorter and easier to call  .../category/8a161439-f869-4f44-7d29-08d8b8724a74
        [HttpGet("id")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest("Please enter a valid category id.");

                var category = await _categoryRepository.GetEntityById<CategoryModel>(id);

                if (category is null)
                    return NotFound($"A category with id '{id}' could not be found.");

                return Ok(category);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"API Failure: {e.Message}");
            }
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            try
            {
                if (name == string.Empty)
                    return BadRequest("Please enter a valid category name.");

                var category = await _categoryRepository.GetCategoryByName(name);

                if (category is null)
                    return NotFound($"A category with the name '{name}' could not be found.");

                return Ok(category);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"API Failure: {e.Message}");
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllEntities<CategoryModel>();

                return Ok(categories);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"API Failure: {e.Message}");
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCategoryById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest("Please enter a valid category id.");

                var category = await _categoryRepository.GetEntityById<CategoryModel>(id);

                if (category is null)
                    return NotFound($"A category with id '{id}' could not be found.");

                var deletedCategory = await _categoryRepository.Delete(category);

                return Ok(deletedCategory);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to remove category Exception thrown when attempting to remove data to the database: {e.Message}");
            }
        }

        [HttpDelete("name")]
        public async Task<IActionResult> DeleteCategoryByName(string name)
        {
            try
            {
                if (name == string.Empty)
                    return BadRequest("Please enter a valid category name.");

                var category = await _categoryRepository.GetCategoryByName(name);

                if (category is null)
                    return NotFound($"A category with the name '{name}' could not be found.");

                var deletedCategory = await _categoryRepository.Delete(category);

                return Ok(deletedCategory);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to remove category Exception thrown when attempting to remove data to the database: {e.Message}");
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var category = await _categoryRepository.GetEntityById<CategoryModel>(request.Id);

                if (category is null)
                    return NotFound($"A category with id '{request.Id}' could not be found.");

                category.Name = request.Name;

                var updatedCategory = await _categoryRepository.Update(category);
                return Ok(updatedCategory);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to update category Exception thrown when attempting to update data to the database: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(CreateCategoryModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var category = new CategoryModel
                {
                    Name = request.Name
                };

                var createdCategory = await _categoryRepository.Add(category);
                return Ok(createdCategory);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to add category Exception thrown when attempting to add data to the database: {e.Message}");
            }
        }
    }
}