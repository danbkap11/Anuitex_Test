using System;
using System.Collections.Generic;
using System.Text;
using Anuitex_v2.Models;

namespace Anuitex_v2.Extensions
{
    public static class EmployeeExtension
    {
        public static bool WorksIn(this Employee source, Company company)
            => company.Employees.EmployeePresent(source);

    }
}
