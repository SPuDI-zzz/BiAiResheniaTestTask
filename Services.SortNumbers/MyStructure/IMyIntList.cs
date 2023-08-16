namespace Services.SortNumbers.MyStructure
{
    public interface IMyIntList : IEnumerable<int>
    {
        int Count { get; }
        int Capacity { get; }
        int this[int index] { get; }
        int Add(int value);
        void Clear();
        bool Contains(int value);
        int IndexOf(int value);
        void Insert(int index, int value);
        void Remove(int value);
        void RemoveAt(int index);
        void Sort();
    }
}
