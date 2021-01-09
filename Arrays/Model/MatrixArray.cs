using System;

namespace TestApp.Arrays
{
    public class MatrixArray<T> : VectorArray<T>
    {
        private int size = 0;
        private VectorArray<VectorArray<T>> matrix;

        public MatrixArray()
        {
            matrix = new VectorArray<VectorArray<T>>();
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
                return matrix.Get(index / vector).Get(index % vector);
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
                Add(item, size);
            }
            catch { }
        }

        /// <summary>
        /// /// Добавление элемента в определенное место массива
        /// </summary>
        /// <param name="item">Новый элемент</param>
        /// <param name="index">Индекс</param>
        public override void Add(T item, int index)
        {
            if (index < 0) return;

            try
            {
                if (size == matrix.Size() * vector)
                {
                    matrix.Add(new VectorArray<T>());
                }

                if (index == size)
                {
                    matrix.Get(size / vector).Add(item);
                }
                else
                {
                    int line = index / vector;
                    for (int i = matrix.Size() - 1; i > line; --i)
                    {
                        matrix.Get(i).Add(matrix.Get(i - 1).Get(matrix.Get(i - 1).Size() - 1), 0);
                        matrix.Get(i - 1).Remove(matrix.Get(i - 1).Size() - 1);
                    }
                    matrix.Get(line).Add(item, index % vector);
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
                int lineIndex = index / vector;
                T removedItem = matrix.Get(lineIndex).Remove(index % vector);

                for (int i = lineIndex + 1; i < matrix.Size(); ++i)
                {
                    matrix.Get(i - 1).Add(matrix.Get(i).Get(0));
                    matrix.Get(i).Remove(0);
                }

                if (matrix.Get(matrix.Size() - 1).Size() == 0)
                {
                    matrix.Remove(matrix.Size() - 1);
                }
                return removedItem;
            }
            catch
            {
                return default(T);
            }
        }
    }
}