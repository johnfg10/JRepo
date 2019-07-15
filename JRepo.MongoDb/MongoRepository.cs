using JRepo.Core;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace JRepo.MongoDb
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

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await (await MongoCollection.FindAsync(predicate)).FirstOrDefaultAsync();
        }

        public Task ReplaceOneAsync(Expression<Func<T, bool>> predicate, T replaceObj)
        {
            return MongoCollection.ReplaceOneAsync(predicate, replaceObj);
        }

        public Task UpdateAsync(Expression<Func<T, bool>> predicate, object updateObject)
        {
            return MongoCollection.UpdateOneAsync(predicate, new ObjectUpdateDefinition<T>(updateObject));
        }
        
        public Task UpdateStringAsync(Expression<Func<T, bool>> predicate, string updateJson)
        {
            //return MongoCollection.UpdateOneAsync(predicate, new JsonUpdateDefinition<T>(updateJson));
            return MongoCollection.UpdateOneAsync(predicate, new BsonDocumentUpdateDefinition<T>(BsonDocument.Parse(updateJson)));
        }
    }
}
