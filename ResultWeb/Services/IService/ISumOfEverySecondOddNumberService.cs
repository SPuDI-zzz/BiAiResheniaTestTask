using ResultWeb.Models;

namespace ResultWeb.Services.IService
{
    public interface ISumOfEverySecondOddNumberService
    {
        Task<ResponseDto> SumOfEverySecondOddNumberAsync(int[] array);
    }
}
