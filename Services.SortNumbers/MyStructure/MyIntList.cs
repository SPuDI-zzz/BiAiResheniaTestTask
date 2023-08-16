using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SortNumbers.MyStructure
{
    public class MyIntList : IMyIntList
    {
        private const int DEFAULT_SIZE = 10;
        private const string INDEX_OUT_OF_RANGE_MESSAGE = "Going outside the list";
        private const string ARGUMENT_OUT_OF_RANGE_MESSAGE = "The capacity must be greater than zero";
        private int[] _items;

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public int this[int index]
        {
            get
            {
                return index < Count && index >= 0
                    ? _items[index]
                    : throw new IndexOutOfRangeException(INDEX_OUT_OF_RANGE_MESSAGE);
            }
            set
            {
                _items[index] = index < Count && index >= 0
                    ? value
                    : throw new IndexOutOfRangeException(INDEX_OUT_OF_RANGE_MESSAGE);
            }
        }

        public MyIntList()
        {
            Capacity = DEFAULT_SIZE;
            _items = new int[Capacity];
        }

        public MyIntList(int Capacity) : this() 
        {
            if (Capacity < 0)
            {
                throw new ArgumentOutOfRangeException(ARGUMENT_OUT_OF_RANGE_MESSAGE);
            }
            this.Capacity = Capacity;
        }

        public void Sort()
        {
            QuickSort(_items, 0, Count - 1);
        }

        public int[] ToArray1()
        {
            return _items;
        }

        public int Add(int value)
        {
            Insert(Count, value);

            return Count - 1;
        }

        public void Clear()
        {
            Capacity = DEFAULT_SIZE;
            _items = new int[Capacity];
            Count = 0;
        }

        public bool Contains(int value)
        {
            if (IsEmpty())
            {
                return false;
            }

            return IndexOf(value) != -1;
        }

        public int IndexOf(int value)
        {
            if (IsEmpty())
            {
                return -1;
            }

            for (int i = 0; i < Count; i++)
            {
                if (_items[i] == (value))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int value)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException(INDEX_OUT_OF_RANGE_MESSAGE);
            }

            if (IsFull())
            {
                Capacity *= 2;
                Array.Resize(ref _items, Capacity);
            }

            if (index < Count)
            {
                Array.Copy(_items, index, _items, index + 1, length: Count - index);
            }

            _items[index] = value;
            Count++;
        }

        public void Remove(int value)
        {
            int index = IndexOf(value);

            if (index >= 0)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (IsEmpty())
            {
                return;
            }

            Count--;

            if (index < Count)
            {
                Array.Copy(_items, index + 1, _items, index, Count - index);
            }

            _items[Count] = default;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private bool IsFull() => Capacity == Count;

        private bool IsEmpty() => Capacity == 0;

        private void QuickSort(int[] inputArray, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return;
            }

            int pivotIndex = GetPivotIndex(inputArray, minIndex, maxIndex);

            QuickSort(inputArray, minIndex, pivotIndex - 1);
            QuickSort(inputArray, pivotIndex + 1, maxIndex);
        }

        private int GetPivotIndex(int[] array, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            for (int index = minIndex; index <= maxIndex; index++)
            {
                if (array[index] < array[maxIndex])
                {
                    pivot++;
                    Swap(array, pivot, index);
                }
            }

            pivot++;
            Swap(array, pivot, maxIndex);

            return pivot;
        }

        private void Swap(int[] array, int leftItem, int rightItem)
        {
            (array[rightItem], array[leftItem]) = (array[leftItem], array[rightItem]);
        }
    }
}
