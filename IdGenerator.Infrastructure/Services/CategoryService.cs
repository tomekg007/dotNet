using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IdGenerator.Core;
using IdGenerator.Core.Repository;
using IdGenerator.Infrastructure.DTO;

namespace IdGenerator.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        readonly IMapper _mapper;
        readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper,ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(string id, string name)
        {
            await _categoryRepository.CreateAsync(new Category(id, name));
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var results = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(results);
        }

        public async Task<Category> GetAsync(string id)
            => await _categoryRepository.GetAsync(id);
    }
}
