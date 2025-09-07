namespace Movement.Application.Commons;

internal class Constants
{
    internal static class CommondResponsesCustom
    {
        internal const string COMMIT_0 = "No se pudo registrar la información, " +
            "verificar que el commit arrojó 0 como respuesta.";
        internal const string DEBT_NO_EXIST = "No se encontró la deuda en la base " +
            "de datos.";
    }

    internal static class Debt
    {
        internal static class Commands
        {
            internal const string CREATED = "Deuda creada de manera exitosa.";
            internal const string NO_CREATED = "No se pudo registrar la deuda, " +
                "verifique con el administrador del sistema.";
            internal const string FAILED_VALIDATIONS_AMOUNT = "La validación de " +
                "monto no negativo falló. Verificar valor.";
            internal const string FAILED_VALIDATIONS_NEW_AMOUNT = "La validación " +
                "de nuevo monto no menor al actual excedente de deuda falló. " +
                "Verificar valor.";
            internal const string DEBTOR_NOT_EXIST = "El usuario deudor no existe " +
                "en la base de datos.";
            internal const string DEBT_NOT_EXIST = "La deuda no existe en la base " +
                "de datos.";
            internal const string CREDITOR_NOT_EXIST = "El usuario creditor no " +
                "existe en la base de datos.";
            internal const string DELETED = "Deuda eliminada de manera exitosa.";
            internal const string NO_DELETED = "No se pudo eliminar la deuda, " +
                "verifique con el administrador del sistema.";
            internal const string NO_DELETED_DIFFERENCE = "No se pudo eliminar " +
                "la deuda, primero debe cancelarla en su totalidad.";
            internal const string UPDATED = "Deuda modificada de manera exitosa.";
            internal const string NO_UPDATED = "No se pudo modificar la deuda, " +
                "verifique con el administrador del sistema.";
            internal const string DEBT_INACTIVE = "La deuda ya se encuentra eliminada.";
        }

        internal static class Queries
        {
            internal static class GetAllDebtsQuery
            {
                internal const string NOT_FOUND_DATA = "No se encontró información " +
                    "de deudas en base de datos.";
                internal const string NO_LOAD_DATA = "No se encontró información " +
                    "de deudas.";
            }

            internal static class GetAllDebtsByUserDebtorQuery
            {
                internal const string NOT_FOUND_DATA = "No se encontró información " +
                    "de deudas en base de datos.";
                internal const string NO_LOAD_DATA = "No se encontró información " +
                    "de deudas.";
            }

            internal static class GetAnyDebtByIdQuery
            {
                internal const string NOT_FOUND_DATA = "No se encontró información " +
                    "de la deuda en la base de datos.";
                internal const string NO_LOAD_DATA = "No se encontró información " +
                    "de la deuda.";
            }
        }
    }

    internal static class Pay
    {
        internal static class Commands
        {
            internal const string PAY = "Se ha hecho el pago a la deuda con éxito.";
            internal const string NO_PAY = "No se pudo realizar el pago a la deuda, " +
                "verifique con el administrador del sistema.";
            internal const string NO_PAY_OUTSIDE = "No se pudo realizar el pago a " +
                "la deuda, el monto sobre pasa la deuda a hoy día.";            
        }
    }
}