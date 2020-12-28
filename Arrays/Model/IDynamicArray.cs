namespace TestApp.Arrays
{
    public interface IDynamicArray<T>
    {
        void Add(T item);
        T Get(int index);
    }
}