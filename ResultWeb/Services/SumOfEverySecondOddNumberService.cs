using ResultWeb.Models;
using ResultWeb.Services.IService;
using ResultWeb.Utility;

namespace ResultWeb.Services
{
    public class SumOfEverySecondOddNumberService : ISumOfEverySecondOddNumberService
    {
        private readonly IBaseService _baseService;

        public SumOfEverySecondOddNumberService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> SumOfEverySecondOddNumberAsync(int[] arrayDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = arrayDto,
                Url = SD.DataAccessWebApi + "/api/SumOfEverySecondOddNumber"
            });
        }
    }
}
