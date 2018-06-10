using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdGenerator.Core.Repository
{
    public interface IFactoryPartsRepository
    {
        Task CreateAsync(FactoryParts factoryParts);
        Task<FactoryParts> GetAsync(string categoryId, string factoryId, int number);
        Task<IEnumerable<FactoryParts>> GetAllAsync();
        int GetLastNumber(string categoryId, string factoryId);
    }
}
