using ResultRazorWeb.Models;
using ResultRazorWeb.Services.IService;
using ResultRazorWeb.Utility;

namespace ResultRazorWeb.Services
{
    public class PalindromeService : IPalindromeService
    {
        private readonly IBaseService _baseService;

        public PalindromeService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> IsPalindromeAsync(string word)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = word,
                Url = SD.DataAccessWebApi + "/api/Palindrome"
            });
        }
    }
}
