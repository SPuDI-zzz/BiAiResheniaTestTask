using ResultWeb.Models;

namespace ResultWeb.Services.IService
{
    public interface IPalindromeService
    {
        Task<ResponseDto?> IsPalindrome(string word);
    }
}
