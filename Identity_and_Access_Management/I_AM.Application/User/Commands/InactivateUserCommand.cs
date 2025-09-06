using I_AM.Application.Commons;
using I_AM.Application.Use_r.DTOs.CommandInactivate;
using I_AM.Domain.Contracts;
using I_AM.Domain.Entities;
using MediatR;
using System.Net;

namespace I_AM.Application.Use_r.Commands;

internal class InactivateUserCommand(IUnitOfWork unitOfWork)
    : IRequestHandler<InactivateUserRequestDTO, CommonResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<string>> Handle(InactivateUserRequestDTO request,
        CancellationToken cancellationToken)
    {
        User user = await _unitOfWork.UserRepository.FindFirstOrDefaultAsync(
               usr => usr.Id.Equals(request.Id));

        if (user is not null)
        {
            user.Inactivate();

            _unitOfWork.UserRepository.Update(user);

            var resultCommit = await _unitOfWork.Commit(CancellationToken.None);

            if (resultCommit > 0)
            {
                _unitOfWork.Dispose();
                return new()
                {
                    Data = string.Empty,
                    StatusCode = HttpStatusCode.Created,
                    Message = Constants.User.Commands.UpdateCommand.UPDATED,
                    MessageCustom = string.Empty,
                    Succeeded = true
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = string.Empty,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = Constants.User.Commands.UpdateCommand.NO_UPDATED,
                MessageCustom = Constants.CommondResponsesCustom.COMMIT_0,
                Succeeded = false
            };            
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = string.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.User.Commands.UpdateCommand.NO_UPDATED,
            MessageCustom = Constants.CommondResponsesCustom.USER_NO_EXIST,
            Succeeded = false
        };
    }
}