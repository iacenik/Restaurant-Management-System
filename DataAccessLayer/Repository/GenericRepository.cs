using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Common;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;
        //Dbset yapısı tanımlanıyor veri çekerken kullanıyor

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet =_context.Set<T>();
            //context  içerisine atacak Tablolarıda dbSet yapısına atıyorum.
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity); 
            await _context.SaveChangesAsync(); 
        }


        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> sorgu = dbSet;

            if (filter != null)
            {
                sorgu = sorgu.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sorgu = sorgu.Include(includeProp);
                }
            }

            return await sorgu.ToListAsync();
        }

        //veritabanından içinde bir filtre ve include ile gönderilicek verileri alıp
        //veri göndermek için bir method yazacağız

        public T GetValue(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetValueAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> sorgu = dbSet;

            if (filter != null)
            {
                sorgu = sorgu.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sorgu = sorgu.Include(includeProp);
                }
            }

            return await sorgu.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
