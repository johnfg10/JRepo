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
        public static IServiceCollection AddMongoDbJRepo<T>(this IServiceCollection serviceCollection) where T : class
        {
            return serviceCollection.AddMongoDbJRepo<T>(it => it.GetService<IMongoCollection<T>>());
            //return serviceCollection.AddJRepo<T>(it => new MongoRepository<T>(it.GetService<IMongoCollection<T>>()));
        }
        
        public static IServiceCollection AddMongoDbJRepo<T>(this IServiceCollection serviceCollection, Func<IServiceProvider, IMongoCollection<T>> implementationFactory ) where T : class
        {
            return serviceCollection.AddJRepo<T>(it => new MongoRepository<T>(implementationFactory.Invoke(it)));
        }
    }
}
