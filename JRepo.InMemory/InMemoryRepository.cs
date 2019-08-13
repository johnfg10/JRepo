using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JRepo.Core;
using JRepo.InMemory.Helpers;
using Newtonsoft.Json;

namespace JRepo.InMemory
{
    public class InMemoryRepository<TKey, T> : IRepository<TKey, T> where T : IId<TKey>
    {
        public List<T> InMemStore { get; set; } = new List<T>();
        
        public Task ReplaceOneAsync(Expression<Func<T, bool>> predicate, T replaceObj)
        {
            var memRes = InMemStore.FirstOrDefault(predicate.Compile());
            if (memRes == null)
                return Task.FromException<ArgumentNullException>(new ArgumentNullException());

            InMemStore[InMemStore.IndexOf(memRes)] = replaceObj;
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Expression<Func<T, bool>> predicate, object updateObject)
        {
            var memRes = Queryable().AsEnumerable().Where(predicate.Compile()).First();
            
            updateObject.CopyProperties(memRes);
            await ReplaceOneAsync(predicate, memRes);
        }

        public Task UpdateStringAsync(Expression<Func<T, bool>> predicate, string updateJson)
        {
            return UpdateAsync(predicate, JsonConvert.DeserializeObject(updateJson));
        }

        public Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var memRes = InMemStore.FirstOrDefault(predicate.Compile());
            if (memRes == null)
                return Task.FromException<ArgumentNullException>(new ArgumentNullException());

            InMemStore.Remove(memRes);
            return Task.CompletedTask;
        }

        public Task CreateAsync(T obj)
        {
            InMemStore.Add(obj);
            return Task.CompletedTask;
        }

        public IQueryable<T> Queryable()
        {
            return InMemStore.AsQueryable();
        }
    }
}