using Contracts;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public AppDbContext dbContext { get; set; }

        public RepositoryBase(AppDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));           
        }

        public virtual void Create(T entity)
        {
            dbContext.Set<T>().Add(entity);           
        }
               
        

        public virtual void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }

        public virtual IQueryable<T> FindAll() =>
                        dbContext.Set<T>().AsNoTracking();



        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
                        dbContext.Set<T>()
                        .Where(expression).AsNoTracking();          
    }
}
