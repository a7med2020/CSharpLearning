using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLearning.Delegates
{
    class Callbacks
    {
    }

    class Program
    {
        // Events uses Delegates
        // Delegates are for callbacks , not encapsulated 
        // Events publisher subscriber model , encapsulated
        static void Main(string[] args)
        {
            MyFileSearch x = new MyFileSearch();
            // publisher -- subcriber
            // observable -- observer
            x.publisher += Subscriber1;
            //x.publisher += Subscriber2;
            //x.SendData = null;
            Console.WriteLine("File Search started....");
            Task.Run(() => x.Search("C:\\Windows")); // non blocking call
            //x.Search("E:\\shivprasad data"); // blocking call
            Console.WriteLine("Continue executing main function....");
            Console.ReadLine();
        }
        static void Subscriber1(string filename)
        {
            Console.WriteLine(filename);
        }
        static void Subscriber2(string filename)
        {
            Console.WriteLine(filename);
        }
    }
    public class MyFileSearch
    {
        public delegate void searchMethod(string search);
        public event searchMethod publisher = null;
        //public  searchMethod publisher = null; 
        public void Search(string dir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(dir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        publisher(f);
                        Thread.Sleep(500);
                    }


                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
