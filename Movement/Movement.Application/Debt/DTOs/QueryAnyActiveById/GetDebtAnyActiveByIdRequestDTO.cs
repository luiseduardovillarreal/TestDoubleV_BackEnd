using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Deb_t.DTOs.QueryAnyActiveById;

public record GetDebtAnyActiveByIdRequestDTO(Guid IdDebt)
    : IRequest<CommonResponse<GetDebtAnyActiveByIdResponseDTO>>;