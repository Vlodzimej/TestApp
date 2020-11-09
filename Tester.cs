using System;
using System.Diagnostics;
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
            Console.WriteLine($"Test {path} {task.Title}");

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

        public string RunTest(string inFile, string outFile)
        {
            var watch = new Stopwatch();
            try
            {
                string[] data = File.ReadAllLines(inFile);
                string expect = File.ReadAllText(outFile).Trim();

                watch.Start();

                string actual = task.Run(data);

                watch.Stop();


                return $"{(actual == expect)} {watch.ElapsedMilliseconds} ms";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Failed";
            }
        }
    }
}

