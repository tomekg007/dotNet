using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IdGenerator.Core;
using IdGenerator.Core.Repository;
using IdGenerator.Infrastructure.DTO;

namespace IdGenerator.Infrastructure.Services
{
    public class FactoryService : IFactoryService
    {
        readonly IMapper _mapper;
        readonly IFactoryRepository _factoryRepository;

        public FactoryService(IMapper mapper, IFactoryRepository factoryRepository)
        {
            _mapper = mapper;
            _factoryRepository = factoryRepository;
        }
        public async Task CreateAsync(string id, string name)
        {
            await _factoryRepository.CreateAsync(new Factory(id, name));
        }

        public async Task<IEnumerable<FactoryDto>> GetAllAsync()
        {
            var results = await _factoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FactoryDto>>(results);
        }

        public async Task<Factory> GetAsync(string id)
             => await _factoryRepository.GetAsync(id);
    }
}
