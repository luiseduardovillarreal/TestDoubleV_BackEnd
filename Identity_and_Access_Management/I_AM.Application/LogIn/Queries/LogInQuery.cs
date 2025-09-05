using I_AM.Application.Commons;
using I_AM.Application.LogIn.DTOs;
using I_AM.Application.LogIn.Results;
using I_AM.Application.Utilities;
using I_AM.Domain.Contracts;
using I_AM.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace I_AM.Application.LogIn.Queries;

internal class LogInQuery(IUnitOfWork unitOfWork) :
    IRequestHandler<LogInRequestDTO, CommonResponse<LogInResponseDTO>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly Security _security = Security.GetInstance();

    public async Task<CommonResponse<LogInResponseDTO>> Handle(LogInRequestDTO request, 
        CancellationToken cancellationToken)
    {
        var dataInProperties = request.DataInProperties();
        if (dataInProperties)
        {
            var emailValid = request.ValidEmil();
            if (emailValid) 
            {
                User user = await _unitOfWork.UserRepository.FindFirstOrDefaultAsync(
                    usr => usr.Email.Equals(request.Email));
                if (user is not null)
                {
                    if (user.IsActive)
                    {
                        bool isPasswordCorrect = _security.VerifyPassword(request.Password,
                            user.Password);
                        if (isPasswordCorrect)
                        {
                            string resultQueryUser = await _unitOfWork.UserRepository
                                .GetUserAccessDetails(user.Id);

                            var resultUserAccessDetai = JsonConvert
                                .DeserializeObject<DTOQuerie<LogInResponseResult>>(resultQueryUser);

                            if (resultUserAccessDetai is not null && resultUserAccessDetai.State)
                            {
                                if (resultUserAccessDetai.Result.Data.Count > 0)
                                {
                                    var token = _unitOfWork.AuthService.GetToken(user.Id);

                                    LogInResponseDTO loginResponse = new(resultUserAccessDetai, token);
                                    loginResponse.ProcessDataGetUserAccessDetails();

                                    _unitOfWork.Dispose();
                                    return new()
                                    {
                                        Data = loginResponse,
                                        StatusCode = HttpStatusCode.OK,
                                        Succeeded = true
                                    };
                                }

                                _unitOfWork.Dispose();
                                return new()
                                {
                                    Data = new(new(), string.Empty),
                                    StatusCode = HttpStatusCode.InternalServerError,
                                    Message = Constants.CommonMessage.LOGIN_FAILED,
                                    MessageCustom = Constants.LogIn.Queries.LogInQuery.INTERNAL_SERVER_ERROR,
                                    Succeeded = false
                                };
                            }

                            _unitOfWork.Dispose();
                            return new()
                            {
                                Data = new(new(), string.Empty),
                                StatusCode = HttpStatusCode.InternalServerError,
                                Message = Constants.CommonMessage.LOGIN_FAILED,
                                MessageCustom = Constants.LogIn.Queries.LogInQuery.INTERNAL_SERVER_ERROR,
                                Succeeded = false
                            };
                        }

                        _unitOfWork.Dispose();
                        return new()
                        {
                            Data = new(new(), string.Empty),
                            StatusCode = HttpStatusCode.Unauthorized,
                            Message = Constants.CommonMessage.LOGIN_FAILED,
                            MessageCustom = Constants.LogIn.Queries.LogInQuery.INVALID_PASSWORD,
                            Succeeded = false
                        };
                    }

                    _unitOfWork.Dispose();
                    return new()
                    {
                        Data = new(new(), string.Empty),
                        StatusCode = HttpStatusCode.Forbidden,
                        Message = Constants.CommonMessage.LOGIN_FAILED +
                            Constants.LogIn.Queries.LogInQuery.USER_INACTIVE,
                        Succeeded = false
                    };
                }

                _unitOfWork.Dispose();
                return new()
                {
                    Data = new(new(), string.Empty),
                    StatusCode = HttpStatusCode.NotFound,
                    Message = Constants.CommonMessage.LOGIN_FAILED,
                    MessageCustom = Constants.LogIn.Queries.LogInQuery.NOT_FOUND_USER,
                    Succeeded = false
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = new(new(), string.Empty),
                StatusCode = HttpStatusCode.BadRequest,
                Message = Constants.CommonMessage.LOGIN_FAILED,
                MessageCustom = Constants.LogIn.Queries.LogInQuery.INVALID_EMAIL,
                Succeeded = false
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = new(new(), string.Empty),
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.CommonMessage.LOGIN_FAILED,
            MessageCustom = Constants.LogIn.Queries.LogInQuery.VERIFY_DATA,
            Succeeded = false
        };
    }
}