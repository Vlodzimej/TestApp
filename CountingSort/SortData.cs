using System;
using System.IO;

namespace TestApp.CountingSort
{
    public class SortData
    {
        void CreateFile()
        {
            string path = @"MyTest.txt";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Create the file.
            using (FileStream fs = File.Create(path))
            {
                for (ushort i = 0; i < 65535; i++)
                {
                    AddNumber(fs, i);
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
