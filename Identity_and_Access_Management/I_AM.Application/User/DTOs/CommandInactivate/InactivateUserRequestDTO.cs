using I_AM.Application.Commons;
using MediatR;

namespace I_AM.Application.Use_r.DTOs.CommandInactivate;

public record InactivateUserRequestDTO(Guid Id)
    : IRequest<CommonResponse<string>>;