using System.Threading.Tasks;
using IdGenerator.Api.Attributes;
using IdGenerator.Api.InputModel;
using IdGenerator.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdGenerator.Api.Controllers
{
    [Route("api/[controller]")]
    public class FactoryController : Controller
    {
        readonly IFactoryService _factoryService;

        public FactoryController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _factoryService.GetAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _factoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody]Factory factory)
        {
            if (await IsFactoryExist(factory.Id))
                return StatusCode(409, "Provided factory exist");

            await _factoryService.CreateAsync(factory.Id, factory.Name);

            return Created($"Factory/{factory.Id}", null);
        }

        async Task<bool> IsFactoryExist(string factoryId)
         => await _factoryService.GetAsync(factoryId) != null;
    }
}
