using JGuid.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGuid.AspNetCore
{
    public static class AspNetCoreExtensions
    {
        public static IServiceCollection AddGuidGenerator(this IServiceCollection serviceCollection, IGuidGenerator guidGen)
        {
            return serviceCollection.AddScoped<IGuidGenerator>(it => guidGen);
        }
    }
}
