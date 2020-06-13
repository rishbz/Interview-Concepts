using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism
{
    public class sClass : Mercidez
    {
        public override void Throttles()
        {
            Console.WriteLine("S class throttles at 180kmph");
        }

        public new void MemorizeSeatSetting()
        {
            Console.WriteLine("sclass memory seat setup!");
        }

        new public void test()
        {

        }
    }
}
