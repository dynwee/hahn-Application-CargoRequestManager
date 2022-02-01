using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CargoRequestManagerDbContext _cargoRequestManagerDbContext;

        public GenericRepository(CargoRequestManagerDbContext cargoRequestManagerDbContext)
        {
            _cargoRequestManagerDbContext = cargoRequestManagerDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _cargoRequestManagerDbContext.AddAsync(entity);
            //await _cargoRequestManagerDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _cargoRequestManagerDbContext.Set<T>().Remove(entity);
            //await _cargoRequestManagerDbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await  _cargoRequestManagerDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _cargoRequestManagerDbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _cargoRequestManagerDbContext.Entry(entity).State = EntityState.Modified;
           // await _cargoRequestManagerDbContext.SaveChangesAsync();
        }
    }
}
