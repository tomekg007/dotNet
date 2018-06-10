using System.Collections.Generic;
using System.Threading.Tasks;
using IdGenerator.Core;
using IdGenerator.Infrastructure.DTO;

namespace IdGenerator.Infrastructure.Services
{
    public interface ICategoryService
    {
        Task CreateAsync(string id, string name);
        Task<Category> GetAsync(string id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
    }
}
