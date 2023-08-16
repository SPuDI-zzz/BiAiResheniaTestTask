using ResultWeb.Models;

namespace ResultWeb.Services.IService
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
