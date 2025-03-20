using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpLearning.System.IO
{
   public class WriteToTextFile
    {
        public static void LogErrorData(string line)
        {
            string folderPath = @"C:\LogMatchErors\";
            string fileName = "output.txt";
            string filePath = Path.Combine(folderPath, fileName);

            // Ensure the directory exists
            Directory.CreateDirectory(folderPath);

            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    // Optionally, you can write something to the file here
                }
            }

            StringBuilder content = new StringBuilder();


            content.AppendLine(line);



            content.AppendLine("=========================================================================");
            WriteToFile(filePath, content);
        }


        private static void WriteToFile(string filePath, StringBuilder content)
        {
            // Create or overwrite the file with the provided content
            using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                writer.WriteLine(Convert.ToString(content));
            }
        }
    }

}
