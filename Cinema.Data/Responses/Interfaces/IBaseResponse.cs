namespace Cinema.Data.Responses.Interfaces;

public interface IBaseResponse<T>
{
    T? Data { get; set; }
}