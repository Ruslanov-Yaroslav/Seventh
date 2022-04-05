using System;
using System.Collections.Generic;
using NLog;

namespace Log
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("Debug is starting");

            string fileToWritePath = $"C:\\Main\\output_23-02-2022.txt";
            List<int> f = new List<int>();
            Creator test = new Creator(f);

            test.CreateFilesForReading("txt");
            logger.Info("Creating the  files in path : 'C:\\Main\\1'");
            Console.WriteLine("Hello!!! I glad to see you");
            test.ReadFromTextFile();
            logger.Info("Read all text from files and separate them");
            test.ShowAllElements(f);
            logger.Info("Write all elements of files to console");
            Console.WriteLine("Its was digitst from files)");
            Console.WriteLine($"Its Summary of this digits: {test.SumOfNumbers(f)}");
            Console.WriteLine($"Its Multiply of this digits: {test.MuliplyOfNumbers(f)}");
            Console.WriteLine($"Its Divide of this digits: {test.DivideFirstAndSecond(f)}");
            test.MathOperations(test, f);
            logger.Info("Create files for output and write all operations inside");
            Console.WriteLine($"THX))) File in Path : {fileToWritePath}  was successfully written!))))");

            test.DeleteFilesFromPc();
            logger.Info("Delete files for reading from PC");
        }
    }
}
