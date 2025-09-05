namespace I_AM.Domain.Services;

public interface IAuthService
{
    string GetToken(Guid idUser);
    string GetTokenInquest();
    string GetTokenForgotPassword();
    string RefreshToken(Guid idUser);
}