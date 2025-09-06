namespace I_AM.WebAPI.Commons;

internal static class Constants
{
    internal static class CommonControllers
    {
        internal const string APPLICATION_JON = "application/json";
    }

    internal static class Controllers
    {
        internal static class ActivateUserEndPoint
        {
            internal const string USER_UPDATE = "/user/activate";
            internal const string SUMMARY = "Actualiza el estado de un usuario.";
            internal const string DESCRIPTION = "Recibe la petición de activar " +
                "un usuario, realiza sus validaciones correspondientes y en " +
                "caso positivo, realiza la activación.";
        }

        internal static class CreateUserEndPoint
        {
            internal const string USER_CREATE = "/user/create";
            internal const string SUMMARY = "Crea un usuario.";
            internal const string DESCRIPTION = "Recibe la petición de crear " +
                "un usuario, realiza sus validaciones correspondientes y en " +
                "caso positivo, realiza la insercción.";
        }

        internal static class GetAllUsersEndPoint
        {
            internal const string USER_GET_ALL = "/user/get-all";
            internal const string SUMMARY = "Obtiene todos los usuarios.";
            internal const string DESCRIPTION = "Recibe la petición de obtener " +
                "todos los usuario, realiza sus validaciones correspondientes y " +
                "devuelve los usuarios que existan en base de datos.";
        }

        internal static class InactivateUserEndPoint
        {
            internal const string USER_UPDATE = "/user/inactivate";
            internal const string SUMMARY = "Actualiza el estado de un usuario.";
            internal const string DESCRIPTION = "Recibe la petición de inactivar " +
                "un usuario, realiza sus validaciones correspondientes y en " +
                "caso positivo, realiza la inactivación.";
        }

        internal static class LogInEndPoint
        {
            internal const string LOGIN_AUTH = "/login/auth";
            internal const string SUMMARY = "Obtiene el token por autenticación para " +
                "la seguridad de las peticiones.";
            internal const string DESCRIPTION = "Valida la autenticidad del usuario que " +
                "realiza la petición del inicio de sesión, verifica todas la validaciones " +
                "y le genera un token de seguirdad.";
        }
    }

    internal static class Listener
    {
        internal class RabbitMQConsumerService
        {
            internal const string SERVER_RABBIT_MQ = "ServiceBus:ServerRabbitMQ";
            internal const string PORT_RABBIT_MQ = "ServiceBus:PortRabbitMQ";            
            internal const string USER = "ServiceBus:User";
            internal const string PASSWORD = "ServiceBus:Password";
            internal const string QUEUE_TOKEN_USER = "ServiceBus:QueueTokenUser";
        }
    }

    internal static class Program
    {
        internal const string I_AM_APPLICATION = "I_AM.Application";
        internal const string DEFAULT_CONNECTION = "DefaultConnection";
        internal const string CONNECTION_STRINGS = "ConnectionStrings";
        internal const string CORS_APP = "corsapp";
        internal const string IP_AUTHORIZED = "IP_AUTHORIZED";
        internal const string V1 = "v1";
        internal const string TITLE = "Identity and Access Management API";
        internal const string DESCRIPTION = "API encargada de la " +
            "identificación, gestión, configuración y permisos de usuarios " +
            "sobre funcionalidades, menús, submenús y rutas del aplicativo, " +
            "también maneja la autorización de tokens para usuarios.";
        internal const string TERMS_OF_SERVICE = "https://google.com.co";
        internal const string CONTACT_NAME = "Nombre contacto";
        internal const string CONTACT_URL = "https://google.com.co";
        internal const string LICENSE_NAME = "Licencia";
        internal const string LICENSE_URL = "https://google.com.co";
        internal const string SLASH = "/";
        internal const string SLASH_SWAGGER = "/swagger";
    }
}