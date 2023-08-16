using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ResultRazorWeb.Models;
using ResultRazorWeb.Services.IService;

namespace ResultRazorWeb.Pages
{
    public class SumOfEverySecondOddNumberModel : PageModel
    {
        [BindProperty]
        public string NumbersInput { get; set; }

        public string ResultText { get; private set; }
        public async Task<IActionResult> OnPostAsync([FromServices] ISumOfEverySecondOddNumberService sumOfEverySecondOddNumberService)
        {
            if (!string.IsNullOrWhiteSpace(NumbersInput))
            {
                var numbers = NumbersInput.Split(',')
                    .Where((val) => int.TryParse(val, out _))
                    .Select(int.Parse)
                    .ToArray();

                var response = await sumOfEverySecondOddNumberService.SumOfEverySecondOddNumberAsync(numbers);

                ResultText = $"Сумма элементов: {response.Result}";
            }
            else
            {
                ResultText = "Сумма элементов: 0";
            }
            return Page();
        }
    }
}
