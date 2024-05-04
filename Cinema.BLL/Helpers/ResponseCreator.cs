using Cinema.Data.Responses;
using Cinema.Data.Responses.Enums;

namespace Cinema.BLL.Helpers;

public class ResponseCreator
{
    public BaseResponse<T> CreateBase<T>(string description, StatusCode statusCode, T data = default, int resultsCount = 0)
    {
        return new BaseResponse<T>()
        {
            ResultsCount = resultsCount,
            Data = data!,
            Description = description,
            StatusCode = statusCode
        };
    }
    
    public BaseResponse<T> CreateBaseOk<T>(T data, int resultsCount)
    {
        return new BaseResponse<T>()
        {
            ResultsCount = resultsCount,
            Data = data,
            Description = "Operation completed successfully.",
            StatusCode = StatusCode.Ok
        };
    }
    
    public BaseResponse<T> CreateBaseBadRequest<T>(string description)
    {
        return new BaseResponse<T>()
        {
            ResultsCount = 0,
            Data = default!,
            Description = description,
            StatusCode = StatusCode.BadRequest
        };
    }
    
    public BaseResponse<T> CreateBaseNotFound<T>(string description)
    {
        return new BaseResponse<T>()
        {
            ResultsCount = 0,
            Data = default!,
            Description = description,
            StatusCode = StatusCode.NotFound
        };
    }
    
    public BaseResponse<T> CreateBaseServerError<T>(string exceptionMessage)
    {
        return new BaseResponse<T>()
        {
            ResultsCount = 0,
            Data = default!,
            Description = "Server error, catch exception: " + exceptionMessage,
            StatusCode = StatusCode.InternalServerError
        };
    }
}