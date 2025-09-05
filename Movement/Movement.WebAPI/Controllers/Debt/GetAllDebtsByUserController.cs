using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.QueryAllByUser;
using Movement.WebAPI.Commons;

namespace Movement.WebAPI.Controllers.Deb_t;

public static class GetAllDebtsByUserController
{
    public static void GetAllDebtsByUserEndPoint(this WebApplication app)
    {
        app.MapGet(Constants.Controllers.GetAllDebtsByUserEndPoint.DEBT_GET_ALL,
            async (IMediator mediator, Guid IdUser) =>
            {
                return await mediator.Send(new GetAllDebtsByUserRequestDTO(IdUser))
                    ?? new CommonResponse<GetAllDebtsByUserResponseDTO>();
            })
        .AddCommonResponse<CommonResponse<GetAllDebtsByUserResponseDTO>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.GetAllDebtsByUserEndPoint.SUMMARY,
            Description = Constants.Controllers.GetAllDebtsByUserEndPoint.DESCRIPTION
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