using I_AM.Application.Commons;
using I_AM.Application.TokenUse_r.DTOs;
using I_AM.Domain.Contracts;
using I_AM.Domain.Entities;
using MediatR;
using System.Net;

namespace I_AM.Application.TokenUse_r.Queries;

internal class ValidateTokenUserQuery(IUnitOfWork unitOfWork)
    : IRequestHandler<ValidateTokenUserRequestDTO, CommonResponse<Guid>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<Guid>> Handle(ValidateTokenUserRequestDTO request, 
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.token))
        {
            TokenUser tokenUser = await _unitOfWork.TokenUserRepository
                .FindFirstOrDefaultAsync(tknInq => tknInq.Token.Equals(request.token));

            if (tokenUser is not null)
            {
                _unitOfWork.Dispose();
                return new()
                {
                    Data = tokenUser.IdUser,
                    Message = string.Empty,
                    MessageCustom = string.Empty,
                    StatusCode = HttpStatusCode.OK,
                    Succeeded = true
                };
            }

            _unitOfWork.Dispose();
            return new()
            {
                Data = Guid.Empty,
                StatusCode = HttpStatusCode.NotFound,
                Message = Constants.CommonMessage.TOKEN_INVALID,
                MessageCustom = Constants.TokenUser.Queries.ValidateTokenUserQuery.NOT_FOUND_TOKEN,
                Succeeded = false
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = Guid.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.CommonMessage.TOKEN_INVALID,
            MessageCustom = Constants.TokenUser.Queries.ValidateTokenUserQuery.VERIFY_DATA,
            Succeeded = false
        };
    }
}