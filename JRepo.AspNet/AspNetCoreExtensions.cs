using JRepo.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JRepo.AspNet
{
    public static class AspNetCoreExtensions
    {
        public static IServiceCollection AddJRepo<T>(this IServiceCollection serviceCollection,
            Func<IServiceProvider, IRepository<string, T>> implementationFactory) where T : IId<string>
        {
            return serviceCollection.AddJRepo(implementationFactory);
        }
        
        public static IServiceCollection AddJRepo<TKey, T>(this IServiceCollection serviceCollection, Func<IServiceProvider, IRepository<TKey, T>> implementationFactory) where T : class, IId<TKey>
        {
            return serviceCollection.AddScoped(implementationFactory);
        }
    }
}
