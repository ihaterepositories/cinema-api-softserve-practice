using Cinema.Data.Responses.Enums;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.Data.Responses;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Description { get; set; } = null!;
    public StatusCode StatusCode { get; set; }
    public int ResultsCount { get; set; }
    public T? Data { get; set; }
}