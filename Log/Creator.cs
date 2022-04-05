using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Log
{
    class Creator
    {
        string directoryPath = "C:\\Main\\1";
        public List<int> intFromTextFile;
        char forTxt = ' ';
        char forCsv = ',';
        char usingChar;
        

        public Creator(List<int> intFrom)
        {
            this.intFromTextFile = intFrom;
        }

        public IEnumerable<int> ReadFromTextFile()
        {
            try
            {
                var directoryPathList = GetPathFromDirectory(directoryPath);
                foreach(var a in directoryPathList)
                {
                    StreamReader sr = new StreamReader(a);
                    var line = sr.ReadToEnd();
                    var splitedList = a.Contains(".txt") ? line.Split(' ') : line.Split(',');
                    
                    foreach (var x in splitedList)
                    {
                        var toInt = Int32.Parse(x);
                        intFromTextFile.Add(toInt);
                    }
                    sr.Close();
                    }    
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return intFromTextFile;
        }

        public int SumOfNumbers(List<int> a)
        {
            return a.Sum();
        }

        public int MuliplyOfNumbers(List<int> a)
        {
           var temp = a.Aggregate(1, (x, y) => x * y);
           return temp;
        }

        public int  DivideFirstAndSecond(List<int> a)
        {
            var temp = 1;
            try
            {
                foreach (var x in a)
                {
                    temp = x / temp;
                }
                return temp;
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }

        public List<string> GetPathFromDirectory(string directiryPathTmp)
        {
            List<string> res = Directory.GetFiles(directiryPathTmp).ToList();
            return res;
        }

        public void ShowAllElements(List<int> f)
        {
            foreach (var x in f)
            {
                Console.WriteLine(x);
            }
        }

        public void MathOperations(Creator test , List<int> f)
        {
            var oddCounter = f.Where((num, i) => num % 2 != 0).Count();
            var evenCounter = f.Where((num, i) => num % 2 == 0).Count();
            var tpm = oddCounter > evenCounter ?  1 : (oddCounter == evenCounter ? 3 : 2);

            try
            {
                CreateThreeFilesForWriting();
                switch (tpm)
                {
                    case 1: WriteToFirst(f);
                        break;
                    case 2: WriteToSecond(f);
                        break;
                    case 3: WriteToTheerd(f);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void CreateFilesForReading(string fileType)
        {
            Directory.CreateDirectory(directoryPath);

            usingChar = fileType.Contains("txt") ? forTxt : forCsv;
           
            for(int i = 0; i < 3; i++)
            {
                string temp = $"C:\\Main\\1\\{i}.{fileType}";
                FileStream fstream = new FileStream(temp, FileMode.OpenOrCreate);

                fstream.Close();
                using (StreamWriter writer = new StreamWriter(temp, true))
                {
                    writer.WriteLine($"2{usingChar}2{usingChar}3{usingChar}3");
                }
            }
        }

        public void DeleteFilesFromPc()
        {
            Directory.Delete(directoryPath , Directory.Exists(directoryPath)) ;
        }

        public void CreateThreeFilesForWriting()
        {
            for(int i = 1; i < 4; i++)
            {
                string fileToWritePath = $"C:\\Main\\output_23-02-2022{i}.txt";
                FileStream fstream = new FileStream(fileToWritePath, FileMode.OpenOrCreate);
                fstream.Close();
            }
        }
        
         public void WriteToFirst(List<int> x)
        {
            var f = x.Where((num , i) => num % 2 != 0).Aggregate(1, (a, b) => a * b);
            using (StreamWriter writer = new StreamWriter("C:\\Main\\output_23-02-20221.txt", true))
            {
                writer.WriteLine(f);
            }
        }

        public void WriteToSecond(List<int> x)
        {
            var f = x.Where((num, i) => num % 2 == 0).Sum();
            using (StreamWriter writer = new StreamWriter("C:\\Main\\output_23-02-20222.txt", true))
            {
                writer.WriteLine(f);
            }
        }

        public void WriteToTheerd(List<int> x)
        {
            x.Sort();
            using (StreamWriter writer = new StreamWriter("C:\\Main\\output_23-02-20223.txt", true))
            {
                foreach(var a in x)
                {
                    writer.WriteLine(a + " ");
                }
            }
        }        
    }
}

