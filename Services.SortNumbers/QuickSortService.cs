using Services.SortNumbers.MyStructure;

namespace Services.SortNumbers
{
    public class QuickSortService : ISortNumbersService
    {
        public IEnumerable<int> Sort(IMyIntList array)
        {
            array.Sort();
            return array;
        }
    }
}
