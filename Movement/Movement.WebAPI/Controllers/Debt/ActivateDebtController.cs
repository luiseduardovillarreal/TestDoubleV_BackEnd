using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.CommandActivate;
using Movement.WebAPI.Commons;

namespace Movement.WebAPI.Controllers.Deb_t;

public static class ActivateDebtController
{
    public static void ActivateDebtEndPoint(this WebApplication app)
    {
        app.MapPut(Constants.Controllers.ActivateDebtEndPoint.DEBT_ACTIVATE,
            async (IMediator mediator, ActivateDebtRequestDTO request) =>
            {
                return await mediator.Send(request)
                    ?? new CommonResponse<string>();
            })
        .AddCommonResponse<CommonResponse<string>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.ActivateDebtEndPoint.SUMMARY,
            Description = Constants.Controllers.ActivateDebtEndPoint.DESCRIPTION
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