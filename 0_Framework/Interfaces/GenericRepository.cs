using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Interfaces
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Get(int id)
        {
            return _dbContext.Find<T>(id);
        }       

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().FirstOrDefault(expression);
        }

        public void Create(T entity)
        {
            _dbContext.Add(entity);
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Any(expression);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
