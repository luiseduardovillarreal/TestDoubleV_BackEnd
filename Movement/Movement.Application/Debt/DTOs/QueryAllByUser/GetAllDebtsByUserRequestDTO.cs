using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Deb_t.DTOs.QueryAllByUser;

public record GetAllDebtsByUserRequestDTO(Guid IdUserDebtor)
    : IRequest<CommonResponse<GetAllDebtsByUserResponseDTO>>;