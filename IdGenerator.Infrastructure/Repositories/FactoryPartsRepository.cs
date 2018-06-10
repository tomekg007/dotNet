using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdGenerator.Core;
using IdGenerator.Core.Repository;
using IdGenerator.Infrastructure.Config;
using IdGenerator.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace IdGenerator.Infrastructure.Repositories
{
    public class FactoryPartsRepository : Disposable, IFactoryPartsRepository
    {
        readonly ApplicationContext _context;
        public FactoryPartsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(FactoryParts factoryParts)
        {
            await _context.AddAsync(factoryParts);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FactoryParts>> GetAllAsync()
         => await _context.UniquePartsIdS.ToListAsync();

        public async Task<FactoryParts> GetAsync(string categoryId, string factoryId, int number)
        => await _context.UniquePartsIdS.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId == categoryId && x.FactoryId == factoryId && x.CategoryFactoryId == number);

        public int GetLastNumber(string categoryId, string factoryId)
        {
           var result = _context.UniquePartsIdS.AsNoTracking().Where(x => x.CategoryId == categoryId && x.FactoryId == factoryId);

           return result.Any() ? result.Max(x => x.CategoryFactoryId) : 0;           
        }

        protected override void DisposeCore()
            => _context?.Dispose();
    }
}
