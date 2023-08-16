using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResultRazorWeb.Services.IService;

namespace ResultRazorWeb.Pages
{
    public class PalindromeModel : PageModel
    {
        [BindProperty]
        public string InputString { get; set; }

        public string ResultText { get; private set; }

        public async Task<IActionResult> OnPostAsync([FromServices] IPalindromeService palindromeService)
        {
            if (!string.IsNullOrWhiteSpace(InputString))
            {
                var response = await palindromeService.IsPalindromeAsync(InputString);

                var isPalindrome = (bool)response.Result!;

                if (isPalindrome)
                {
                    ResultText = "��, ��� ���������!";
                }
                else
                {
                    ResultText = "���, ��� �� ���������.";
                }
            }
            return Page();
        }
    }
}
