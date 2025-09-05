using MediatR;
using Movement.Application.Commons;

namespace Movement.Application.Deb_t.DTOs.QueryAll;

public record GetAllDebtsRequestDTO()
    : IRequest<CommonResponse<GetAllDebtsResponseDTO>>;