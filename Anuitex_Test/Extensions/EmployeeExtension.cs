using Anuitex_Test.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anuitex_Test.Extensions
{
    public static class EmployeeExtension
    {
        public static bool WorksIn(this Employee source, Company company)
            => company.Employees.EmployeePresent(source);
       
    }
}
