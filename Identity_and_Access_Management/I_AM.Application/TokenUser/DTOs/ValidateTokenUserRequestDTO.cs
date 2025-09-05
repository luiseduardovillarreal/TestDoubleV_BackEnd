using I_AM.Application.Commons;
using MediatR;

namespace I_AM.Application.TokenUse_r.DTOs;

public record ValidateTokenUserRequestDTO(string token)
    : IRequest<CommonResponse<Guid>>;