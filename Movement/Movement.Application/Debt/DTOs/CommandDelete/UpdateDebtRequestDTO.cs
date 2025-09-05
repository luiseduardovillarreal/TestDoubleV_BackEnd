using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Deb_t.DTOs.CommandDelete;

public record DeleteDebtRequestDTO(Guid IdDebt) 
    : IRequest<CommonResponse<string>>;