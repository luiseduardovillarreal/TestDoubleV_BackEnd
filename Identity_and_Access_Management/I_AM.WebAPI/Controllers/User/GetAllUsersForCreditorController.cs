using I_AM.Application.Commons;
using I_AM.Application.Use_r.DTOs.QueryAllForCreditor;
using I_AM.WebAPI.Commons;
using MediatR;

namespace I_AM.WebAPI.Controllers.Use_r;

public static class GetAllUsersForCreditorController
{
    public static void GetAllUsersForCreditorEndPoint(this WebApplication app)
    {
        app.MapGet(Constants.Controllers.GetAllUsersForCreditorEndPoint.USER_GET_ALL_FOR_CREDITOR,
            async (IMediator mediator, Guid IdDebtor) =>
            {
                return await mediator.Send(new GetAllUsersForCreditorRequestDTO(IdDebtor))
                    ?? new CommonResponse<GetAllUsersForCreditorResponseDTO>();
            })
        .AddCommonResponse<CommonResponse<GetAllUsersForCreditorResponseDTO>>()
        .WithOpenApi(static operation => new(operation)
        {
            Summary = Constants.Controllers.GetAllUsersForCreditorEndPoint.SUMMARY,
            Description = Constants.Controllers.GetAllUsersForCreditorEndPoint.DESCRIPTION
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