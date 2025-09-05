using MediatR;

namespace I_AM.Application.TokenUse_r.DTOs;

public record CreateTokenUserRequestDTO(Guid IdUser) : IRequest;