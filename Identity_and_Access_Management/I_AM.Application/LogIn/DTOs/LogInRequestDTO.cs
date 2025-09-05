using I_AM.Application.Commons;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace I_AM.Application.LogIn.DTOs;

public record LogInRequestDTO(string Email, string Password)
    : IRequest<CommonResponse<LogInResponseDTO>>
{
    public bool DataInProperties() 
        => Email != null && Email != string.Empty &&
           Password != null && Password != string.Empty;

    public bool ValidEmil()
        => new EmailAddressAttribute().IsValid(Email);
}