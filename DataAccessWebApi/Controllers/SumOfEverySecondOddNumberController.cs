using DataAccessWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Services.SumOfEverySecondOddNumber;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumOfEverySecondOddNumberController : ControllerBase
    {
        private readonly ISumOfEverySecondOddNumberService _sumOfEverySecondOddNumberService;

        public SumOfEverySecondOddNumberController(ISumOfEverySecondOddNumberService sumOfEverySecondOddNumberService)
        {
            _sumOfEverySecondOddNumberService = sumOfEverySecondOddNumberService;
        }

        [HttpPost("")]
        public ResponseDto SumOfEverySecondOddNumber([FromBody] [NotNull] int[] numbersRequest)
        {
            var response = _sumOfEverySecondOddNumberService.SumOfEverySecondOddNumber(numbersRequest);

            return new ResponseDto() { Result = response };
        }
    }
}
