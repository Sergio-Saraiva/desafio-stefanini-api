using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioStefanini.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T item);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string itemId);
        Task<T> Update(T item);
        void Delete(T item);
    }
}
