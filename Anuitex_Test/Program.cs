using System;
using System.IO;
using Anuitex_Test.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace Anuitex_Test
{
    class Program
    {
        public static ServiceProvider Services;
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            Services = serviceCollection.BuildServiceProvider();
            serviceCollection.AddSingleton<AppRepository>();
        }
    }
}
