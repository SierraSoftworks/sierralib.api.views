namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Linq;
    using System.Reflection;
    using SierraLib.API.Views;

    /// <summary>
    /// Extension methods for <see cref="Microsoft.Extensions.DependencyInjection"/> which simplify working
    /// with <see cref="SierraLib.API.Views"/>.
    /// </summary>
    public static class APIViewsExtensions
    {
        /// <summary>
        /// Add a model representer to the service collection for the given model and view types.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <typeparam name="TModel">The type of the model to add a representer for.</typeparam>
        /// <typeparam name="TView">The type of view for the model.</typeparam>
        /// <typeparam name="TRepresenter">The representer implementation.</typeparam>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddModelRepresenter<TModel, TView, TRepresenter>(this IServiceCollection services)
            where TView : IView<TModel>
            where TModel : class
            where TRepresenter : class, IRepresenter<TModel, TView>
        {
            if (services is null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }

            return services.AddSingleton<IRepresenter<TModel, TView>, TRepresenter>();
        }

        /// <summary>
        /// Adds all implementations of the IRepresenter interface to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="assembly">The assembly from which to load implementations.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddModelRepresentersFromAssembly(this IServiceCollection services, Assembly assembly = null)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            assembly = assembly ?? Assembly.GetExecutingAssembly();

            foreach (var implementingType in assembly.GetTypes())
            {
                var representerImplementations = implementingType.GetInterfaces().Where(IsFullyQualifiedRepresenterInterface);
                foreach (var representerInterface in representerImplementations)
                {
                    services.AddSingleton(representerInterface, implementingType);
                }
            }

            return services;
        }

        private static bool IsFullyQualifiedRepresenterInterface(Type type)
        {
            return type != null && type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(IRepresenter<,>);
        }
    }
}