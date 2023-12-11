using Entities;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MARDBContext _context;
        private DbSet<T> table = null;
        public GenericRepository(MARDBContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public void Delete(object id)
        {
            T existing = GetById(id);
            table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return  table.ToList();
        }

        public IEnumerable<T> GetAll(Func<T,bool> expression)
        {
            return table.Where(expression).ToList();
        }

        public T GetById(object id)
        {
            table.AsNoTracking();
            var data= table.Find(id);
            table.AsNoTracking();
            _context.Entry(data).State = EntityState.Detached;
            return data;
        }

        public void Insert(T entity)
        {
            table.Add(entity);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Dispose()
        {
            _context.Dispose();
        }






    }
}
