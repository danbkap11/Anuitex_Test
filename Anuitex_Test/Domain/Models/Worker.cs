using System;
using System.Collections.Generic;
using System.Text;

namespace Anuitex_Test.Models
{
    public class Worker : Employee
    {
        public Worker(string fullname, int experience) : base(fullname, experience) { }

        public Worker() : base() { }

        public override void DoWork() => Console.WriteLine("Some product has been released");
    }
}
