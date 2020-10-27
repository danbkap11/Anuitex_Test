using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex_v2.Extensions;
using Anuitex_v2.Interfaces;
using Anuitex_v2.Models;

namespace Anuitex_v2.Repos
{
    public class AppRepository : IAppRepository
    {
        public List<Employee> Employees = new List<Employee>();
        public List<Company> Companies = new List<Company>();
        public void AddEmployee(Employee employee)
        {
            if (!Employees.Contains(employee))
            {
                Employees.Add(employee);
            }
        }

        public void RemoveEmployee(Employee employee)
        {
            if (Employees.Contains(employee))
            {
                Employees.Remove(employee);
            }
        }

        public void AddCompany(Company company)
        {
            if (!Companies.Contains(company))
            {
                Companies.Add(company);
            }
        }

        public void RemoveCompany(Company company)
        {
            if (Companies.Contains(company))
            {
                foreach (var employee in company.Employees)
                {
                    employee.CompanyId = Guid.Empty;
                }

                Companies.Remove(company);
            }
        }

        public Company FindCompanyByName(string name)
            => Companies.Where(cmp => cmp.Name == name).FirstOrDefault();

        public Employee FIndEmployeeByName(string name)
            => Employees.Where(emp => emp.FullName == name).FirstOrDefault();
        public Company AddEmployeeToCompany(Company _company, Employee _employee)
            => _company += _employee;


        public Company RemoveEmployeeFromCompany(Company _company, Employee _employee)
            => _company -= _employee;
        

        public IEnumerable<T> GetByType<T>() where T : Employee
        {
            foreach (var employee in Employees)
            {
                if (employee is T)
                    yield return (T)employee;
            }
        }

        public int GetCountByType<T>() where T : Employee
            => GetByType<T>().Count();

        public List<Employee> GetEmployeesByCompany(Company company)
        {
            var employees = Employees.Where(emp => emp.CompanyId == company.Id)
                                                .ToList();
            return employees;
        }
    }
}
