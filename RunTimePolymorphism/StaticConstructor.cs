using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism
{
    class StaticConstructor
    {
        public int TestProp { get; set; }

        public static int MyProperty { get; set; }

        //private StaticConstructor()
        //{

        //}

        static StaticConstructor()
        {
            MyProperty = 3;
            Console.WriteLine("i got called");
        }

        public StaticConstructor()
        {

        }

        private StaticConstructor(int a)
        {

        }

      
    }
}
