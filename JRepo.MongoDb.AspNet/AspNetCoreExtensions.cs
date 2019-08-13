using JRepo.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using JRepo.AspNet;
using MongoDB.Driver;

namespace JRepo.MongoDb.AspNet
{
    public static class AspNetCoreExtensions
    {
        public static IServiceCollection AddMongoDbJRepoAuto<T>(this IServiceCollection serviceCollection) where T : class, IId<string>
        {
            return serviceCollection.AddMongoDbJRepo<string, T>(it => it.GetService<IMongoDatabase>());
            //return serviceCollection.AddJRepo<T>(it => new MongoRepository<T>(it.GetService<IMongoCollection<T>>()));
        } 
        
        public static IServiceCollection AddMongoDbJRepoAuto<TKey, T>(this IServiceCollection serviceCollection) where T : class, IId<TKey>
        {
            return serviceCollection.AddMongoDbJRepo<TKey, T>(it => it.GetService<IMongoDatabase>());
            //return serviceCollection.AddJRepo<T>(it => new MongoRepository<T>(it.GetService<IMongoCollection<T>>()));
        }
        
        public static IServiceCollection AddMongoDbJRepo<T>(this IServiceCollection serviceCollection, Func<IServiceProvider, IMongoDatabase> implementationFactory ) where T : class, IId<string>
        {
            return serviceCollection.AddJRepo<string, T>(it => new MongoRepository<string, T>(implementationFactory.Invoke(it)));
        }
        
        public static IServiceCollection AddMongoDbJRepo<TKey, T>(this IServiceCollection serviceCollection, Func<IServiceProvider, IMongoDatabase> implementationFactory ) where T : class, IId<TKey>
        {
            return serviceCollection.AddJRepo<TKey, T>(it => new MongoRepository<TKey, T>(implementationFactory.Invoke(it)));
        }
        
        public static IServiceCollection AddMongoDbJRepo<TKey, T>(this IServiceCollection serviceCollection) where T : class, IId<TKey>
        {
            return serviceCollection.AddMongoDbJRepo<TKey, T>(it => it.GetService<IMongoCollection<T>>());
            //return serviceCollection.AddJRepo<T>(it => new MongoRepository<T>(it.GetService<IMongoCollection<T>>()));
        }
        
        public static IServiceCollection AddMongoDbJRepo<TKey, T>(this IServiceCollection serviceCollection, Func<IServiceProvider, IMongoCollection<T>> implementationFactory ) where T : class, IId<TKey>
        {
            return serviceCollection.AddJRepo<TKey, T>(it => new MongoRepository<TKey, T>(implementationFactory.Invoke(it)));
        }
    }
}
