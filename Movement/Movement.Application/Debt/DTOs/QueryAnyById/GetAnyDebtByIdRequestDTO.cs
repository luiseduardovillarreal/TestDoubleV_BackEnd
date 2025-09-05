using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Deb_t.DTOs.QueryAnyById;

public record class GetAnyDebtByIdRequestDTO(Guid IdDebt)
    : IRequest<CommonResponse<GetAnyDebtByIdResponseDTO>>;