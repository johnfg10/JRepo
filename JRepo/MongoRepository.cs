using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JRepo
{
    public class MongoRepository<T> : IRepository<T>
    {
        public MongoRepository(IMongoCollection<T> mongoCollection)
        {
            MongoCollection = mongoCollection;
        }

        public IMongoCollection<T> MongoCollection { get; }

        public Task CreateAsync(T obj)
        {
            return MongoCollection.InsertOneAsync(obj);
        }

        public Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            return MongoCollection.DeleteOneAsync(predicate);
        }

        public async Task<List<T>> GetAsync(Expression<Func<T,bool>> predicate)
        {
            var res = await MongoCollection.FindAsync<T>(predicate);
            return await res.ToListAsync();
        }

        public Task UpdateAsync(Expression<Func<T, bool>> predicate, object updateObject)
        {
            return MongoCollection.UpdateOneAsync(predicate, new ObjectUpdateDefinition<T>(updateObject));
        }
    }
}
