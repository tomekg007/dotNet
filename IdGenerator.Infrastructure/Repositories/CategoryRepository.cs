using System.Collections.Generic;
using System.Threading.Tasks;
using IdGenerator.Core;
using IdGenerator.Core.Repository;
using IdGenerator.Infrastructure.Config;
using IdGenerator.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace IdGenerator.Infrastructure.Repositories
{
    public class CategoryRepository : Disposable, ICategoryRepository
    {
        readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetAsync(string id)
            => await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _context.Categories.ToListAsync();

        protected override void DisposeCore() 
            => _context?.Dispose();
    }
}
