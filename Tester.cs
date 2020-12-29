using System;
using System.Diagnostics;
using System.IO;

namespace TestApp
{
    class Tester
    {
        ITask task;
        string path;

        public Tester(ITask task, string path = null)
        {
            this.task = task;
            this.path = path;
        }

        public void RunTest()
        {
            int nr = 0;
            Console.WriteLine($"Test {path} {task.Title}");

            if (path != null)
            {
                while (true)
                {
                    var exePath = AppDomain.CurrentDomain.BaseDirectory;

                    string inFile = Path.Combine(exePath, "Tests", $"{path}test.{nr}.in");
                    string outFile = Path.Combine(exePath, "Tests", $"{path}test.{nr}.out");

                    if (!File.Exists(inFile) || !File.Exists(outFile))
                        break;
                    Console.WriteLine($"Test #{nr} - " + doTest(inFile, outFile));
                    nr++;
                }
            }
            else
            {
                Console.WriteLine($"Elapsed time: {doTest()}");
            }
        }

        private string doTest(string inFile, string outFile)
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

        private string doTest()
        {
            var watch = new Stopwatch();
            try
            {
                watch.Start();
                string actual = task.Run(null);
                watch.Stop();


                return $"{watch.ElapsedMilliseconds} ms";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Failed";
            }
        }
    }
}

