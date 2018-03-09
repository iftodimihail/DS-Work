using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MathLibrary
{
    public class SimpleMath : MarshalByRefObject
    {
        public SimpleMath()
        {
            Console.WriteLine("SimpleMath actor called");
        }
        public int Add(int n1, int n2)
        {
            Console.WriteLine("SimpleMath.Add({0}, {1})", n1, n2);
            return n1 + n2;
        }
        public int Subtract(int n1, int n2)
        {
            Console.WriteLine("SimpleMath.Subtract({0}, {1})", n1,n2);
            return n1 - n2;
        }

        public int[] SortArray(int[] array)
        {
            Array.Sort(array);
            Console.WriteLine("SimpleMath.SortArray({0})",array);
            return array;
        }

        public int[] DeleteFromArray(int[] array, int a)
        {
            Console.WriteLine("SimpleMath.DeleteFromArray({0},{1})", array,a);
            return array.Where(val => val != a).ToArray();
        }

        public bool SearchInArray(int[] array, int a)
        {
            Console.WriteLine("SimpleMath.DeleteFromArray({0},{1})", array, a);
            if (Array.IndexOf(array, a)>=0)
            {
                return true;
            }
            return false;
        }
        
    }

    public class Customer : MarshalByRefObject
    {
        string mName;
        public Customer(string name)
        {
            Console.WriteLine("Customer.ctor({0})", name);
            mName = name;
        }
        public string SayHello()
        {
            Console.WriteLine("Customer.SayHello()");
            return "Hello " + mName;
        }
    }
}