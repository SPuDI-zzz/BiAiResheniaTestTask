using Microsoft.AspNetCore.Mvc;
using ResultWeb.Models;
using ResultWeb.Services.IService;

namespace ResultWeb.Controllers
{
    public class SumOfEverySecondOddNumberController : Controller
    {
        private readonly ISumOfEverySecondOddNumberService _sumOfEverySecondOddNumberService;

        public SumOfEverySecondOddNumberController(ISumOfEverySecondOddNumberService sumOfEverySecondOddNumberService)
        {
            _sumOfEverySecondOddNumberService = sumOfEverySecondOddNumberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SumOfEverySecondOddNumberDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _sumOfEverySecondOddNumberService.SumOfEverySecondOddNumberAsync(model.Array);

                if (response != null && response.IsSuccess)
                {
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
