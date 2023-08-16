using ResultRazorWeb.Models;

namespace ResultRazorWeb.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
