using MediatR;
using Movement.Application.Commons;
using Movement.Application.Deb_t.DTOs.QueryAll;
using Movement.WebAPI.Commons;

namespace Movement.WebAPI.Controllers.Deb_t;

public static class GetAllDebtsController
{
    public static void GetAllDebtsEndPoint(this WebApplication app)
    {
        app.MapGet(Constants.Controllers.GetAllDebtsEndPoint.DEBT_GET_ALL,
            async (IMediator mediator) =>
            {
                return await mediator.Send(new GetAllDebtsRequestDTO())
                    ?? new CommonResponse<GetAllDebtsResponseDTO>();
            })
        .AddCommonResponse<CommonResponse<GetAllDebtsResponseDTO>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.GetAllDebtsEndPoint.SUMMARY,
            Description = Constants.Controllers.GetAllDebtsEndPoint.DESCRIPTION
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