using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Deb_t.DTOs.CommandPay;

public record PayDebtRequestDTO(PayRequestDTO Pay) 
    : IRequest<CommonResponse<string>>;