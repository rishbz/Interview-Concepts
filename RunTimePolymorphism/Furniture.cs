using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism
{
    class Furniture
    {
        public virtual void CreateFurniture()
        {
            //enum,for,int, Comparer,COMPARETO,TRIM,TRIMEND,REMOVE,WHY STIRNG ref Type AND ARRAY MUTTABLE..CEATE UR OWN ARRAYLIST
            //TRY,CATCH PLAY WITH IT.copy constructor
            string life = "air";
            string big = "air";
            string best = "tree";
            var a= life.CompareTo(big);
            var b=life.CompareTo(best);
            var c = string.Compare(life, big);
            var d = string.Compare(life, best);
            
        }

        public virtual void IamGoingToBeOverriden()
        {

        }

        public void MoveFurniture() { }
    }

    class Chair : Furniture
    {
        public new void CreateFurniture() { }

        public override void IamGoingToBeOverriden()
        {
            Console.WriteLine("I am being called bcz I have overriden the base method");
            base.IamGoingToBeOverriden();
        }

        public new void MoveFurniture() { }

        public void ChairKaPersonalMethod() { }
    }

    class Table : Furniture
    {
        new public void CreateFurniture()
        {

        }
    }
}
