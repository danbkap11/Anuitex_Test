using System;
using System.Collections.Generic;
using System.Text;

namespace Anuitex_v2.Models
{
    public abstract class Employee
    {
        public Employee(string fullname, int experience)
        {
            FullName = fullname;
            Experience = experience;
            Id = Guid.NewGuid();
        }
        public Employee() : this("Danyil Prokopchuk", 5) { }

        public Guid Id { get; set; }

        public string FullName { get; set; }

        public int Experience { get; set; }

        public Guid CompanyId { get; set; }

        public abstract void DoWork();

        public override string ToString()
        {
            return $"Name: {FullName}, Experience: {Experience}";
        }

    }
}
