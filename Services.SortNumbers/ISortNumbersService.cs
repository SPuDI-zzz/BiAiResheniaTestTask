using Services.SortNumbers.MyStructure;

namespace Services.SortNumbers
{
    public interface ISortNumbersService
    {
        IEnumerable<int> Sort(IMyIntList array);
    }
}
