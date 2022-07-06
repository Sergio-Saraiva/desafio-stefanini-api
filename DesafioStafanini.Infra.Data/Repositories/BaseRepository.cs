using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioStefanini.Domain.Interfaces;
using DesafioStefanini.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioStefanini.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T item)
        {
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public async Task<T> GetByIdAsync(string itemId)
        {
            return await _context.Set<T>().FindAsync(itemId);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _context.Set<T>();
        }

        public async Task<T> Update(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
