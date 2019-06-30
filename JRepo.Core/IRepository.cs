using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JRepo.Core
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task UpdateAsync(Expression<Func<T, bool>> predicate, object updateObject);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        Task CreateAsync(T obj);
    }
}
