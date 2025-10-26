using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetAll();    
        public Task<T> Create(T t);
        public Task<T> GetById(int id);

        public Task<T> Update(T t);
        public Task Delete(int id);
    }
}
