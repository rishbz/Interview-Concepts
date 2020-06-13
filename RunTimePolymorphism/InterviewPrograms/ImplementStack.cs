using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism.InterviewPrograms
{
    public class ImplementStack<T> where T:struct
    {
        T[] arr ;
        int head = 0;
         
        public ImplementStack() 
        {
            arr = new T[10];
        }

        public void Push(T inp)
        {
            if (head > arr.Length)
            {
                Array.Resize(ref arr, head);
                arr[head-1] = inp;
            }
            else
            {
                arr[head++] = inp;
            }
        }

        public void Pop()
        {
            Array.Resize(ref arr, head - 1);
        }

        public void d()
        {
            Stack s = new Stack();
            s.Push(1);
            s.Push("3");
            s.Pop();
            s.Pop();
        }
    }
}
