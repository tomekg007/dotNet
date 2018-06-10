using System.Collections.Generic;
using System.Threading.Tasks;
using IdGenerator.Core;
using IdGenerator.Infrastructure.DTO;

namespace IdGenerator.Infrastructure.Services
{
    public interface IFactoryService
    {
        Task CreateAsync(string id, string name);
        Task<Factory> GetAsync(string id);
        Task<IEnumerable<FactoryDto>> GetAllAsync();
    }
}
