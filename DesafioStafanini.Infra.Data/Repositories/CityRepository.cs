using DesafioStefanini.Domain.Enitities;
using DesafioStefanini.Domain.Interfaces;
using DesafioStefanini.Infra.Data.Context;

namespace DesafioStefanini.Infra.Data.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
