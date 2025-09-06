using AutoMapper;
using I_AM.Application.Commons;
using I_AM.Application.LogIn.DTOs;
using I_AM.Application.Utilities;
using I_AM.Domain.Contracts;
using I_AM.Domain.Entities;
using MediatR;
using System.Net;

namespace I_AM.Application.LogIn.Queries;

internal class LogInQuery(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<LogInRequestDTO, CommonResponse<LogInResponseDTO>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
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
                User user = await _unitOfWork.UserRepository.FindAnyByEmailAsync(request.Email);
                if (user is not null)
                {
                    if (user.IsActive)
                    {
                        bool isPasswordCorrect = _security.VerifyPassword(request.Password,
                            user.Password);

                        var token = _unitOfWork.AuthService.GetToken(user.Id);

                        var userDTO = _mapper.Map<UserDTO>(user);

                        if (isPasswordCorrect)
                        {
                            _unitOfWork.Dispose();
                            return new()
                            {
                                Data = new(userDTO, token),
                                StatusCode = HttpStatusCode.OK,
                                Succeeded = true
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