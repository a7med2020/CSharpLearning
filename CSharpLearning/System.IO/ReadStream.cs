using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CSharpLearning.System.IO
{
    public class ReadStream
    {
        public static void Execute()
        {
         
            using (var stream =  File.OpenRead("Example.txt"))
            using (var reader = new StreamReader(stream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }

            using (StreamReader reader = new StreamReader("Example.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            using (StreamWriter writer = new StreamWriter("Example.txt"))
            {
                writer.WriteLine("Hello, World!");
            }
        }

    }
}
