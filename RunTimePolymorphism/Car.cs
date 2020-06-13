using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism
{
    public class Car
    {
        public string Name { get; set; }

        public double Mileage { get; set; }

        public int Speed { get; set; }

        public Mercidez MyBenz { get; set; }

        public virtual void Throttles()
        {
            Console.WriteLine("A car throttles!");
        }

        public void MemorizeSeatSetting()
        {
            Console.WriteLine("This car has memory setting");
        }

        public object clone()
        {
            return this.MemberwiseClone();
        }

        public void MethodOverload(int a, int b) { }

        public void MethodOverload(String a, int b) { }

        // Method overload does not depend on return type of method
        //public int MethodOverload(int a, int b) { return 0; }
    }
}
