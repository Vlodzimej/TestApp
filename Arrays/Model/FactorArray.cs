using System;

namespace TestApp.Arrays
{
    public class FactorArray<T> : VectorArray<T>
    {
        private int size = 0;

        public FactorArray() : base() { }

        /// <summary>
        /// Увеличение массива на значение delta
        /// </summary>  
        private void increment()
        {
            try
            {
                T[] newArray = new T[size * 2 + 1];
                Array.Copy(array, newArray, size);
                array = newArray;
            }
            catch { }
        }
    }
}