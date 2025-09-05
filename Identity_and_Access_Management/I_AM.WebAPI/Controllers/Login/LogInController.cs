using I_AM.Application.Commons;
using I_AM.Application.LogIn.DTOs;
using I_AM.WebAPI.Commons;
using MediatR;

namespace I_AM.WebAPI.Controllers.Login;

public static class LogInController
{
    public static void LogInEndPoint(this WebApplication app)
    {
        app.MapPost(Constants.Controllers.LogInEndPoint.LOGIN_AUTH,
            async (IMediator mediator, LogInRequestDTO request) =>
            {
                return await mediator.Send(request) 
                    ?? new CommonResponse<LogInResponseDTO>();
            })
        .AddCommonResponse<CommonResponse<LogInResponseDTO>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.LogInEndPoint.SUMMARY,
            Description = Constants.Controllers.LogInEndPoint.DESCRIPTION
        });
    }

    private static RouteHandlerBuilder AddCommonResponse<T>(
        this RouteHandlerBuilder builder)
    {
        string contentType = Constants.CommonControllers.APPLICATION_JON;
        int status200OK = StatusCodes.Status200OK;
        int status401Unauthorized = StatusCodes.Status401Unauthorized;
        int status400BadRequest = StatusCodes.Status400BadRequest;
        int status403Forbidden = StatusCodes.Status403Forbidden;
        int status404NotFound = StatusCodes.Status404NotFound;

        return builder
            .Produces<T>(status200OK, contentType)
            .Produces<T>(status401Unauthorized, contentType)
            .Produces<T>(status400BadRequest, contentType)
            .Produces<T>(status403Forbidden, contentType)
            .Produces<T>(status404NotFound, contentType);
    }
}