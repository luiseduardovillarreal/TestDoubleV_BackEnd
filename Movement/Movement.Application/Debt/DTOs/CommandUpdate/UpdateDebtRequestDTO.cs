using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Deb_t.DTOs.CommandUpdate;

public record UpdateDebtRequestDTO(DebtDTO Debt) 
    : IRequest<CommonResponse<string>>;