using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism.InterviewPrograms
{
    public class ImplementArrayList
    {
        //how compare two object..using sort to filter out car object list/// ienumerable vs ienumerator // hashtable vs dict

        public object[] arr;
        int i = 0;
        public int intialLength;

        public ImplementArrayList()
        {
            intialLength = 2;
            arr = new object[intialLength];
        }

        public void Add(object inp)
        {
            if (i == intialLength)
            {
                intialLength += intialLength;

                //Can also be done like :
                
                //object[] nnew = new object[intialLength];
                //arr.CopyTo(nnew, 0);
                //arr = nnew;
                Array.Resize(ref arr, intialLength);
            }

            arr[i++] = inp;
        }

        public void Remove(object inp)
        {
            var ff3 = arr.Select((a, index) => new { hahaha = a, index }).First(c => c.hahaha == inp).index;
        }
    }
}
