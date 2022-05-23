using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    abstract public class BaseUnit
    {

        private readonly Guid _id = Guid.NewGuid();
        private string _name = "";
        public Guid Id { get { return _id; } }
        public string Name { get { return _name; } set { _name = value; } }

        protected BaseUnit()
        {
        }
        public abstract void PrintInfo();
        public void PrintName()   
        { 

         Console.WriteLine($"\n BaseUnit -----> Unit name: {Name}");
        }

        public abstract string addtoJSON();


    }
}
