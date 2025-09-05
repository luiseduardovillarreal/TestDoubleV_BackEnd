using System.Net;

namespace Movement.Application.Commons;

#pragma warning disable CS8618

public class CommonResponse<T>
{
    public CommonResponse()
    {
    }

    public CommonResponse(T data, HttpStatusCode responseHttp,
        string message = "", string messageCustom = "", bool state = false)
    {
        Succeeded = state;
        StatusCode = responseHttp;
        Message = message;
        MessageCustom = messageCustom;
        Data = data;
    }

    public bool Succeeded { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public string MessageCustom { get; set; }
    public T Data { get; set; }
}