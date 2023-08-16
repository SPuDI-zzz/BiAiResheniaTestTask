using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResultRazorWeb.Services.IService;

namespace ResultRazorWeb.Pages
{
    public class SortNumbersModel : PageModel
    {
        [BindProperty]
        public string InputArray { get; set; }

        public string SortedArrayText { get; private set; }
        public async Task<IActionResult> OnPostAsync([FromServices] ISortNumbersService sortNumbersService)
        {
            if (!string.IsNullOrWhiteSpace(InputArray))
            {
                var numbers = InputArray.Split(',')
                    .Where((val) => int.TryParse(val, out _))
                    .Select(int.Parse)
                    .ToArray();

                var response = await sortNumbersService.SortNumbersAsync(numbers);

                SortedArrayText = $"Отсортированный список: {response.Result}";
            }
            else
            {
                SortedArrayText = "Отсортированный список:";
            }
            return Page();
        }
    }
}
