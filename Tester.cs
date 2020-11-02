using System;
using System.IO;

namespace TestApp
{
    class Tester
    {
        ITask task;
        string path;

        public Tester(ITask task, string path)
        {
            this.task = task;
            this.path = path;
        }

        public void RunTest()
        {
            int nr = 0;
            Console.WriteLine($"Test {path}");

            while (true)
            {
                var exePath = AppDomain.CurrentDomain.BaseDirectory;

                string inFile = Path.Combine(exePath, "Tests", $"{path}test.{nr}.in");
                string outFile = Path.Combine(exePath, "Tests", $"{path}test.{nr}.out");

                if (!File.Exists(inFile) || !File.Exists(outFile))
                    break;
                Console.WriteLine($"Test #{nr} - " + RunTest(inFile, outFile));
                nr++;
            }
        }

        public bool RunTest(string inFile, string outFile)
        {
            try
            {
                string[] data = File.ReadAllLines(inFile);
                string expect = File.ReadAllText(outFile).Trim();
                string actual = task.Run(data);
                return actual == expect;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}

