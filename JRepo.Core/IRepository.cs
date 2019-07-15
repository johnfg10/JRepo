using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace JRepo.Core
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        
        Task<T> GetOneAsync(Expression<Func<T, bool>> predicate);

        Task ReplaceOneAsync(Expression<Func<T, bool>> predicate, T replaceObj);
        
        Task UpdateAsync(Expression<Func<T, bool>> predicate, object updateObject);
        
        Task UpdateStringAsync(Expression<Func<T, bool>> predicate, string updateJson);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        Task CreateAsync(T obj);
    }
}
