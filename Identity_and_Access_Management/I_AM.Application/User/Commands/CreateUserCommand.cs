using AutoMapper;
using I_AM.Application.Commons;
using I_AM.Application.Use_r.DTOs.CommandCreate;
using I_AM.Application.Utilities;
using I_AM.Domain.Contracts;
using I_AM.Domain.Entities;
using MediatR;
using System.Net;

namespace I_AM.Application.Use_r.Commands;

internal class CreateUserCommand(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateUserRequestDTO, CommonResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly Security _security = Security.GetInstance();

    public async Task<CommonResponse<string>> Handle(CreateUserRequestDTO request,
        CancellationToken cancellationToken)
    {
        var validExistData = request.User.ValidDataInProperties();
        if (validExistData)
        {
            var emailValid = request.User.ValidEmil();
            if (emailValid)
            {
                var queryUser = await _unitOfWork.UserRepository.FindFirstOrDefaultAsync(
                    usr => usr.Email.Equals(request.User.Email));

                if (queryUser is null)
                {
                    var user = _mapper.Map<User>(request.User);
                    user.SetPasswordHash(_security.HashPassword(user.Password));
                    var profile = await _unitOfWork.ProfileRepository.FindFirstOrDefaultAsync(
                        pro => pro.Code == 2);
                    user.AddProfile(profile);

                    await _unitOfWork.UserRepository.AddAsync(user);

                    var resultCommit = await _unitOfWork.Commit(CancellationToken.None);

                    if (resultCommit > 0)
                    {
                        _unitOfWork.Dispose();
                        return new()
                        {
                            Data = string.Empty,
                            StatusCode = HttpStatusCode.Created,
                            Message = Constants.User.Commands.CreateCommand.CREATED,
                            MessageCustom = string.Empty,
                            Succeeded = true
                        };
                    }

                    _unitOfWork.Dispose();
                    return new()
                    {
                        Data = string.Empty,
                        StatusCode = HttpStatusCode.InternalServerError,
                        Message = Constants.User.Commands.CreateCommand.NO_CREATED,
                        MessageCustom = Constants.CommondResponsesCustom.COMMIT_0,
                        Succeeded = false
                    };
                }

                _unitOfWork.Dispose();
                return new()
                {
                    Data = string.Empty,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = Constants.User.Commands.CreateCommand.NO_CREATED,
                    MessageCustom = Constants.CommondResponsesCustom.USER_EXIST,
                    Succeeded = false
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = string.Empty,
                StatusCode = HttpStatusCode.BadRequest,
                Message = Constants.User.Commands.CreateCommand.NO_CREATED,
                MessageCustom = Constants.CommondResponsesCustom.INVALID_EMAIL,
                Succeeded = false
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = string.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.User.Commands.CreateCommand.NO_CREATED,
            MessageCustom = Constants.CommondResponsesCustom.VERIFY_DATA,
            Succeeded = false
        };
    }
}