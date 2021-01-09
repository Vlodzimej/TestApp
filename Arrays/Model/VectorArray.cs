using System;

namespace TestApp.Arrays
{
    public class VectorArray<T> : SingleArray<T>
    {
        private int size = 0;
        protected int vector = 100;

        public VectorArray()
        {
            array = new T[vector];
        }

        /// <summary>
        /// Размер массива
        /// </summary>
        /// <returns></returns>
        public override int Size()
        {
            return size;
        }

        /// <summary>
        /// Получение элемента массива по индексу
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns></returns>
        public override T Get(int index)
        {
            try
            {
                if (index < 0 || index >= size)
                {
                    return default(T);
                }
                return array[index];
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Добавление элемента в конец массива
        /// </summary>
        /// <param name="item">Новые элемент</param>
        public override void Add(T item)
        {
            try
            {
                if (size == array.Length)
                {
                    increment();
                }
                array[size] = item;
                size++;
            }
            catch { }
        }

        /// <summary>
        /// Добавление элемента в определенное место массива
        /// </summary>
        /// <param name="item">Новый элемент</param>
        /// <param name="index">Индекс</param>
        public override void Add(T item, int index)
        {
            if (index < 0) return;

            try
            {
                if (size == array.Length)
                {
                    increment();
                }

                if (index == size - 1)
                {
                    array[index] = item;
                }
                else
                {
                    T[] newArray = new T[array.Length];

                    Array.Copy(array, 0, newArray, 0, index);
                    newArray[index] = item;
                    Array.Copy(array, index, newArray, index + 1, size - index);

                    array = newArray;
                }
                size++;
            }
            catch { }
        }

        /// <summary>
        /// Удаление элемента по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override T Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                return default(T);
            }

            try
            {
                var removedItem = array[index];
                if (index != size - 1)
                {
                    T[] newArray = new T[array.Length];

                    Array.Copy(array, 0, newArray, 0, index);
                    Array.Copy(array, index + 1, newArray, index, size - 1 - index);

                    array = newArray;
                }

                size--;

                return removedItem;
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Увеличение массива на значение delta
        /// </summary>  
        private void increment()
        {
            try
            {
                T[] newArray = new T[size + vector];
                Array.Copy(array, newArray, size);
                array = newArray;
            }
            catch { }
        }
    }
}