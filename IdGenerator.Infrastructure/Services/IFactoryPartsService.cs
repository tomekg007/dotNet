using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdGenerator.Infrastructure.DTO;

namespace IdGenerator.Infrastructure.Services
{
    public interface IFactoryPartsService
    {
        Task CreateAsync(string categoryId, string factoryId, DateTime createdAt);
        Task<UniquePartDto> GetAsync(string categoryId, string factoryId, int number);
        Task<IEnumerable<UniquePartDto>> GetAllAsync();
        int GeneratedNumber { get; }
    }
}
