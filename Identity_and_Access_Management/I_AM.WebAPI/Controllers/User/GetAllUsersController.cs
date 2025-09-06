using I_AM.Application.Commons;
using I_AM.Application.Use_r.DTOs.QueryAll;
using I_AM.WebAPI.Commons;
using MediatR;

namespace I_AM.WebAPI.Controllers.Use_r;

public static class GetAllUsersController
{
    public static void GetAllUsersEndPoint(this WebApplication app)
    {
        app.MapGet(Constants.Controllers.GetAllUsersEndPoint.USER_GET_ALL,
            async (IMediator mediator) =>
            {
                return await mediator.Send(new GetAllUsersRequestDTO())
                    ?? new CommonResponse<GetAllUsersResponseDTO>();
            })
        .AddCommonResponse<CommonResponse<GetAllUsersResponseDTO>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.GetAllUsersEndPoint.SUMMARY,
            Description = Constants.Controllers.GetAllUsersEndPoint.DESCRIPTION
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