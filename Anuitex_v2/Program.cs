using System;
using System.Collections.Generic;
using Anuitex_v2.Extensions;
using Anuitex_v2.Interfaces;
using Anuitex_v2.Models;
using Anuitex_v2.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace Anuitex_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAppRepository, AppRepository>()
                .BuildServiceProvider();

            var repo = serviceProvider
                        .GetService<IAppRepository>();

            var e1 = new Manager("Danyilll", 7);
            var e2 = new Brigadier("Maxym", 1);
            var e3 = new Worker("Iryna", 3);

            repo.AddEmployee(e1);
            repo.AddEmployee(e2);
            repo.AddEmployee(e3);

            repo.AddCompany(new Company("Anuitex", new List<Employee>()));

            repo.AddEmployeeToCompany(repo.FindCompanyByName("Anuitex"), e1);
            repo.AddEmployeeToCompany(repo.FindCompanyByName("Anuitex"), e2);
            repo.AddEmployeeToCompany(repo.FindCompanyByName("Anuitex"), e3);

            repo.GetEmployeesByCompany(repo.FindCompanyByName("Anuitex")).PrintList();

            repo.RemoveEmployeeFromCompany(repo.FindCompanyByName("Anuitex"), e1);

            repo.GetEmployeesByCompany(repo.FindCompanyByName("Anuitex")).PrintList();

            Console.WriteLine(repo.FIndEmployeeByName("Iryna").WorksIn(repo.FindCompanyByName("Anuitex")));

            repo.GetByType<Manager>().PrintList();

            Console.WriteLine(repo.GetCountByType<Manager>());

            repo.RemoveCompany(repo.FindCompanyByName("Anuitex"));

            Console.WriteLine(e2.CompanyId);


        }
    }
}
