namespace I_AM.Application.Commons;

internal static class Constants
{
    internal static class CommonMessage
    {
        internal const string LOGIN_FAILED = "No se pudo iniciar la sesión.";
        internal const string TOKEN_INVALID = "Token inválido, verifique su " +
            "link o contáctese con el administrador de la plataforma.";
    }

    internal static class LogIn
    {
        internal static class Queries
        {
            internal static class LogInQuery
            {
                internal const string NOT_FOUND_USER 
                    = "No se encontró el usuario en la base de datos.";
                internal const string VERIFY_DATA = "Verificar valor en las propiedades " +
                    "de sesión.";
                internal const string INVALID_PASSWORD = "Credencial password inválida.";
                internal const string USER_INACTIVE = " El usuario se encuentra inactivo.";
                internal const string CONTACT_ADMIN = "Contáctese con el usuario administrador.";
                internal const string INTERNAL_SERVER_ERROR = "Falló la consulta con la base " +
                    "de datos al momento de traer la información del login con accesos y " +
                    "permisos.";
                internal const string INVALID_EMAIL = "El correo no contiene un formato correcto.";
            }
        }
    }

    internal static class TokenUser
    {
        internal static class Queries
        {
            internal static class ValidateTokenUserQuery
            {
                internal const string NOT_FOUND_TOKEN
                    = "No se encontró el token en la base de datos.";
                internal const string VERIFY_DATA = "Verificar valor en la propiedad " +
                    "token.";
            }
        }
    }
}