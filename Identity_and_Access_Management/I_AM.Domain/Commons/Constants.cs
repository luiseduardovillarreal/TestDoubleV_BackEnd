namespace I_AM.Domain.Commons;

internal static class Constants
{
    internal static class Entities
    {
        internal static class CommonComents
        {
            internal const string COMMENTS_ON_PROPERTIES_ID = "Id autogenerativo para la llave " +
                "principal de la tabla.";
            internal const string COMMENTS_ON_PROPERTIES_CREATE_AT = "Fecha de creación del " +
                "registro.";
            internal const string COMMENTS_ON_PROPERTIES_UPDATE_AT = "Fecha de la última " +
                "modificación sobre el registro.";
            internal const string COMMENTS_ON_PROPERTIES_IS_ACTIVE = "Esta propiedad traducida " +
                "como ¿Está activo? Quiere decir que si el valor es true, es por que si está activo " +
                "el registro, o sea que el registro no está eliminado, pero si el valor es false, " +
                "quiere decir que el registro no está activo, o sea, está eliminado.";
            internal const string COMMENTS_ON_PROPERTIES_ID_INQUEST = "Llave foránea de referencia " +
                "a la tabla TblSurveyInquest.";
            internal const string COMMENTS_ON_PROPERTIES_ID_USER = "Llave foránea de referencia " +
                "a la tabla TblUser.";
            internal const string COMMENTS_ON_PROPERTIES_ID_PROFILE = "Llave foránea de referencia " +
                "a la tabla TblProfile.";
            internal const string COMMENTS_ON_PROPERTIES_ID_MODULE = "Llave foránea de referencia " +
                "a la tabla TblModule.";
            internal const string COMMENTS_ON_PROPERTIES_ID_SUB_MODULE = "Llave foránea de referencia " +
                "a la tabla TblSubModule.";            
            internal const string COMMENTS_ON_PROPERTIES_CODE = "Código numérico de identificación " +
                "única para un registro.";
        }

        internal static class CommonProperties
        {
            internal const string ID = "Id";
            internal const string ID_INQUEST = "IdInquest";
            internal const string CREATE_AT = "CreateAt";
            internal const string UPDATE_AT = "UpdateAt";
            internal const string IS_ACTIVE = "IsActive";
            internal const string ID_USER = "IdUser";
            internal const string ID_PROFILE = "IdProfile";
            internal const string ID_MODULE = "IdModule";
            internal const string ID_SUB_MODULE = "IdSubModule";
            internal const string CODE = "Code";
        }

        internal static class ForeignsKeys
        {
            internal const string FOREIGN_KEY_INQUEST = "Inquest";
            internal const string FOREIGN_KEY_TYPE_QUESTION = "TypeQuestion";
            internal const string FOREIGN_KEY_QUESTION = "Question";
            internal const string FOREIGN_KEY_RESPONSE_CLOSED = "ResponseClosed";
            internal const string FOREIGN_KEY_ROL = "Rol";
            internal const string FOREIGN_KEY_USER = "User";
            internal const string FOREIGN_KEY_PROFILE = "Profile";
            internal const string FOREIGN_KEY_MODULE = "Module";
            internal const string FOREIGN_KEY_SUB_MODULE = "SubModule";
            internal const string FOREIGN_KEY_ACTION = "Action";
        }

        internal static class Module
        {
            internal const string TBL_MODULE = "TblModule";
            internal const string NAME = "Name";
            internal const string DESCRIPTION = "Description";
            internal const string ICON = "Icon";            
            internal const string COMMENTS_ON_NAME = "Breve nombre alusivo al módulo.";
            internal const string COMMENTS_ON_DESCRIPTION = "Descripción del módulo.";
            internal const string COMMENTS_ON_ICON = "Ícono para el módulo.";
        }

        internal static class Module_SubModule
        {
            internal const string TBL_MODULE_SUB_MODULE = "TblModule_SubModule";
        }

        internal static class Profile
        {
            internal const string TBL_PROFILE = "TblProfile";
            internal const string NAME = "Name";
            internal const string DESCRIPTION = "Description";
            internal const string COMMENTS_ON_NAME = "Breve nombre alusivo al perfil.";
            internal const string COMMENTS_ON_DESCRIPTION = "Descripción del perfil.";
        }

