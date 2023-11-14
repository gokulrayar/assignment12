using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace file_handling_managementsystem
{
    internal class Program
    {

        public static void CreateFile(string fileName, string content)
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(content);
                streamWriter.Close();
                fileStream.Close();
                Console.WriteLine("File Created Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error" + ex.Message);
            }
        }
        public static void ReadFile(string fileName)
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);
                String line = streamReader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = streamReader.ReadLine();
                    streamReader.Close();
                    fileStream.Close();
                }
                Console.WriteLine("File Readed Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error" + ex.Message);
            }
        }
        public static void AppendToFile(string fileName, string content)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("File does not Exist" + fileName);
                }
                StreamWriter streamWriter = new StreamWriter(fileName, true);
                streamWriter.WriteLine(content);
                Console.WriteLine("Content append Successfully");
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }
        public static void DeleteFil(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("File does not Exits");
                }
                File.Delete(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter the Operation Like: create, read, apppend,delete");
                string operation = Console.ReadLine().ToLower();
                if (operation == "create")
                {
                    Console.WriteLine("Enter the file name");
                    string fileName = Console.ReadLine();
                    Console.WriteLine("Enter the file Content");
                    string content = Console.ReadLine();
                    CreateFile(fileName, content);
                }
                else if (operation == "read")
                {
                    Console.WriteLine("Enter the file name to read");
                    string fileName = Console.ReadLine();
                    ReadFile(fileName);
                }
                else if (operation == "append")
                {
                    Console.WriteLine("Enter the file name to append to:");
                    string fileName = Console.ReadLine();
                    Console.WriteLine("Enter the content to append:");
                    string content = Console.ReadLine();
                }
                else if (operation == "delete")
                {
                    Console.WriteLine("Enter the file name to delete");
                    string fileName = Console.ReadLine();
                    DeleteFil(fileName);
                }
                else
                {
                    Console.WriteLine("Invalid opertion. try again");
                }
            }





        }

    }
}