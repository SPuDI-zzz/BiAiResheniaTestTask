using ResultRazorWeb.Models;

namespace ResultRazorWeb.Services.IService
{
    public interface ISortNumbersService
    {
        Task<ResponseDto> SortNumbersAsync (int[] array);
    }
}
