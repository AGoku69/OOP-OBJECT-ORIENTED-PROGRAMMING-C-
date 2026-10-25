using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read the content of a text file and display it on the console
            string path = @"E:\UET 2nd SEM\OOP\lab\Task8\TextFile1.txt";
            StreamReader content = new StreamReader(path);
            Console.WriteLine(content.ReadToEnd());
            Console.ReadKey();
            content.Close();
            // Append a new line to the text file
            string newPath = @"E:\UET 2nd SEM\OOP\lab\Task8\TextFile1.txt";
            StreamWriter writer = new StreamWriter(newPath,true);
            writer.WriteLine("\n This is a new line added to the file ...");
            //writer.Flush();
            writer.Close();

            // Read the content of the new text file and display it on the console
            string newPath2 = @"E:\UET 2nd SEM\OOP\lab\Task8\TextFile1.txt";
            if(File.Exists(newPath2))
            {
                StreamReader content2 = new StreamReader(newPath2);
                string fileContent;
                while((fileContent = content2.ReadLine()) != null)
                {
                    Console.WriteLine(fileContent);
                }
                content2.Close();
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
    }
}
