using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.QueryAnyActiveById;
using Movement.WebAPI.Commons;

namespace Movement.WebAPI.Controllers.Deb_t;

public static class GetAnyDebtActiveByIdController
{
    public static void GetAnyDebtActiveByIdEndPoint(this WebApplication app)
    {
        app.MapGet(Constants.Controllers.GetAnyDebtActiveByIdEndPoint.DEBT_GET_ACTIVE_BY_ID,
            async (IMediator mediator, Guid idDebt) =>
            {
                return await mediator.Send(new GetDebtAnyActiveByIdRequestDTO(idDebt))
                    ?? new CommonResponse<GetDebtAnyActiveByIdResponseDTO>();
            })
        .AddCommonResponse<CommonResponse<GetDebtAnyActiveByIdResponseDTO>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.GetAnyDebtActiveByIdEndPoint.SUMMARY,
            Description = Constants.Controllers.GetAnyDebtActiveByIdEndPoint.DESCRIPTION
        });
    }

    private static RouteHandlerBuilder AddCommonResponse<T>(
        this RouteHandlerBuilder builder)
    {
        string contentType = Constants.CommonControllers.APPLICATION_JON;
        int status200OK = StatusCodes.Status200OK;
        int status500InternalServerError = StatusCodes.Status500InternalServerError;
        int status404NotFound = StatusCodes.Status404NotFound;

        return builder
            .Produces<T>(status200OK, contentType)
            .Produces<T>(status500InternalServerError, contentType)
            .Produces<T>(status404NotFound, contentType);
    }
}