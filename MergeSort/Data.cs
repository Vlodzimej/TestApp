using System;
using System.IO;

namespace TestApp.Merge
{
    public static class Data
    {
        public static void CreateFile()
        {
            string path = @"MergeSortData.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Create the file.
            using (FileStream fs = File.Create(path))
            {
                for (long i = 0; i < 100; i++)
                {
                    var rnd = new Random();
                    Console.WriteLine($"{i}");
                    //AddNumber(fs, (ushort)rnd.Next(65535));
                    AddNumber(fs, 65534); 
                }
            }
        }

        private static void AddNumber(FileStream fs, ushort value)
        {
            byte[] data = BitConverter.GetBytes(value);
            fs.Write(data, 0, data.Length);
        }
    }
}
