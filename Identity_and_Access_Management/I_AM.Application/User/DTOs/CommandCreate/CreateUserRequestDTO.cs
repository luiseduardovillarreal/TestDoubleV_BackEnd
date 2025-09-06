using I_AM.Application.Commons;
using MediatR;

namespace I_AM.Application.Use_r.DTOs.CommandCreate;

public record CreateUserRequestDTO(UserDTO User)
    : IRequest<CommonResponse<string>>;