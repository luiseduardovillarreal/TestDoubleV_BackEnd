using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Deb_t.DTOs.CommandCreate;

public record CreateDebtRequestDTO(DebtDTO Debt) 
    : IRequest<CommonResponse<string>>;