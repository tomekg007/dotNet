using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdGenerator.Core;
using IdGenerator.Core.Repository;
using IdGenerator.Infrastructure.DTO;

namespace IdGenerator.Infrastructure.Services
{
    public class FactoryPartsService : IFactoryPartsService
    {
        readonly IMapper _mapper;
        readonly ICategoryRepository _categoryRepository;
        readonly IFactoryPartsRepository _factoryPartsRepository;
        public int GeneratedNumber { get; private set; }

        public FactoryPartsService(IMapper mapper, ICategoryRepository categoryRepository, IFactoryRepository factoryRepository, IFactoryPartsRepository factoryPartsRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _factoryPartsRepository = factoryPartsRepository;
        }

        public async Task CreateAsync(string categoryId, string factoryId, DateTime createdAt)
        {
            await _categoryRepository.GetAsync(categoryId);
            var number = _factoryPartsRepository.GetLastNumber(categoryId, factoryId);
            GeneratedNumber = GetNextNumber(number);
            await _factoryPartsRepository.CreateAsync(new FactoryParts(categoryId, factoryId, GeneratedNumber, createdAt));
        }


        public async Task<IEnumerable<UniquePartDto>> GetAllAsync()
        {
            var results = await _factoryPartsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UniquePartDto>>(results).OrderByDescending(o => o.CreatedAt);
        }

        public async Task<UniquePartDto> GetAsync(string categoryId, string factoryId, int number)
        {
            var results = await _factoryPartsRepository.GetAsync(categoryId, factoryId, number);
            return results != null ? _mapper.Map<UniquePartDto>(results) : null;
        }

        static int GetNextNumber(int number)
            => number + 1;
    }
}

