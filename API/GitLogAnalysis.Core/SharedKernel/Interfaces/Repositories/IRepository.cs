using GitLogAnalysis.Core.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GitLogAnalysis.Core.SharedKernel.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T Create(T obj);
        T Update(T obj);
        void Delete(int id);
        T GetById(int id);
        T GetByIdWithIncludes(int id, bool asNoTracking = true,
            params Expression<Func<T, object>>[] includeExpressions);
        IEnumerable<T> GetAllWithIncludes(Expression<Func<T, object>> ordenacao = null,
           params Expression<Func<T, object>>[] includeExpressions);
        IList<T> GetAll();
        void Inactivate(T entity);
    }
}
