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
        /// Добавление элемента в конец массива
        /// </summary>
        /// <param name="item">Новые элемент</param>
        public void Add(T item)
        {
            increment();
            array[size - 1] = item;
        }

        /// <summary>
        /// Добавление элемента в определенное место массива
        /// </summary>
        /// <param name="item">Новый элемент</param>
        /// <param name="index">Индекс</param>
        public void Add(T item, int index)
        {
            if (index < 0 || index > size) return;

            T[] newArray = new T[size + 1];

            Array.Copy(array, 0, newArray, 0, index);
            newArray[index] = item;
            Array.Copy(array, index, newArray, index + 1, size - index);

            array = newArray;
        }

        /// <summary>
        /// Удаление элемента по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Remove(int index)
        {
            if (index < 0 || index > size) return default(T);

            var removedItem = array[index];
            T[] newArray = new T[size - 1];

            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, size - 1 - index);

            array = newArray;
            return removedItem;
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
            }
            catch { }
            return result;
        }

        private void increment()
        {
            T[] newArray = new T[size + 1];
            Array.Copy(array, newArray, size);
            array = newArray;
        }
    }
}