using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism.InterviewPrograms
{
    class LargestNumberSortWithoutUsingSortButWithQueues
    {
        /// <summary>
        ///Program : K operations on provided list ex: 10,3,4,5,33. In k operations, divide any number by 2 such that sum minimum ho.
        ///Solution: Largest number ko K times 2 se divide krte jao. In below prog,we didnt use sort() function as it will 
        ///give timeout for big ops. Hence we use 2 queues. Ek khali queue lee usme dalte gye largest number.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int minSum(List<int> num, int k)
        {
            var compare = new Comparers<int>();

            num.Sort(compare);

            Queue<int> q1 = new Queue<int>(num);
            var q2 = new Queue<int>();
            int lh = 0;
            while (k > 0)
            {
                var largest = (q2.Count() == 0 || q1.Peek() > q2.Peek()) ? q1.Dequeue() : q2.Dequeue();

                if (q1.Count() == 0)
                {
                    Queue<int> temp = q1;
                    q1 = q2;
                    q2 = temp;
                }

                q2.Enqueue((largest + 1) / 2);
                k--;
            }
            int len = num.Count;

            for (int i = 0; i < k; i++)
            {
                num.Sort();
                double a = num[len - 1];
                var c = a / 2;
                var b = Math.Ceiling(c);
                num[len - 1] = Convert.ToInt32(c);
            }
            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                sum += num[i];
            }

            return sum;
        }

        public class Comparers<T> : IComparer<T>
        {
            public int Compare(T x, T y)
            {
                int c1 = (int)(object)x;
                int c2 = (int)(object)y;
                if (c2 > c1)
                    return 1;
                if (c2 < c1)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
