using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Anuitex_Test.Models
{
    public abstract class Employee
    {
        public Employee(string fullname, int experience)
        {
            FullName = fullname;
            Experience = experience;
        }
        public Employee() : this("Danyil Prokopchuk", 5) { }

        public int Id { get; set; }

        public string FullName { get; set; }

        public int Experience { get; set; }

        public int CompanyId { get; set; }

        public abstract void DoWork();

        public override string ToString()
        {
            return $"Name: {FullName}, Experience: {Experience}";
        }

    }
}
