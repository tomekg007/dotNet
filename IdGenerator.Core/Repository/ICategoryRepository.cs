using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdGenerator.Core.Repository
{
    public interface ICategoryRepository
    {
        Task CreateAsync(Category category);
        Task<Category> GetAsync(string id);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
