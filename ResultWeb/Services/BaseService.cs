using Newtonsoft.Json;
using ResultWeb.Models;
using ResultWeb.Services.IService;
using System.Text;
using static ResultWeb.Utility.SD;

namespace ResultWeb.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            HttpClient client = _httpClientFactory.CreateClient("WebApi");
            HttpRequestMessage message = new();

            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(requestDto.Url);

            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? apiResponse = null;

            switch (requestDto.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponse = await client.SendAsync(message);

            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                return apiResponseDto;
            }

            return new() { IsSuccess = false };
        }
    }
}
