using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdGenerator.Core.Repository
{
    public interface IFactoryRepository
    {
        Task CreateAsync(Factory factory);
        Task<Factory> GetAsync(string id);
        Task<IEnumerable<Factory>> GetAllAsync();
    }
}
