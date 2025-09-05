namespace I_AM.Infrastructure.Commons;

internal static class Constants
{
    internal static class GenericQuery
    {
        internal static class ExecuteQuery
        {
            internal const string REPORTS = "reports";
            internal const string YOUR_ASSEMBLY = "YourAssembly";
            internal const string YOUR_DYNAMIC_MODULE = "YourDynamicModule";
            internal const string GET_VALUE = "get_value";
            internal const string SET_VALUE = "set_value";
        }
    }

    internal static class Repositories
    {
        internal static class UserRepository
        {
            internal const string ID_USER = "idUser";
            internal const string SP_GET_USER_ACCESS_DETAILS = "StoreProcedure:GetUserAccessDetails";
        }
    }

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