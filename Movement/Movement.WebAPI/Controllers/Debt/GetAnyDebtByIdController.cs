using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.QueryAnyById;
using Movement.WebAPI.Commons;

namespace Movement.WebAPI.Controllers.Deb_t;

public static class GetAnyDebtByIdController
{
    public static void GetAnyDebtByIdEndPoint(this WebApplication app)
    {
        app.MapGet(Constants.Controllers.GetAnyDebtByIdEndPoint.DEBT_GET_BY_ID,
            async (IMediator mediator, Guid idDebt) =>
            {
                return await mediator.Send(new GetAnyDebtByIdRequestDTO(idDebt))
                    ?? new CommonResponse<GetAnyDebtByIdResponseDTO>();
            })
        .AddCommonResponse<CommonResponse<GetAnyDebtByIdResponseDTO>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.GetAnyDebtByIdEndPoint.SUMMARY,
            Description = Constants.Controllers.GetAnyDebtByIdEndPoint.DESCRIPTION
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