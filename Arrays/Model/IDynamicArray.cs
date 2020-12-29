namespace TestApp.Arrays
{
    public interface IDynamicArray<T>
    {
        int Size();
        bool isEmpty();
        void Add(T item);
        void Add(T item, int index);
        T Remove(int index);
        T Get(int index);
    }
}