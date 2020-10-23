using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex_Test.Domain;
using Anuitex_Test.Extensions;
using Anuitex_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Anuitex_Test.Repos
{
    public class AppRepository
    {
        public async Task AddEmployeeAsync(Employee employee)
        {
            using(AnuitexContext context = new AnuitexContext())
            {
                if (!context.Employees.Contains(employee))
                {
                    await context.Employees.AddAsync(employee);
                    await context.SaveChangesAsync();
                }
            }
        }

        public Company AddEmployeeToCompany(Company _company, Employee _employee)
        {
            using (AnuitexContext context = new AnuitexContext())
            {
                var company = context.Companies.Include(cmp => cmp.Employees)
                                                        .Where(cmp => cmp.Id == _company.Id)
                                                        .FirstOrDefault();

                if(!_employee.WorksIn(_company))                                                                ;
                    company.Employees.Add(_employee);

                context.SaveChanges();
                return company;
            }
        }

        public Company RemoveEmployeeFromCompany(Company _company, Employee _employee)
        {
            using (AnuitexContext context = new AnuitexContext())
            {
                var company = context.Companies.Include(cmp => cmp.Employees)
                                                        .Where(cmp => cmp.Id == _company.Id)
                                                        .FirstOrDefault();

                if (_employee.WorksIn(_company)) 
                    company.Employees.Add(_employee);

                context.SaveChanges();
                return company;
            }
        }
        public async Task RemoveEmployeeAsync(Employee employee)
        {
            using (AnuitexContext context = new AnuitexContext())
            {
                if (context.Employees.Contains(employee))
                {
                    context.Employees.Remove(employee);
                    await context.SaveChangesAsync();
                }
            }
        }

        public IEnumerable<T> GetByType<T>() where T : Employee
        {
            using (AnuitexContext context = new AnuitexContext())
            {
                var employees = context.Employees;
                foreach (var employee in employees)
                {
                    if (employee is T)
                        yield return (T)employee;
                }
            }
        }

        public int GetCountByType<T>() where T : Employee
            => GetByType<T>().Count();

        public List<Employee> GetEmployeesByCompany(Company company)
        {
            using (AnuitexContext context = new AnuitexContext())
            {
                var employees = context.Employees.Where(emp => emp.CompanyId == company.Id)
                    .ToList();
                return employees;
            }
        }
    }
}
