using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Pa_y.DTOs.CommandPay;

public record CreatePayDebtRequestDTO(PayDTO Pay) 
    : IRequest<CommonResponse<string>>;