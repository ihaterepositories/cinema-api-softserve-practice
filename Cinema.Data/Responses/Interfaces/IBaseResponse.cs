using Cinema.Data.Responses.Enums;

namespace Cinema.Data.Responses.Interfaces;

public interface IBaseResponse<T>
{
    public string Description { get; set; }
    public StatusCode StatusCode { get; set; }
    public int ResultsCount { get; set; }
    public T Data { get; set; }
}