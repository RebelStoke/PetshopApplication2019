using System;
using Microsoft.Extensions.DependencyInjection;
using PetshopApp2019.Core;
using PetshopApp2019.Core.ApplicationService;
using PetshopApp2019.Core.ApplicationService.Impl;
using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Infrastructure.Data.Repositories;

namespace PetshopApp2019.UI.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();


            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.PrintUI();
        }
    }
}
