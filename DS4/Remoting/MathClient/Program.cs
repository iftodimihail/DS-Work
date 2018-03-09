using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using MathLibrary;
namespace MathClient
{
    class ClientMain
    {

        //private static string Choose()
        //{
        //    string choice = Console.ReadLine();
        //    return choice;
        //}

        static void Main(string[] args)
        {
            // Load the configuration file
            RemotingConfiguration.Configure("MathClient.exe.config");
            // Get a proxy to the remote object
            SimpleMath math = new SimpleMath();
            Console.Write("Introduceti lungime vector: ");
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("a[" + i + "]= ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("Sortare: Apasa 1");
            Console.WriteLine("Cautare: Apasa 2");
            Console.WriteLine("Stergere: Apasa 3");
            Console.WriteLine("Exit: Apasa 0");
 
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    int[] sortedArray = math.SortArray(array);
                    Console.Write("Vector sortat: ");
                    for (int j = 0; j < sortedArray.Length;j++)
                        Console.Write(sortedArray[j] + " ");
                    break;

                case "2":
                    Console.Write("Numar: ");

                    string x = Console.ReadLine();
                    int val1 = 0;
                    if (!string.IsNullOrWhiteSpace(x))
                    {
                        val1 = Convert.ToInt32(x);
                    }

                    if (math.SearchInArray(array, val1))
                    {
                        Console.WriteLine("Elementul exista");
                    }
                    else
                        Console.WriteLine("Elementul nu exista");
                    break;

                case "3":
                    Console.Write("Numar: ");
                    string y = Console.ReadLine();
                    int val2 = 0;

                    if (!string.IsNullOrWhiteSpace(y))
                    {
                        val2 = Convert.ToInt32(y);
                    }

                    int[] newArr = math.DeleteFromArray(array, val2);

                    Console.Write("Noul vector: ");
                    for (int k=0;k<newArr.Length; k++)
                        Console.Write(newArr[k] + " ");
                    break;

                default:
                    break;
            }

            // Use the remote object
            //Console.WriteLine("5 + 2 = {0}", math.Add(5, 2));
            //Console.WriteLine("5 - 2 = {0}", math.Subtract(5, 2));

            //int[] newArr = math.DeleteFromArray(array, 4);
            //int[] sortedArray = math.SortArray(array);

            //Console.Write("Sorted array: ");
            //foreach (int i in array)
            // Console.Write(array[i] + " ");
            // Ask user to press Enter
            Console.WriteLine("\nPress enter to close...");
            Console.ReadLine();
        }
    }
}


//class ClientMain
//{
//    static void Main(string[] args)
//    {
//        // Create and register the channel. The default channel actor
//    // does not open a port, so we can't use this to receive messages.
//        HttpChannel channel = new HttpChannel();
//        ChannelServices.RegisterChannel(channel);
//        // Get a proxy to the remote object
//        Object remoteObj = Activator.GetObject(typeof(MathLibrary.SimpleMath),"http://localhost:4000/MyURI.soap");
//        // Cast the returned proxy to the SimpleMath type
//        SimpleMath math = (SimpleMath)remoteObj;
//        // Use the remote object
//        Console.WriteLine("5 + 2 = {0}", math.Add(5, 2));
//        Console.WriteLine("5 - 2 = {0}", math.Subtract(5, 2));
//        // Ask user to press Enter
//        Console.Write("Press enter to end");
//        Console.ReadLine();
//    }
//}