using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism.InterviewPrograms
{
    public class LongestIncreasingSubsequence
    {
        public static void FindMinSubsequenceToBeRemoved()
        {
            int[] arr = new int[] { 2, 1, 3, 1, 4, 1, 3 };
            int[] lis = new int[arr.Length];

            int arrDistinCount = arr.Distinct().Count();
            Dictionary<int, string> stringDict = new Dictionary<int, string>();

            for (int i = 0; i < arr.Length; i++)
            {
                stringDict.Add(i, i.ToString());
                var list = arr.ToList();
                list.RemoveAt(i);
                if (list.Count() == arrDistinCount)
                {
                    Console.WriteLine(arr[i]);
                }
            }


            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] >= arr[j] && lis[i] <= lis[j] + 1)
                    {
                        lis[i] = lis[j] + 1;
                        stringDict[i] = stringDict[j] + i;
                        CheckRemovalValuesMakesUnique(stringDict[i], arr);
                    }
                }
            }
        }

        private static void CheckRemovalValuesMakesUnique(string valsToRemove, int[] arr)
        {
            var my = arr.ToList();

            for (int i = 0; i < valsToRemove.Length; i++)
            {
                my[valsToRemove[i] - '0'] = -1;
            }

            my.RemoveAll(c => c == -1);

            if (my.Count == my.Distinct().Count() && my.Count() == arr.Distinct().Count())
            {
                Console.WriteLine(valsToRemove);
            }
        }

        public static void FindLongestIncreasingSubSequence()
        {
            int[] arr = new int[] { 3, 2, 6, 4, 5, 1 };

            int n = 6;
            int[] lis = new int[n];
            int max = 0;

            var dictionary = new Dictionary<int, List<int>>();
            var stringDict = new Dictionary<int, string>();

            /* Initialize LIS values for all indexes */
            for (int i = 0; i < n; i++)
            {
                lis[i] = 1;
                stringDict.Add(i, arr[i].ToString());
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                    {
                        lis[i] = lis[j] + 1;
                        stringDict[i] = stringDict[j] + " " + arr[i];
                    }
                }
            }

            /* Pick maximum of all LIS values */
            for (int i = 0; i < n; i++)
                if (max < lis[i])
                    max = lis[i];
        }
    }
}
