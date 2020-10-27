using System;
using System.Collections.Generic;
using System.Text;

namespace Anuitex_v2.Models
{
    class Brigadier : Employee
    {
        public Brigadier(string fullname, int experience) : base(fullname, experience) { }

        public Brigadier() : base() { }

        public override void DoWork() => Console.WriteLine("Materials have been bought");

        public void CheckWorkers() => Console.WriteLine("The workers have been checked");

    }
}
