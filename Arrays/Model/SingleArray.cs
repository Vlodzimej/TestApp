using System;

namespace TestApp.Arrays
{
    public class SingleArray<T> : IDynamicArray<T>
    {
        private T[] array;
        private int size { get => this.array.Length; }

        public SingleArray()
        {
            array = new T[0];
        }

        /// <summary>
        /// Размер массива
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// Получение элемента массива по индексу
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns></returns>
        public T Get(int index)
        {
            T result = default(T);
            try
            {
                result = array[index];
                return result;
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
        public void Add(T item)
        {
            try
            {
                increment();
                array[size - 1] = item;
            }
            catch { }
        }

        /// <summary>
        /// Добавление элемента в определенное место массива
        /// </summary>
        /// <param name="item">Новый элемент</param>
        /// <param name="index">Индекс</param>
        public void Add(T item, int index)
        {
            if (index < 0) return;
            try
            {
                if (index > size)
                {
                    Add(item);
                }
                else
                {
                    T[] newArray = new T[size + 1];

                    Array.Copy(array, 0, newArray, 0, index);
                    newArray[index] = item;
                    Array.Copy(array, index, newArray, index + 1, size - index);

                    array = newArray;
                }
            }
            catch { }
        }

        /// <summary>
        /// Удаление элемента по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Remove(int index)
        {
            if (index < 0 || index > size) return default(T);

            try
            {
                var removedItem = array[index];
                T[] newArray = new T[size - 1];

                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index + 1, newArray, index, size - 1 - index);

                array = newArray;
                return removedItem;
            }
            catch
            {
                return default(T);
            }
        }

        private void increment()
        {
            try
            {
                T[] newArray = new T[size + 1];
                Array.Copy(array, newArray, size);
                array = newArray;
            }
            catch { }
        }
    }
}