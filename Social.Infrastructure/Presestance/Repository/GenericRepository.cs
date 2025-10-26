using Microsoft.EntityFrameworkCore;
using Social.Domain.Interface;
using Social.Infrastructure.Presestance.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Infrastructure.Presestance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private ApplicationDBContext _dbContext;
        public GenericRepository(ApplicationDBContext applicationDB)
        {
            _dbContext = applicationDB;
        }
        public async Task<List<T>> GetAll()
        {
           return await _dbContext.Set<T>().ToListAsync();
        }


        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Create(T t)
        {
            await _dbContext.Set<T>().AddAsync(t);
            await _dbContext.SaveChangesAsync();
            return t;
        }

        public async Task<T> Update(T t)
        {
             _dbContext.Set<T>().Update(t);
            await _dbContext.SaveChangesAsync();
            return t;
        }
        public async Task Delete(int id)
        {
           var t = await GetById(id);
            if(t != null)
            {
                _dbContext.Set<T>().Remove(t);
               await _dbContext.SaveChangesAsync();
            }
        }

    }
}
