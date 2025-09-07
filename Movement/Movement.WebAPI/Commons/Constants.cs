namespace Movement.WebAPI.Commons;

internal static class Constants
{
    internal static class CommonControllers
    {
        internal const string APPLICATION_JON = "application/json";
    }

    internal static class Controllers
    {
        internal static class ActivateDebtEndPoint
        {
            internal const string DEBT_ACTIVATE = "/debt/activate";
            internal const string SUMMARY = "Activa una deuda solicitada.";
            internal const string DESCRIPTION = "Recibe petición de activación " +
                "de una deuda eliminada y realiza la correspondiente acción " +
                "modificando el estado de esta.";
        }

        internal static class CreateDebtEndPoint
        {
            internal const string DEBT_CREATE = "/debt/create";
            internal const string SUMMARY = "Crea una deuda solicitada.";
            internal const string DESCRIPTION = "Recibe petición de registro de " +
                "deuda y realiza los registros correspondientes en sus " +
                "tablas predefinidas.";
        }

        internal static class DeleteDebtEndPoint
        {
            internal const string DEBT_DELETE = "/debt/delete";
            internal const string SUMMARY = "Elimina (Inactiva) una deuda solicitada.";
            internal const string DESCRIPTION = "Recibe petición de eliminación " +
                "de una deuda y realiza la correspondiente acción modificando " +
                "el estado de esta.";
        }

        internal static class GetAllDebtsByUserEndPoint
        {
            internal const string DEBT_GET_ALL = "/debt/get-all-by-user";
            internal const string SUMMARY = "Obtiene todas las deudas completas de un usuario.";
            internal const string DESCRIPTION = "Recibe petición con Id de un " +
                "usuario para obtener todas las deudas, realiza la consulta en base " +
                "de datos y en caso de encontrar al menos una, regresa una respuesta con la data.";
        }

        internal static class GetAllDebtsEndPoint
        {
            internal const string DEBT_GET_ALL = "/debt/get-all";
            internal const string SUMMARY = "Obtiene todas las deudas completas.";
            internal const string DESCRIPTION = "Recibe petición de obtener todas " +
                "las deudas, realiza la consulta en base de datos y en caso de " +
                "encontrar al menos una, regresa una respuesta con la data.";
        }

        internal static class GetAnyDebtActiveByIdEndPoint
        {
            internal const string DEBT_GET_ACTIVE_BY_ID = "/debt/get-active-by-id";
            internal const string SUMMARY = "Obtiene una deuda completa.";
            internal const string DESCRIPTION = "Recibe petición con el id de una " +
                "deuda, realiza la consulta en base de datos y en caso de encontrarla, " +
                "regresa la deuda con sus pagos a la fecha.";
        }

        internal static class GetAnyDebtByIdEndPoint
        {
            internal const string DEBT_GET_BY_ID = "/debt/get-by-id";
            internal const string SUMMARY = "Obtiene una deuda completa.";
            internal const string DESCRIPTION = "Recibe petición con el id de una " +
                "deuda, realiza la consulta en base de datos y en caso de encontrarla, " +
                "regresa la deuda con sus pagos a la fecha.";
        }

        internal static class CreatePayDebtEndPoint
        {
            internal const string DEBT_PAY = "/pay/create";
            internal const string SUMMARY = "Paga o abona a una deuda.";
            internal const string DESCRIPTION = "Recibe petición de abonar o " +
                "pagar una deuda y realiza la correspondiente acción.";
        }

        internal static class UpdateDebtEndPoint
        {
            internal const string DEBT_UPDATE = "/debt/update";
            internal const string SUMMARY = "Modifica una deuda solicitada.";
            internal const string DESCRIPTION = "Recibe petición de modificación " +
                "de una deuda y realiza la modificación correspondiente.";
        }
    }

    internal static class Program
    {
        internal const string MOVEMENT_APPLICATION = "Movement.Application";
        internal const string CONNECTION_STRINGS = "ConnectionStrings";
        internal const string DEFAULT_CONNECTION = "DefaultConnection";
        internal const string CORS_POLICY = "CorsPolicy";
        internal const string IP_AUTHORIZED = "IP_AUTHORIZED";
        internal const string V1 = "v1";
        internal const string TITLE = "Movements API";
        internal const string DESCRIPTION = "API encargada del core del módulo" +
            "de deudas.";
        internal const string TERMS_OF_SERVICE = "https://google.com.co";
        internal const string CONTACT_NAME = "Nombre contacto";
        internal const string CONTACT_URL = "https://google.com.co";
        internal const string LICENSE_NAME = "Licencia";
        internal const string LICENSE_URL = "https://google.com.co";
        internal const string SLASH = "/";
        internal const string SLASH_SWAGGER = "/swagger";
    }
}