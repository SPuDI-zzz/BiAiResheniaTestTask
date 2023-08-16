using DataAccessWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Palindrome;
using Services.SumOfEverySecondOddNumber;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalindromeController : ControllerBase
    {
        private readonly IPalindromeService _palindromeService;

        public PalindromeController(IPalindromeService palindromeService)
        {
            _palindromeService = palindromeService;
        }

        [HttpPost("")]
        public ResponseDto IsPalindrome([FromBody] [NotNull] string word)
        {
            var response = _palindromeService.IsPalindrome(word);

            return new ResponseDto() { Result = response };
        }
    }
}
