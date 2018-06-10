using System.Threading.Tasks;
using IdGenerator.Api.Attributes;
using IdGenerator.Api.InputModel;
using IdGenerator.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdGenerator.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _categoryService.GetAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody]Category categoryInput)
        {
            
            if (await IsCategoryExist(categoryInput.Id))            
                return StatusCode(409, "Provided category exist");   
            

            await _categoryService.CreateAsync(categoryInput.Id, categoryInput.Name);
            return Created($"Category/{categoryInput.Id}", null);
        }

        async Task<bool> IsCategoryExist(string categoryId)
         =>  await _categoryService.GetAsync(categoryId) != null;        
    }
}
