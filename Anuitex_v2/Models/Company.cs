using System;
using System.Collections.Generic;
using System.Text;

namespace Anuitex_v2.Models
{
    public class Company
    {
        public Company() : this("Anuitex",
            new List<Employee>() {new Manager(), new Worker(), new Brigadier()})
        {
        }

        public Company(string name, List<Employee> employees)
        {
            Name = name;
            Employees = employees;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

        public static Company operator +(Company company, Employee employee)
        {
            if (employee.CompanyId != company.Id)
            {
                company.Employees.Add(employee);
                employee.CompanyId = company.Id;
            }
            else
            {
                Console.WriteLine("This employee already works in the company");
            }

            return company;
        }


        public static Company operator -(Company company, Employee employee)
        {
            if (employee.CompanyId == company.Id)
            {
                company.Employees.Remove(employee);
                employee.CompanyId = Guid.Empty;
            }
            else
            {
                Console.WriteLine("This employee doesn't work in this company");
            }

            return company;
        }

    }
}
