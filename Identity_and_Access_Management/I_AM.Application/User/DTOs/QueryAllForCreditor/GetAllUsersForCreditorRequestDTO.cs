using I_AM.Application.Commons;
using MediatR;

namespace I_AM.Application.Use_r.DTOs.QueryAllForCreditor;

public record GetAllUsersForCreditorRequestDTO(Guid IdDebtor)
    : IRequest<CommonResponse<GetAllUsersForCreditorResponseDTO>>;