using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioStefanini.Domain.Enitities;
using DesafioStefanini.Domain.Interfaces;
using DesafioStefanini.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Infra.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            
        }

        public async Task<IQueryable<Person>> GetAllAsync()
        {
            return _context.Set<Person>().AsNoTracking().Include(p => p.City);
        }

        public async Task<Person> GetByIdAsync(string itemId)
        {
            return await _context.Set<Person>().AsNoTracking().Include(p => p.City).FirstAsync(x => x.Id == itemId);
        }

        public void Delete(Person item)
        {
            _context.Set<Person>().Remove(item);
            _context.Set<City>().Remove(item.City);

            _context.SaveChanges();
        }
    }
}
