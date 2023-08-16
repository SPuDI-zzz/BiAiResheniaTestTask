using ResultRazorWeb.Models;

namespace ResultRazorWeb.Services.IService
{
    public interface IPalindromeService
    {
        Task<ResponseDto> IsPalindromeAsync(string word);
    }
}
