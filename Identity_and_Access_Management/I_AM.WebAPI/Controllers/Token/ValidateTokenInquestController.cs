using I_AM.Application.Commons;
using I_AM.Application.TokenInques_t.DTOs;
using I_AM.WebAPI.Commons;
using MediatR;

namespace I_AM.WebAPI.Controllers.Token;

public static class ValidateTokenInquestController
{
    public static void ValidateTokenInquestEndPoint(this WebApplication app)
    {
        app.MapGet(Constants.Controllers.ValidateTokenInquestEndPoint.TOKEN_VALIDATE_TOKEN_INQUEST,
            async (IMediator mediator, string token) =>
            {
                return await mediator.Send(new ValidateTokenInquestRequestDTO(token))
                    ?? new CommonResponse<Guid>();
            })
        .AddCommonResponse<CommonResponse<Guid>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.ValidateTokenInquestEndPoint.SUMMARY,
            Description = Constants.Controllers.ValidateTokenInquestEndPoint.DESCRIPTION
        });
    }

    private static RouteHandlerBuilder AddCommonResponse<T>(
        this RouteHandlerBuilder builder)
    {
        string contentType = Constants.CommonControllers.APPLICATION_JON;
        int status200OK = StatusCodes.Status200OK;
        int status400BadRequest = StatusCodes.Status400BadRequest;
        int status404NotFound = StatusCodes.Status404NotFound;

        return builder
            .Produces<T>(status200OK, contentType)
            .Produces<T>(status400BadRequest, contentType)
            .Produces<T>(status404NotFound, contentType);
    }
}