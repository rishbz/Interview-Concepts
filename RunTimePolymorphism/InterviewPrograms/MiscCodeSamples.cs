using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism.InterviewPrograms
{
    public class MiscCodeSamples
    {
        public static void ObjectComparer()
        {
            Car c1 = new Car() { Speed = 300, Mileage = 33.4, Name = "Sclass350" };
            Car c2 = new Car() { Speed = 400, Mileage = 31.4, Name = "Cclass350" };
            Car c3 = new Car() { Speed = 300, Mileage = 33.4, Name = "Sclass350" };

            var isTrue = c1.Equals(c2);
            //Always use -> Object.ReferenceEquals(c1, c2) for object comparison;
        }

        public static void SortListOnMemberOfaClass()
        {
            List<Car> carList = new List<Car>() 
            {
                new Car{ Name="sclass", Speed=200, Mileage=33.9},
                new Car{Name="mclass", Speed = 300, Mileage=3.4},
                new Car { Name="cclass", Speed = 333, Mileage= 4.5}
            };

            IComparer<Car> compare = new Comparators<Car>();
            carList.Sort(compare);
        }

        public static void Linq()
        {
            int[] arr = new int[] { 2, 3, 4, 5, 6, 7, 3, 4, 2, 2, 2, 100000, 100000 };

            #region Pick the most repetive number
            var myList2 = arr.GroupBy(c => c).OrderByDescending(c => c.Count()).Select((number, count) => new { number.Key, count = number.Count() }).FirstOrDefault();

            var pick = (from c in arr.GroupBy(e => e).OrderByDescending(e => e.Count())
                        select new { number = c.Key, count = c.Count() }).FirstOrDefault();
            #endregion

            SortedList<int, int> mySorted = new SortedList<int, int>();
            foreach (var item in arr)
            {
                if (!mySorted.ContainsKey(item))
                {
                    mySorted.Add(item, 1);
                }
                else
                    mySorted[item]++;
            }

            var df = mySorted.OrderByDescending(c => c.Value).FirstOrDefault();


            // Picklist below is iEnumerable
            var pickList = from c in arr.GroupBy(e => e).OrderByDescending(e => e.Count())
                           select new { number = c.Key, count = c.Count() };

            // On an IEnumerable type, we can iterat an Enumertor to loop throw like shown below.
            var dlist = pickList.GetEnumerator();

            while (dlist.MoveNext())
            {
                var a = dlist.Current;
            }


        }

        /// <summary>
        /// Update employees gender "male" to "female" and "female" to "male" using LINQ in 1 query.
        /// </summary>
        public static void LinqAvalaraQuestion()
        {
            var emps = Employee.GetAllEmployees();

            emps.ForEach(d => d.Gender = (d.Gender == "Male") ? "Female" : "Male");

            (from c in emps where c.Gender == "Male" || c.Gender == "Female" select c).ToList().ForEach(d => d.Gender = (d.Gender == "Male") ? "Female" : "Male");
        }

        public static int maxRepeating()
        {
            int k = 100000;
            int[] arr = new int[] { 0, 1, 3, 0, 3, 8, 8, 8 };
            int n = arr.Length;

            // Iterate though input array, for 
            // every element arr[i], increment 
            // arr[arr[i]%k] by k 
            for (int i = 0; i < n; i++)
                arr[(arr[i] % k)] += k;

            // Find index of the maximum  
            // repeating element 
            int max = arr[0], result = 0;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    result = i;
                }
            }

            // Return index of the  
            // maximum element 
            return result;
        }

        public static void Sorting()
        {
            int[] arr = new int[] { 4, 2, 3, 0, 8, 1,33,22,4,2,34,55,6,322,2,1,1,25,13,15,16,33 };
            //2,3,4,0

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i-1; j >= 0; j--)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j]; //4
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                    else
                        break;
                }
            }
        }

        public static void InsertionInSortedSequenceOptimized()
        {
            int[] arr = new int[] { 3,4,5,16,27};
            int element = 8;
            int index = 0;
            int end = arr.Length-1;
            int start = 0;
            while(true){
                if (start == end)
                {
                    index = start + 1;   
                }
                int middle = (start + end )/ 2;

                if (arr[middle] < element)
                    start = middle+1;
            }
        }

        public static int BinarySearch(int [] arr, int left,int right, int element)
        {

            int mid = left + right / 2;
            if (arr[mid] < element)
            {
                left = mid;
            }
            else if (arr[mid] > element)
            {
                right = mid;
            }
            else
            {
                return mid;
            }

            return BinarySearch(arr, left, right, element);

        }
    }

    public class Comparators<T> : IComparer<T>
    {
        //How implement open closed here.
        public int Compare(T x, T y)
        {
            if (x.GetType() == typeof(Car))
            {
                var c1 = (Car)(Object)x;
                var c2 = (Car)(Object)y;

                if (c2.Speed > c1.Speed)
                    return 1;
                else if (c2.Speed < c1.Speed)
                    return -1;
                else
                    return 0;
            }

            return 0;
        }
    }

    public class Employee
    {
        public string Name { get; set; }

        public String Gender { get; set; }

        public int Age { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> empList = new List<Employee>() { new Employee { Name = "Rishab", Gender = "Male" }, new Employee{Name = "Powerpuff", Gender = "Girls"},
            new Employee{Name = "Babloo", Gender = "Male"}};

            return empList;
        }
    }
}
