using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Complaint.Data.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext { get; set; }
       

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }
        public void Create(T entity)
        {
            this._repositoryContext.Set<T>().Add(entity);
        }
        

        

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

       
    }
}
