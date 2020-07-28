using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Parus.Data.Abstractions;
using System;

namespace Parus.Data.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, Action<IConnection> optionsAction = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return AddDataAccess(
                services,
                optionsAction == null
                    ? (Action<IServiceProvider, IConnection>)null
                    : (p, c) => optionsAction?.Invoke(c));
        }

        public static IServiceCollection AddDataAccess(this IServiceCollection services, Action<IServiceProvider, IConnection> optionsAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var connection = new Connection();
            services.TryAdd(new ServiceDescriptor(typeof(IConnection), c => ConnectionFactory(c, optionsAction), ServiceLifetime.Singleton));

            return services;
        }

        private static IConnection ConnectionFactory(IServiceProvider serviceProvider, Action<IServiceProvider, IConnection> optionsAction)
        {
            var connection = new Connection();
            optionsAction?.Invoke(serviceProvider, connection);

            return connection;
        }
    }
}
