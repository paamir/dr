using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        T GetBy(Expression<Func<T, bool>> expression);
        void Create(T entity);
        bool Exist(Expression<Func<T, bool>> expression);
        void SaveChanges();

    }
}
