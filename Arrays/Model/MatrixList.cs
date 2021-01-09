using System.Collections.Generic;

namespace TestApp.Arrays
{
    public class MatrixList<T> : IDynamicArray<T>
    {
        private int size = 0;
        private int vector = 100;
        List<List<T>> matrix;

        public MatrixList()
        {
            matrix = new List<List<T>>();
        }

        /// <summary>
        /// Размер массива
        /// </summary>
        /// <returns></returns>
        public virtual int Size()
        {
            return size;
        }

        /// <summary>
        /// Проверка массива на заполненность
        /// </summary>
        /// <returns>Флаг наличия элементов у массива</returns>
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
            try
            {
                return matrix[index / vector][index % vector];
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
                Add(item, size);
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
                if (size == matrix.Count * vector)
                {
                    matrix.Add(new List<T>());
                }

                if (index == size)
                {
                    matrix[size / vector].Add(item);
                }
                else
                {
                    int line = index / vector;
                    for (int i = matrix.Count - 1; i > line; --i)
                    {
                        matrix[i].Insert(0, matrix[i - 1][matrix[i - 1].Count - 1]);
                        matrix[i - 1].RemoveAt(matrix[i - 1].Count - 1);
                    }
                    matrix[line].Insert(index % vector, item);
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
        public T Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                return default(T);
            }

            try
            {
                int lineIndex = index / vector;
                T removedItem = matrix[lineIndex][index % vector];
                matrix[lineIndex].RemoveAt(index % vector);

                for (int i = lineIndex + 1; i < matrix.Count; ++i)
                {
                    matrix[i - 1].Add(matrix[i][0]);
                    matrix[i].RemoveAt(0);
                }

                if (matrix[matrix.Count - 1].Count == 0)
                {
                    matrix.RemoveAt(matrix.Count - 1);
                }
                size--;
                return removedItem;
            }
            catch
            {
                return default(T);
            }
        }
    }
}