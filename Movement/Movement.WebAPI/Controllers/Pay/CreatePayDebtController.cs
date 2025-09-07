using MediatR;
using Movement.Application.Commons;
using Movement.Application.Pa_y.DTOs.CommandPay;
using Movement.WebAPI.Commons;

namespace Movement.WebAPI.Controllers.Pa_y;

public static class CreatePayDebtController
{
    public static void CreatePayDebtEndPoint(this WebApplication app)
    {
        app.MapPost(Constants.Controllers.CreatePayDebtEndPoint.DEBT_PAY,
            async (IMediator mediator, CreatePayDebtRequestDTO request) =>
            {
                return await mediator.Send(request)
                    ?? new CommonResponse<string>();
            })
        .AddCommonResponse<CommonResponse<string>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.CreatePayDebtEndPoint.SUMMARY,
            Description = Constants.Controllers.CreatePayDebtEndPoint.DESCRIPTION
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