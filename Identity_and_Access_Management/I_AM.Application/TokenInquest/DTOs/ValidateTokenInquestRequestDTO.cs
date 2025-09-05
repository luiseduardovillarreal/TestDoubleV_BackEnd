using I_AM.Application.Commons;
using MediatR;

namespace I_AM.Application.TokenInques_t.DTOs;

public record ValidateTokenInquestRequestDTO(string token)
    : IRequest<CommonResponse<Guid>>;