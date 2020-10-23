using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anuitex_Test.Models;

namespace Anuitex_Test.Extensions
{
    public static class LINQExtension
    {
        public static bool EmployeePresent(this IEnumerable<Employee>? source, Employee _employee)
        {
            if (!(source?.Any() ?? false))
            {
                throw new InvalidOperationException("Cannot determine for a null or empty set.");
            }

            foreach (var employee in source)
            {
                if (employee.Id == _employee.Id)
                    return true;
            }
            return false;
        }

        public static void PrintList(this IEnumerable<Employee>? source)
        {
            if (!(source?.Any() ?? false))
            {
                throw new InvalidOperationException("Cannot print a null or empty set.");
            }

            foreach (var employee in source)
            {
               Console.WriteLine(employee.ToString());
            }
        }
    }
}
