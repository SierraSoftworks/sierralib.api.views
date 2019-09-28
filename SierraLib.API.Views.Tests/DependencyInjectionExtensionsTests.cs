namespace SierraLib.API.Views.Tests
{
    using System;
    using System.Reflection;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using SierraLib.API.Views.Examples;

    public class DependencyInjectionExtensionsTests
    {
        [Test]
        public void TestAddModelRepresenter()
        {
            var services = new ServiceCollection();

            services.AddModelRepresenter<UserProfile, UserProfile.Version1, UserProfile.Version1.Representer>().Should().BeSameAs(services);

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<IRepresenter<UserProfile, UserProfile.Version1>>().Should().NotBeNull();
        }

        [Test]
        public void TestAddModelRepresentersFromAssembly()
        {
            var services = new ServiceCollection();

            services.AddModelRepresentersFromAssembly(Assembly.GetAssembly(typeof(UserProfile))).Should().BeSameAs(services);

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<IRepresenter<UserProfile, UserProfile.Version1>>().Should().NotBeNull();
        }
    }
}