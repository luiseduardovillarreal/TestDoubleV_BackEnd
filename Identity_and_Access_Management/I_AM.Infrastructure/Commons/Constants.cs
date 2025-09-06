namespace I_AM.Infrastructure.Commons;

internal static class Constants
{
    internal static class Services
    {
        internal static class AuthService
        {
            internal const string KEY_SECRET = "Jwt:KeySecret";
            internal const string ISSUER = "Jwt:Issuer";
            internal const string AUDIENCE = "Jwt:Audience";
            internal const string MINUTES_ACTIVE = "Jwt:MinutesActive";
        }
    }
}