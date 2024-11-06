using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Common
{
    public interface IGenericRepository<T> where T :class
    {
        public interface IGenericRepository<T> where T : class
        {
            Task AddAsync(T entity); 
            Task UpdateAsync(T entity); 
            Task DeleteAsync(T entity); 

            Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
            // Tüm verileri getirirken asenkron çalışacak

            Task<T> GetValueAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
            // Tek bir veri getirirken asenkron çalışacak
        }

    }
}
