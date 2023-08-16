﻿using ResultRazorWeb.Models;
using ResultRazorWeb.Services.IService;
using ResultRazorWeb.Utility;

namespace ResultRazorWeb.Services
{
    public class SumOfEverySecondOddNumberService : ISumOfEverySecondOddNumberService
    {
        private readonly IBaseService _baseService;

        public SumOfEverySecondOddNumberService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> SumOfEverySecondOddNumberAsync(int[] array)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = array,
                Url = SD.DataAccessWebApi + "/api/SumOfEverySecondOddNumber"
            });
        }
    }
}
