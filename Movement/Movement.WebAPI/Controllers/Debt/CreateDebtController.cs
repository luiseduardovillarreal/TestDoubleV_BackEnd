using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.CommandCreate;
using Movement.WebAPI.Commons;

namespace Movement.WebAPI.Controllers.Deb_t;

public static class CreateDebtController
{
    public static void CreateDebtEndPoint(this WebApplication app)
    {
        app.MapPost(Constants.Controllers.CreateDebtEndPoint.DEBT_CREATE,
            async (IMediator mediator, CreateDebtRequestDTO request) =>
            {
                return await mediator.Send(request)
                    ?? new CommonResponse<string>();
            })
        .AddCommonResponse<CommonResponse<string>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.CreateDebtEndPoint.SUMMARY,
            Description = Constants.Controllers.CreateDebtEndPoint.DESCRIPTION
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