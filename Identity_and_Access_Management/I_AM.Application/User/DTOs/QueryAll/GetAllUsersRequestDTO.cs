using I_AM.Application.Commons;
using MediatR;

namespace I_AM.Application.Use_r.DTOs.QueryAll;

public record GetAllUsersRequestDTO()
    : IRequest<CommonResponse<GetAllUsersResponseDTO>>;