        internal static class Profile_Module
        {
            internal const string TBL_PROFILE_MODULE = "TblProfile_Module";
        }

        internal static class Profile_SubModule
        {
            internal const string TBL_PROFILE_SUBMODULE = "TblProfile_SubModule";
        }
                
        internal static class Rol
        {            
            internal const string TBL_ROL = "TblRol";
            internal const string NAME = "Name";
            internal const string DESCRIPTION = "Description";
            internal const string COMMENTS_ON_NAME = "Breve nombre alusivo al rol de usuario.";
            internal const string COMMENTS_ON_DESCRIPTION = "Descripción del rol de usuario.";
        }

        internal static class SubModule
        {
            internal const string TBL_SUB_MODULE = "TblSubModule";
            internal const string NAME = "Name";
            internal const string DESCRIPTION = "Description";
            internal const string ROUTER_LINK = "RouterLink";
            internal const string COMMENTS_ON_NAME = "Breve nombre alusivo al sub módulo.";
            internal const string COMMENTS_ON_DESCRIPTION = "Descripción del sub módulo.";
            internal const string COMMENTS_ON_ROUTER_LINK = "Ruta de apertura del submódulo al " +
                "hacer clic.";
        }       

        internal static class TokenInquest
        {
            internal const string TBL_TOKEN_INQUEST = "TblTokenInquest";
            internal const string TOKEN = "Token";
            internal const string THIS_UNIQUE_RESPONSE = "ThisUniqueResponse";
            internal const string THIS_OPEN = "ThisOpen";
            internal const string COMMENTS_ON_TOKEN = "Token que manejará la seguridad " +
                "de muestra y acceso a la encuesta (Inquest), mediante éste Token " +
                "y en unión a otras propiedades, se da acceso a mostrar la encuesta " +
                "u ocultarla.";
            internal const string COMMENTS_ON_THIS_UNIQUE_RESPONSE = "Esta propiedad " +
                "traducida como ¿Esto es única respuesta? Quiere decir que si el valor es " +
                "true, es por que el token del registro relacionado con una encuesta, sólo " +
                "tiene un uso válido por usuario, no expira el token sino sólo para quién " +
                "respondió la encuesta.";
            internal const string COMMENTS_ON_THIS_OPEN = "Esta propiedad traducida " +
                "como ¿Esto es abierto? Quiere decir que si el valor es true, es por que el " +
                "token del registro relacionado con una encuesta, nunca expirará.";
        }

        internal static class TokenUser
        {
            internal const string TBL_TOKEN_USER = "TblTokenUser";
            internal const string TOKEN = "Token";
            internal const string EXPIRE_AT = "ExpireAt";
            internal const string COMMENTS_ON_TOKEN = "Token que manejará la seguridad " +
                "de muestra y acceso a las interfaces para los usuario, que necesiten " +
                "seguridad.";
            internal const string COMMENTS_ON_EXPIRE_AT = "Fecha de expiración del Token " +
                "para el usuario, una vez expira, ya no puede ser utilizado para ninguna " +
                "acción.";
        }

        internal static class User
        {
            internal const string TBL_USER = "TblUser";            
            internal const string NAMES = "Names";
            internal const string LAST_NAMES = "LastNames";
            internal const string EMAIL = "Email";
            internal const string PASSWORD = "´Password";            
            internal const string COMMENTS_ON_NAMES = "Nombres completos del usuario.";
            internal const string COMMENTS_ON_LAST_NAMES = "Apellidos completos del usuario.";
            internal const string COMMENTS_ON_EMAIL = "Correo electrónico del usuario.";
            internal const string COMMENTS_ON_PASSWORD = "Contraseña del usuario.";
        }

        internal static class User_Profile
        {
            internal const string TBL_USER_PROFILE = "TblUser_Profile";
        }

        internal static class User_Rol
        {
            internal const string TBL_USER_ROL = "TblUser_Rol";
            internal const string ID_ROL = "IdRol";
            internal const string COMMENTS_ON_ID_ROL = "Llave foránea de referencia " +
                "a la tabla TblRol.";
        }        
    }
}