using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Deb_t.DTOs.CommandActivate;

public record ActivateDebtRequestDTO(Guid Id) 
    : IRequest<CommonResponse<string>>;