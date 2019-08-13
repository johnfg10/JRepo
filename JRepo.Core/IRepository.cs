using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JRepo.Core
{
    public interface IRepository<TKey, T> where T : IId<TKey>
    {
        Task ReplaceOneAsync(Expression<Func<T, bool>> predicate, T replaceObj);
        
        Task UpdateAsync(Expression<Func<T, bool>> predicate, object updateObject);
        
        Task UpdateStringAsync(Expression<Func<T, bool>> predicate, string updateJson);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        Task CreateAsync(T obj);

        IQueryable<T> Queryable();
    }
}
