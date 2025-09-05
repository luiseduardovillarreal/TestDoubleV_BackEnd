using MediatR;

namespace I_AM.Application.TokenInques_t.DTOs;

public record CreateTokenInquestRequestDTO(Guid IdInquest, 
    bool ThisUniqueResponse, bool ThisOpen) : IRequest;