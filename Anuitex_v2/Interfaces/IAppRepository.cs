using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anuitex_v2.Models;

namespace Anuitex_v2.Interfaces
{
    public interface IAppRepository
    { 
        void AddEmployee(Employee employee);

        void RemoveEmployee(Employee employee);

        void AddCompany(Company company);

        void RemoveCompany(Company company);

        Employee FIndEmployeeByName(string name);
        Company FindCompanyByName(string name);

        Company AddEmployeeToCompany(Company _company, Employee _employee);

        Company RemoveEmployeeFromCompany(Company _company, Employee _employee);

        List<Employee> GetEmployeesByCompany(Company company);

        IEnumerable<T> GetByType<T>() where T : Employee;

        int GetCountByType<T>() where T : Employee;

    }
}
