using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Mercidez
    {

        public static void EngineIgniting(string engine)
        {
            Console.WriteLine(engine);
        }

        //static void Main(string[] args)
        //{
        //    Car car = new Car();
        //    //Jaguar can send its own method for driving the car.
        //    car.ProcessDrive(EngineIgniting);
        //}
    }

    public class Jaguar
    {
        public static void EngineStartForJag(string engine)
        {
            Console.WriteLine("staring jag");
        }

        static void Main()
        {
            Car car = new Car();
            car.Name = "Jag";
            //Jaguar can send its own method for driving the car.
            car.ProcessDrive(EngineStartForJag);
        }
    }

    public class Car
    {
        public delegate void DriveCar(string car);

        public string Name { get; set; }
        
        public int Speed { get; set; }

        /// <summary>
        /// Now, any class implementing Car class can pass their own version - They just need to send method with accepted delegate signature
        /// Thus, helping us achieve SOLID principles and IOC as well.
        /// </summary>
        /// <param name="dc">Accepts method which ccan marry the delegate</param>
        public void ProcessDrive(DriveCar dc)
        {
            //DriveCar dd = new DriveCar(Jaguar.EngineStartForJag); //Basic way how we instantiate a delegate

            dc("Engine Starting for " + Name);
        }
    }

   
}
