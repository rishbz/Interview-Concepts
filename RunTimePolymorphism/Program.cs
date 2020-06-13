using RunTimePolymorphism.InterviewPrograms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism
{
    public class A {
        public A(int z)
        {
            z = 12;
            int j = 12;
            Console.WriteLine(z*j);
        }
    }

    class B :A
    {
        public B(int u):base(u)
        {
            u = 13;
            int h = 13;
            Console.WriteLine(u + h);
        }
    }

    class C : B
    {
        public C(int k) : base(k)
        {
            k = 24;
            int o = 6;
            Console.WriteLine(k / o);
        }
    }


    class Program
    {
        public static string change(string tst)
        {
             tst +="achaaddkiya";
            return tst;
        }
       
        //https://www.c-sharpcorner.com/article/understand-antiforgeri-token-in-asp-net-mvc/
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 0, 6, 18, 10 };

            int element = MiscCodeSamples.BinarySearch(array, 0, array.Length - 1, 6);
            var arr5 = new int[] {100,2,7,2,100};

            SortedList<int,int> lsd = new SortedList<int,int>();

            var arr6 = new int[100000];

            for (int i = 0; i < arr5.Length; i++)
            {
                arr6[arr5[i]]++;
            }

            var lsdd = new List<int>();

            for (int i = 0; i < arr6.Length; i++)
            {
                if (arr6[i] >= 2)
                {
                    for (int q = 1; q < arr6[i]; q++)
                    {
                        lsdd.Add(i);
                    }
                }

            }


            C ch = new C(10);

            var dd = new Program();
            string tst = "hey";

            string tst1 = "hey1";
            tst1 = tst;
            var check= object.ReferenceEquals(tst, tst1);

            tst = "ok";

            string oh = change(tst);

            
            Console.WriteLine(tst1);

            Car obj = new Car { Name = "merc", MyBenz = new Mercidez { Name="cclass" } };

            Car obj2 = (Car) obj.clone();

            Console.WriteLine(obj2.Name);
            Console.WriteLine(obj2 == obj);

            obj.Name = "jaguar!";

            Console.WriteLine(obj2.Name);

            string test = "hi";
            string test1 = "hi";

            StringBuilder b1 = new StringBuilder("ok");
            StringBuilder b2 = new StringBuilder("ok");

            ArrayList ar = new ArrayList{test,b1};

            Console.WriteLine(ar.Contains(test1)); //true
            Console.WriteLine(ar.Contains(b2)); // false
            Console.WriteLine(ar.Contains(b1.ToString()));

            
            IEnumerable arr = new int[] { 2, 3, 4, 5, 6 };

            List<int> aa = new List<int> {1,2 };

            
            var t = arr.Cast<int>().ToList();

            foreach (var item in t)
            {
                Console.WriteLine(item);
            }

            // Static constructor is called once for one AppDomain.
            StaticConstructor constructorTest = new StaticConstructor();

            #region MethodOverriding

            Mercidez merci = new Mercidez();
            merci.Throttles(); 
            Car mclass = new Mercidez();
            mclass.Throttles(); //Calls mercidez method bcz it is overriden by merci class.
            mclass.MemorizeSeatSetting(); //Calls class method bcz we have marked method as new in Merci class hence doing method hiding here.
            Car anycar = new Car();
            anycar.Throttles();

            Mercidez sclass = new sClass();
            sclass.Throttles();
            sclass.MemorizeSeatSetting(); //Calls base class i.e.Mercidez method as its own method is marked as new.

            Furniture chair = new Chair();
            chair.CreateFurniture(); //Calls furniture(base class) method because in derived class this method is marked as new.
            chair.IamGoingToBeOverriden(); // Calls derived class method as overriden.

            // chair.ChairKaPersonalMethod(); not able to call from here: Reason: https://stackoverflow.com/questions/33131610/base-class-new-derived-class-how-does-this-work
            
            Furniture table = new Table();
            table.CreateFurniture();
            table.MoveFurniture();

            Chair chr = new Chair();
            chr.MoveFurniture();             //this is method hiding.
            chr.CreateFurniture();

            Furniture furn = new Furniture();
            furn.IamGoingToBeOverriden();
            furn.MoveFurniture();

            #endregion

            var actions = new List<Action>();
            for (int i = 0; i < 5; i++)
                actions.Add(() => Console.WriteLine(i));
            foreach (var action in actions)
                action();
           
        }

    }

    public static class extension
    {
        public static void Check(this Mercidez m)
        {
            Console.Write(m);
        }
    }
}
