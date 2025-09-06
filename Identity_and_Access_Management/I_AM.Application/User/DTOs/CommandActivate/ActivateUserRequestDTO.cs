using I_AM.Application.Commons;
using MediatR;

namespace I_AM.Application.Use_r.DTOs.CommandActivate;

public record ActivateUserRequestDTO(Guid Id)
    : IRequest<CommonResponse<string>>;