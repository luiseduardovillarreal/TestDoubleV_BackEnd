using I_AM.Application.Commons;
using I_AM.Application.Use_r.DTOs.CommandCreate;
using I_AM.WebAPI.Commons;
using MediatR;

namespace I_AM.WebAPI.Controllers.Use_r;

public static class CreateUserController
{
    public static void CreateUserEndPoint(this WebApplication app)
    {
        app.MapPost(Constants.Controllers.CreateUserEndPoint.USER_CREATE,
            async (IMediator mediator, CreateUserRequestDTO request) =>
            {
                return await mediator.Send(request)
                    ?? new CommonResponse<string>();
            })
        .AddCommonResponse<CommonResponse<string>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.CreateUserEndPoint.SUMMARY,
            Description = Constants.Controllers.CreateUserEndPoint.DESCRIPTION
        });
    }

    private static RouteHandlerBuilder AddCommonResponse<T>(
        this RouteHandlerBuilder builder)
    {
        string contentType = Constants.CommonControllers.APPLICATION_JON;
        int status201Created = StatusCodes.Status201Created;
        int status500InternalServerError = StatusCodes.Status500InternalServerError;
        int status400BadRequest = StatusCodes.Status400BadRequest;

        return builder
            .Produces<T>(status201Created, contentType)
            .Produces<T>(status500InternalServerError, contentType)
            .Produces<T>(status400BadRequest, contentType);
    }
}