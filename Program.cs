using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            string contPrompt = "Y";

            while (contPrompt == "Y")
            {
                string fileName1, fileName2;

                Console.WriteLine("DOCUMENT MERGER\n");

                Console.WriteLine("What is the name of the first file (do not include extension)?\n");
                fileName1 = Console.ReadLine();

                while (File.Exists(fileName1 + ".txt") == false)
                {
                    Console.WriteLine("\nSorry! This file does not exist. Please re-enter the name of the first file:\n");
                    fileName1 = Console.ReadLine();
                }

                Console.WriteLine("\nWhat is the name of the second file (do not include extension)?\n");
                fileName2 = Console.ReadLine();

                while (File.Exists(fileName2 + ".txt") == false)
                {
                    Console.WriteLine("\nSorry! This file does not exist. Please re-enter the name of the second file:\n");
                    fileName2 = Console.ReadLine();
                }

                string mergedFile = fileName1 + fileName2 + ".txt";

                string fileCharacters1 = "";
                string fileCharacters2 = "";
                string line = "";
                string line2 = "";
                int count;

                StreamReader sr = new StreamReader(fileName1 + ".txt");
                StreamReader sr2 = new StreamReader(fileName2 + ".txt");
                StreamWriter sw = new StreamWriter(mergedFile);

                try
                {
                    line = sr.ReadLine();
                    fileCharacters1 = line;

                    while (line != null)
                    {
                        line = sr.ReadLine();
                        fileCharacters1 += line;
                        fileCharacters1 = fileCharacters1 + line;
                    }

                    line2 = sr2.ReadLine();
                    fileCharacters2 = line2;

                    while (line2 != null)
                    {
                        line2 = sr2.ReadLine();
                        fileCharacters2 += line2;
                        fileCharacters2 = fileCharacters2 + line2;
                    }

                    string mergedContent = fileCharacters1 + fileCharacters2;

                    sw.Write(mergedContent);

                    count = fileCharacters1.Length + fileCharacters2.Length;

                    Console.WriteLine("\n" + mergedFile + " was successfully saved. The document contains " + count + " characters.");
                }

                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

                finally
                {
                    sr.Close();
                    sr2.Close();
                    sw.Close();
                }

                Console.WriteLine("\nWould you like to merge two more files? Input Y (capital) for yes or hit enter to close the program.\n");
                contPrompt = Console.ReadLine();
            }
        }
    }
}