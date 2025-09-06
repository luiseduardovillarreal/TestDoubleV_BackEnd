namespace I_AM.Application.Commons;

internal static class Constants
{
    internal static class CommonMessage
    {
        internal const string LOGIN_FAILED = "No se pudo iniciar la sesión.";
        internal const string TOKEN_INVALID = "Token inválido, verifique su " +
            "link o contáctese con el administrador de la plataforma.";
    }

    internal static class CommondResponsesCustom
    {
        internal const string COMMIT_0 = "No se pudo registrar la información, " +
            "verificar que el commit arrojó 0 como respuesta.";
        internal const string USER_EXIST = "Ya existe un usuario con ese correo " +
            "en la base de datos.";
        internal const string USER_NO_EXIST = "No se encontró el usuario en la " +
            "base de datos.";
        internal const string INVALID_EMAIL = "El correo no contiene un formato " +
            "correcto.";
        internal const string VERIFY_DATA = "Verificar valor en las propiedades " +
            "de sesión.";
    }

    internal static class LogIn
    {
        internal static class Queries
        {
            internal static class LogInQuery
            {
                internal const string NOT_FOUND_USER 
                    = "No se encontró el usuario en la base de datos.";
                internal const string INVALID_PASSWORD = "Credencial password inválida.";
                internal const string USER_INACTIVE = " El usuario se encuentra inactivo.";
                internal const string CONTACT_ADMIN = "Contáctese con el usuario administrador.";
                internal const string INTERNAL_SERVER_ERROR = "Falló la consulta con la base " +
                    "de datos al momento de traer la información del login con accesos y " +
                    "permisos.";
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

    internal static class User
    {
        internal static class Commands
        {
            internal static class CreateCommand
            {
                internal const string CREATED = "Usuario creado de manera exitosa.";
                internal const string NO_CREATED = "No se pudo registrar el usuario, " +
                    "verifique con el administrador del sistema.";
            }

            internal static class UpdateCommand
            {
                internal const string UPDATED = "Usuario actualizado de manera exitosa.";
                internal const string NO_UPDATED = "No se pudo actualizar el usuario, " +
                    "verifique con el administrador del sistema.";
            }
        }

        internal static class Queries
        {
            internal static class GetAllQuery
            {
                internal const string NOT_FOUND_DATA = "No se encontró información de usuarios " +
                    "en base de datos.";
                internal const string NO_LOAD_DATA = "No se encontró información de usuarios.";
            }
        }
    }
}