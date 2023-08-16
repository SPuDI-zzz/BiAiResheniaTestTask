using ResultRazorWeb.Models;
using ResultRazorWeb.Services.IService;
using ResultRazorWeb.Utility;

namespace ResultRazorWeb.Services
{
    public class SortNumbersService : ISortNumbersService
    {
        private readonly IBaseService _baseService;

        public SortNumbersService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> SortNumbersAsync(int[] array)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = array,
                Url = SD.DataAccessWebApi + "/api/SortNumbers"
            });
        }
    }
}
