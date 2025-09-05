using I_AM.Application.Commons;
using I_AM.Application.TokenInques_t.DTOs;
using I_AM.Domain.Contracts;
using I_AM.Domain.Entities;
using MediatR;
using System.Net;

namespace I_AM.Application.TokenInques_t.Queries;

internal class ValidateTokenInquestQuery(IUnitOfWork unitOfWork)
    : IRequestHandler<ValidateTokenInquestRequestDTO, CommonResponse<Guid>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CommonResponse<Guid>> Handle(ValidateTokenInquestRequestDTO request, 
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.token))
        {
            TokenInquest tokenInquest = await _unitOfWork.TokenInquestRepository
                .FindFirstOrDefaultAsync(tknInq => tknInq.Token.Equals(request.token));

            if (tokenInquest is not null)
            {
                _unitOfWork.Dispose();
                return new()
                {
                    Data = tokenInquest.IdInquest,
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
                MessageCustom = Constants.TokenInquest.Queries.ValidateTokenInquestQuery.NOT_FOUND_TOKEN,
                Succeeded = false
            };
        }

        _unitOfWork.Dispose();
        return new()
        {
            Data = Guid.Empty,
            StatusCode = HttpStatusCode.BadRequest,
            Message = Constants.CommonMessage.TOKEN_INVALID,
            MessageCustom = Constants.TokenInquest.Queries.ValidateTokenInquestQuery.VERIFY_DATA,
            Succeeded = false
        };
    }
}