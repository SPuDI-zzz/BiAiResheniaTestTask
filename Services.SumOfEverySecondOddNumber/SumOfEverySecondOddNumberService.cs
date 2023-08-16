namespace Services.SumOfEverySecondOddNumber
{
    public class SumOfEverySecondOddNumberService : ISumOfEverySecondOddNumberService
    {
        public long SumOfEverySecondOddNumber(int[] numbers)
        {
            var result = Math.Abs(numbers
                .Where(num => num % 2 != 0)
                .Where((_, index) => index % 2 != 0)
                .Sum());

            return result;
        }
    }
}
