using System.Collections.Generic;
using System.Threading.Tasks;
using IdGenerator.Core;
using IdGenerator.Core.Repository;
using IdGenerator.Infrastructure.Config;
using IdGenerator.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace IdGenerator.Infrastructure.Repositories
{
    public class FactoryRepository : Disposable, IFactoryRepository
    {
        readonly ApplicationContext _context;
        public FactoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Factory factory)
        {
            await _context.AddAsync(factory);
            await _context.SaveChangesAsync();
        }

        public async Task<Factory> GetAsync(string id)
          => await _context.Factories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Factory>> GetAllAsync()
            => await _context.Factories.ToListAsync();

        protected override void DisposeCore()
            => _context?.Dispose();

    }
}
