using ResultRazorWeb.Models;

namespace ResultRazorWeb.Services.IService
{
    public interface ISumOfEverySecondOddNumberService
    {
        Task<ResponseDto> SumOfEverySecondOddNumberAsync(int[] array);
    }
}
