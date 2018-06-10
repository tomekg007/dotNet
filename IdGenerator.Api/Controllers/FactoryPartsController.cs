using System;
using System.Linq;
using System.Threading.Tasks;
using IdGenerator.Api.Attributes;
using IdGenerator.Api.InputModel;
using IdGenerator.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdGenerator.Api.Controllers
{
    [Route("api/[controller]")]
    public class FactoryPartsController : Controller
    {
        readonly IFactoryPartsService _factoryPartsService;
        readonly ICategoryService _categoryService;
        readonly IFactoryService _factoryService;
        const string _error = "Invalid";

        public FactoryPartsController(IFactoryPartsService factoryPartsService, ICategoryService categoryService, IFactoryService factoryService)
        {
            _factoryPartsService = factoryPartsService;
            _categoryService = categoryService;
            _factoryService = factoryService;
        }



        [HttpGet("{categoryId}/{factoryId}/{number}")]
        public async Task<IActionResult> Get(string categoryId, string factoryId, int number)
        {

            var result = await _factoryPartsService.GetAsync(categoryId, factoryId, number);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _factoryPartsService.GetAllAsync();
            return Ok(result);
        }


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody]UniqueParts uniquePartsId)
        {
            if (await IsCategoryNotExist(uniquePartsId.CategoryId))
                return StatusCode(409, $"{_error} {nameof(uniquePartsId.CategoryId)}");

            if (await IsFactoryNotExist(uniquePartsId.FactoryId))
                return StatusCode(409, $"{_error} {nameof(uniquePartsId.FactoryId)}");


            await _factoryPartsService.CreateAsync(uniquePartsId.CategoryId, uniquePartsId.FactoryId, DateTime.Now);

            return Created($"FactoryParts/{uniquePartsId.CategoryId}/{uniquePartsId.FactoryId}/{_factoryPartsService.GeneratedNumber}", null);
        }

        async Task<bool> IsCategoryNotExist(string categoryId)
            => await _categoryService.GetAsync(categoryId) == null;

        async Task<bool> IsFactoryNotExist(string factoryId)
            => await _factoryService.GetAsync(factoryId) == null;
    }
}
