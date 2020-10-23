using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Anuitex_Test.Repos;
using Microsoft.Extensions.DependencyInjection;


namespace Anuitex_Test.Models
{
    public class Company
    {
        public Company() : this("Anuitex", 
                            new List<Employee>() { new Manager(), new Worker(), new Brigadier() }) { }
            
        public Company(string name, List<Employee> employees)
        {
            Name = name;
            Employees = employees;
            repo = Program.Services.GetService<AppRepository>();
        }
        private static AppRepository repo;
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

        public static Company operator +(Company company, Employee employee)
            =>  repo.AddEmployeeToCompany(company, employee);

        public static Company operator -(Company company, Employee employee)
            => repo.RemoveEmployeeFromCompany(company, employee);

    }
}
