using I_AM.Application.TokenInques_t.DTOs;
using I_AM.Domain.Contracts;
using I_AM.Domain.Entities;
using MediatR;

namespace I_AM.Application.TokenInques_t.Commands;

internal class CreateTokenInquestCommand(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateTokenInquestRequestDTO>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(CreateTokenInquestRequestDTO request, 
        CancellationToken cancellationToken)
    {
        var token = _unitOfWork.AuthService.GetTokenInquest();

        TokenInquest tokenInquest = new(request.IdInquest, token, 
            request.ThisUniqueResponse, request.ThisOpen);

        await _unitOfWork.TokenInquestRepository.AddAsync(tokenInquest);
        await _unitOfWork.Commit(CancellationToken.None);
    }
}