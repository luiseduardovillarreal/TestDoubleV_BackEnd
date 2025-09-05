using I_AM.Application.TokenUse_r.DTOs;
using I_AM.Domain.Contracts;
using I_AM.Domain.Entities;
using MediatR;

namespace I_AM.Application.TokenUse_r.Commands;

internal class CreateTokenUserCommand(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateTokenUserRequestDTO>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(CreateTokenUserRequestDTO request, 
        CancellationToken cancellationToken)
    {
        var token = _unitOfWork.AuthService.GetTokenUser();

        TokenUser tokenUser = new();// (request.IdInquest, token, 
            //request.ThisUniqueResponse, request.ThisOpen);

        await _unitOfWork.TokenUserRepository.AddAsync(tokenUser);
        await _unitOfWork.Commit(CancellationToken.None);
    }
}