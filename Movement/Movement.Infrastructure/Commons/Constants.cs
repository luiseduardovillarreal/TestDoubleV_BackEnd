namespace Movement.Infrastructure.Commons;

internal static class Constants
{
    internal static class Persistence
    {
        internal static class Context
        {
            internal static class MovementDbContext
            {                
                internal static class SeedDataModules
                {
                    internal const string GUID_DASHBOARD = "42690d34-5695-4b04-aa50-7c85ee34f18d";
                    internal const string DASHBOARD = "Dashboard";
                    internal const string DESCRIPTION_DASHBOARD
                        = "Dashboard principal del aplicativo. Vista sin ningún componente a bordo.";
                    internal const string ICON_DASHBOARD = "menu-icon tf-icons bx bx-home-circle";

                    internal const string GUID_CONFIGURATION = "0f96c167-ebcb-4083-a3e1-60332ca21827";
                    internal const string CONFIGURATION = "Configuración";
                    internal const string DESCRIPTION_CONFIGURATION = "Módulo encargado de las " +
                        "configuraciones del sistema; todo lo que puede ver sólo un súper usuario.";
                    internal const string ICON_CONFIGURATION = "menu-icon tf-icons bx bx-cog";

                    internal const string GUID_DEBT = "62af661b-7686-42db-ac90-8d3e801aded0";
                    internal const string DEBT = "Admin. Deuda";
                    internal const string DESCRIPTION_DEBT = "Módulo encargado de la gestión de " +
                        "deudas.";
                    internal const string ICON_DEBT = "menu-icon tf-icons bx bx-spreadsheet";                    
                }

                internal static class SeedDataProfiles
                {
                    internal const string GUID_PROFILE_SUP_ADM = "aa30317b-e63b-4ac0-bfde-1d97cdb38001";
                    internal const string PROFILE_SUP_ADM = "Súper Administrador";
                    internal const string DESCRIPTION_PROFILE_SUP_ADM = "Perfil encargado del acceso " +
                        "total y toda la configuración del sistema.";

                    internal const string GUID_PROFILE_USER = "cd2b4165-a729-4f24-b218-c60f965cab21";
                    internal const string PROFILE_USER = "Usuario del Sistema";
                    internal const string DESCRIPTION_PROFILE_USER = "Perfil encargado de manejar sus " +
                        "movimientos en cuanto a deudas.";
                }

                internal static class SeedDataSubModules
                {
                    internal const string GUID_LIST_USERS = "2e4ab52e-95f0-4bc8-9273-1083305a5dd1";
                    internal const string LIST_USERS = "Listar usuarios";
                    internal const string DESCRIPTION_LIST_USERS = "Permite listar los usuarios del " +
                        "sistema.";
                    internal const string ROUTER_LINK_LIST_USERS = "list-users";

                    internal const string GUID_LIST_DEBTS = "8dd2ed3e-5d0e-435d-b1bd-b74bafbf8bf1";
                    internal const string LIST_DEBTS = "Listar deudas";
                    internal const string DESCRIPTION_LIST_DEBTS = "Permite la visualización de las " +
                        "deudas de todos los usuarios del sistema.";
                    internal const string ROUTER_LINK_LIST_DEBTS = "list-debts";

                    internal const string GUID_LIST_PAYS = "d66b1448-cbb8-483d-9dc3-9016b3b4c92f";
                    internal const string LIST_PAYS = "Listar pagos";
                    internal const string DESCRIPTION_LIST_PAYS = "Permite la visualización de los " +
                        "pagos o abonos a las deudas de todos los usuarios.";
                    internal const string ROUTER_LINK_LIST_PAYS = "list-pays";

                    internal const string GUID_MANAGE_DEBTS = "1d53feef-eb1a-4b4e-bd7b-163341b8e2fd";
                    internal const string MANAGE_DEBTS = "Gestionar deudas";
                    internal const string DESCRIPTION_MANAGE_DEBTS = "Permite la gestión de las deuda.";
                    internal const string ROUTER_LINK_MANAGE_DEBTS = "manage-debts";
                }

                internal static class SeedDataUsers
                {
                    internal const string GUID_USER_SUP_ADM = "4b6045d7-dc71-42f4-8b32-43cc00cc75fb";
                    internal const string NAMES_USER_SUP_ADM = "User:Names";
                    internal const string LASTNAMES_USER_SUP_ADM = "User:LastNames";
                    internal const string EMAIL_USER_SUP_ADM = "User:Email";
                    internal const string PASSWORD_USER_SUP_ADM = "User:Password";
                }

                internal static class SeedDataModules_SubModules
                {
                    internal const string GUID_CONFIGURATION_LIST_USERS
                        = "ad53c111-7434-4d26-ad12-06276f30687f";

                    internal const string GUID_CONFIGURATION_LIST_DEBTS
                        = "5b2f13a2-8abe-48ef-9fb6-3b2dcafaab6d";

                    internal const string GUID_CONFIGURATION_LIST_PAYS
                        = "b44ecaf8-5a2a-4b53-9d76-ade2a0994703";

                    internal const string GUID_DEBT_MANAGE_DEBTS
                        = "3fdef01b-7f33-4200-a983-beaa96548ee6";
                }

                internal static class SeedDataProfiles_Modules
                {
                    internal const string GUID_PROFILE_SUP_ADM_DASHBOARD
                        = "28c9b1fc-2906-4d3f-9a6a-cbcfc64c727e";

                    internal const string GUID_PROFILE_SUP_ADM_CONFIGURATION
                        = "db9a7883-2dee-4f56-a75e-4b59345b64cd";
                }

                internal static class SeedDataProfiles_SubModules
                {
                    internal const string GUID_PROFILE_SUP_ADM_LIST_USERS
                        = "7455cbac-dbfa-4b70-a093-03529da55eac";

                    internal const string GUID_PROFILE_SUP_ADM_LIST_DEBTS
                        = "7e2be985-11ce-4bba-8ed2-1b233fc8feda";

                    internal const string GUID_PROFILE_SUP_ADM_LIST_PAYS
                        = "e39e75d3-ab07-44c0-b123-2f7c549d9f2a";

                    internal const string GUID_PROFILE_USER_MANAGE_DEBTS
                        = "0b25fea0-a5af-405f-a9ec-73e3609d8630";
                }

                internal static class SeedDataUsers_Profiles
                {
                    internal const string GUID_USER_SUP_ADM_PROFILE_SUP_ADM
                        = "39fa6836-cca2-4507-9629-b45a9f17e9d5";
                }
            }
        }
    }
}