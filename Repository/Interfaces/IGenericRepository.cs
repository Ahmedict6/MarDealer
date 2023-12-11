using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IGenericRepository<T> where T :  class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, bool> expression);
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        
    }
}
