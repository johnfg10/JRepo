using JRepo.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JRepo.AspNet
{
    public static class AspNetCoreExtensions
    {
        public static IServiceCollection AddJRepo<T>(this IServiceCollection serviceCollection, Func<IServiceProvider, IRepository<T>> implementationFactory) where T : class
        {
            return serviceCollection.AddScoped<IRepository<T>>(implementationFactory);
        }
    }
}
