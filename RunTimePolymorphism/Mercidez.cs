using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism
{
    public class Mercidez : Car
    {
        public override void Throttles()
        {
            Console.WriteLine("Mercidez car throttles at 150kmph");
        }

        
        public new void MemorizeSeatSetting()
        {
            Console.WriteLine("Setting up new feature to memorize seat settings!");
        }
    }
}
