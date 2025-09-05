using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.CommandUpdate;
using Movement.WebAPI.Commons;

namespace Movement.WebAPI.Controllers.Deb_t;

public static class UpdateDebtController
{
    public static void UpdateDebtEndPoint(this WebApplication app)
    {
        app.MapPut(Constants.Controllers.UpdateDebtEndPoint.DEBT_UPDATE,
            async (IMediator mediator, UpdateDebtRequestDTO request) =>
            {
                return await mediator.Send(request)
                    ?? new CommonResponse<string>();
            })
        .AddCommonResponse<CommonResponse<string>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.UpdateDebtEndPoint.SUMMARY,
            Description = Constants.Controllers.UpdateDebtEndPoint.DESCRIPTION
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