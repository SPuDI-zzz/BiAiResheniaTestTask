using DataAccessWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Services.SortNumbers;
using Services.SortNumbers.MyStructure;
using System.Diagnostics.CodeAnalysis;

namespace DataAccessWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortNumbersController : ControllerBase
    {
        private readonly ISortNumbersService _sortNumbersService;

        public SortNumbersController(ISortNumbersService sortNumbersService)
        {
            _sortNumbersService = sortNumbersService;
        }

        [HttpPost("")]
        public ResponseDto SortNumbers([FromBody] [NotNull] int[] array)
        {
            var list = new MyIntList();
            foreach (var item in array)
            {
                list.Add(item);
            }

            var response = _sortNumbersService.Sort(list);

            return new ResponseDto() { Result = response };
        }
    }
}
