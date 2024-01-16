using AutoMapper;
using IWantApp.Application.Contracts;
using IWantApp.Application.DTO;
using IWantApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IWantApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryResponse model)
        {

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (model == null)
                    return NotFound();


                await _categoryService.Add(model, userId);

                return new CreatedAtRouteResult("GetCategory", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CategoryUpdateDTO model, Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _categoryService.Update(model, id, userId);

            return new CreatedAtRouteResult("GetCategory", new { id = model.Id }, model);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();

            if (categories == null)
                return NotFound("Categories not Found");

            return Ok(categories);
        }



        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(Guid id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
                return NotFound("Category not Found");

            return Ok(category);
        }
    }
}
