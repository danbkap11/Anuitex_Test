using System;
using System.Collections.Generic;
using System.Text;

namespace Anuitex_v2.Models
{
    class Manager : Employee
    {
        public Manager(string fullname, int experience) : base(fullname, experience) { }

        public Manager() : base() { }

        public override void DoWork() => Console.WriteLine("Orders have been gathered");

        public void GiveTask() => Console.WriteLine("The task has been given");
    }
}
