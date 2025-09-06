using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithModulesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Breve nombre alusivo al módulo."),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false, comment: "Descripción del módulo."),
                    Icon = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Ícono para el módulo."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro."),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Fecha de la última modificación sobre el registro."),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Esta propiedad traducida como ¿Está activo? Quiere decir que si el valor es true, es por que si está activo el registro, o sea que el registro no está eliminado, pero si el valor es false, quiere decir que el registro no está activo, o sea, está eliminado.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblModule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    Code = table.Column<byte>(type: "smallint", precision: 3, nullable: false, comment: "Código numérico de identificación única para un registro."),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Breve nombre alusivo al perfil."),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false, comment: "Descripción del perfil."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro."),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Fecha de la última modificación sobre el registro."),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Esta propiedad traducida como ¿Está activo? Quiere decir que si el valor es true, es por que si está activo el registro, o sea que el registro no está eliminado, pero si el valor es false, quiere decir que el registro no está activo, o sea, está eliminado.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblRol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    Code = table.Column<byte>(type: "smallint", precision: 3, nullable: false, comment: "Código numérico de identificación única para un registro."),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Breve nombre alusivo al rol de usuario."),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false, comment: "Descripción del rol de usuario."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro."),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Fecha de la última modificación sobre el registro."),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Esta propiedad traducida como ¿Está activo? Quiere decir que si el valor es true, es por que si está activo el registro, o sea que el registro no está eliminado, pero si el valor es false, quiere decir que el registro no está activo, o sea, está eliminado.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSubModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Breve nombre alusivo al sub módulo."),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false, comment: "Descripción del sub módulo."),
                    RouterLink = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Ruta de apertura del submódulo al hacer clic."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro."),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Fecha de la última modificación sobre el registro."),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Esta propiedad traducida como ¿Está activo? Quiere decir que si el valor es true, es por que si está activo el registro, o sea que el registro no está eliminado, pero si el valor es false, quiere decir que el registro no está activo, o sea, está eliminado.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSubModule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    Names = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Nombres completos del usuario."),
                    LastNames = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Apellidos completos del usuario."),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "Correo electrónico del usuario."),
                    Password = table.Column<string>(name: "´Password", type: "character varying(500)", maxLength: 500, nullable: false, comment: "Contraseña del usuario."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro."),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Fecha de creación del registro."),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Esta propiedad traducida como ¿Está activo? Quiere decir que si el valor es true, es por que si está activo el registro, o sea que el registro no está eliminado, pero si el valor es false, quiere decir que el registro no está activo, o sea, está eliminado.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblProfile_Module",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    IdProfile = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblProfile."),
                    IdModule = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblModule."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProfile_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProfile_Module_TblModule_IdModule",
                        column: x => x.IdModule,
                        principalTable: "TblModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblProfile_Module_TblProfile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "TblProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblModule_SubModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    IdModule = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblModule."),
                    IdSubModule = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblSubModule."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblModule_SubModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblModule_SubModule_TblModule_IdModule",
                        column: x => x.IdModule,
                        principalTable: "TblModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblModule_SubModule_TblSubModule_IdSubModule",
                        column: x => x.IdSubModule,
                        principalTable: "TblSubModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblProfile_SubModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    IdProfile = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblProfile."),
                    IdSubModule = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblSubModule."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProfile_SubModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProfile_SubModule_TblProfile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "TblProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblProfile_SubModule_TblSubModule_IdSubModule",
                        column: x => x.IdSubModule,
                        principalTable: "TblSubModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblMovementDebt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    IdUserDebtor = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblUser."),
                    IdUserCreditor = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblUser."),
                    Amount = table.Column<double>(type: "double precision", nullable: false, comment: "Valor del préstamo acordado entre deudor y creditor."),
                    Difference = table.Column<double>(type: "double precision", nullable: false, comment: "Valor excedente para lograr cubrir toda la deuda del préstamo."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro."),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Fecha de la última modificación sobre el registro."),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, comment: "Esta propiedad traducida como ¿Está activo? Quiere decir que si el valor es true, es por que si está activo el registro, o sea que el registro no está eliminado, pero si el valor es false, quiere decir que el registro no está activo, o sea, está eliminado.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMovementDebt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblMovementDebt_TblUser_IdUserCreditor",
                        column: x => x.IdUserCreditor,
                        principalTable: "TblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMovementDebt_TblUser_IdUserDebtor",
                        column: x => x.IdUserDebtor,
                        principalTable: "TblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblTokenUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    IdUser = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblUser."),
                    Token = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, comment: "Token que manejará la seguridad de muestra y acceso a las interfaces para los usuario, que necesiten seguridad."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro."),
                    ExpireAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de expiración del Token para el usuario, una vez expira, ya no puede ser utilizado para ninguna acción.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTokenUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblTokenUser_TblUser_IdUser",
                        column: x => x.IdUser,
                        principalTable: "TblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUser_Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    IdUser = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblUser."),
                    IdProfile = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblProfile."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUser_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUser_Profile_TblProfile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "TblProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblUser_Profile_TblUser_IdUser",
                        column: x => x.IdUser,
                        principalTable: "TblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUser_Rol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    IdUser = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblUser."),
                    IdRol = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblRol."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUser_Rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUser_Rol_TblRol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "TblRol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblUser_Rol_TblUser_IdUser",
                        column: x => x.IdUser,
                        principalTable: "TblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblMovementDebtMovement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Id autogenerativo para la llave principal de la tabla."),
                    IdDebt = table.Column<Guid>(type: "uuid", nullable: false, comment: "Llave foránea de referencia a la tabla TblMovementDebt."),
                    Amount = table.Column<double>(type: "double precision", nullable: false, comment: "Valor del abono o pago a la deuda."),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Fecha de creación del registro.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMovementDebtMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblMovementDebtMovement_TblMovementDebt_IdDebt",
                        column: x => x.IdDebt,
                        principalTable: "TblMovementDebt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TblModule",
                columns: new[] { "Id", "CreateAt", "Description", "Icon", "IsActive", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("0f96c167-ebcb-4083-a3e1-60332ca21827"), new DateTime(2025, 9, 5, 12, 0, 0, 0, DateTimeKind.Utc), "Módulo encargado de las configuraciones del sistema; todo lo que puede ver sólo un súper usuario.", "menu-icon tf-icons bx bx-cog", true, "Configuración", null },
                    { new Guid("42690d34-5695-4b04-aa50-7c85ee34f18d"), new DateTime(2025, 9, 4, 12, 0, 0, 0, DateTimeKind.Utc), "Dashboard principal del aplicativo. Vista sin ningún componente a bordo.", "menu-icon tf-icons bx bx-home-circle", true, "Dashboard", null },
                    { new Guid("62af661b-7686-42db-ac90-8d3e801aded0"), new DateTime(2025, 9, 6, 12, 0, 0, 0, DateTimeKind.Utc), "Módulo encargado de la gestión de deudas.", "menu-icon tf-icons bx bx-spreadsheet", true, "Admin. Deuda", null }
                });

            migrationBuilder.InsertData(
                table: "TblProfile",
                columns: new[] { "Id", "Code", "CreateAt", "Description", "IsActive", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("aa30317b-e63b-4ac0-bfde-1d97cdb38001"), (byte)1, new DateTime(2025, 9, 4, 12, 0, 0, 0, DateTimeKind.Utc), "Perfil encargado del acceso total y toda la configuración del sistema.", true, "Súper Administrador", null },
                    { new Guid("cd2b4165-a729-4f24-b218-c60f965cab21"), (byte)2, new DateTime(2025, 9, 5, 12, 0, 0, 0, DateTimeKind.Utc), "Perfil encargado de manejar sus movimientos en cuanto a deudas.", true, "Usuario del Sistema", null }
                });

            migrationBuilder.InsertData(
                table: "TblSubModule",
                columns: new[] { "Id", "CreateAt", "Description", "IsActive", "Name", "RouterLink", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1d53feef-eb1a-4b4e-bd7b-163341b8e2fd"), new DateTime(2025, 9, 6, 12, 0, 0, 0, DateTimeKind.Utc), "Permite la gestión de las deuda.", true, "Gestionar deudas", "manage-debts", null },
                    { new Guid("2e4ab52e-95f0-4bc8-9273-1083305a5dd1"), new DateTime(2025, 9, 6, 12, 0, 0, 0, DateTimeKind.Utc), "Permite listar los usuarios del sistema.", true, "Listar usuarios", "list-users", null },
                    { new Guid("8dd2ed3e-5d0e-435d-b1bd-b74bafbf8bf1"), new DateTime(2025, 9, 7, 12, 0, 0, 0, DateTimeKind.Utc), "Permite la visualización de las deudas de todos los usuarios del sistema.", true, "Listar deudas", "list-debts", null },
                    { new Guid("d66b1448-cbb8-483d-9dc3-9016b3b4c92f"), new DateTime(2025, 9, 8, 12, 0, 0, 0, DateTimeKind.Utc), "Permite la visualización de los pagos o abonos a las deudas de todos los usuarios.", true, "Listar pagos", "list-pays", null }
                });

            migrationBuilder.InsertData(
                table: "TblUser",
                columns: new[] { "Id", "CreateAt", "Email", "IsActive", "LastNames", "Names", "´Password", "UpdateAt" },
                values: new object[] { new Guid("4b6045d7-dc71-42f4-8b32-43cc00cc75fb"), new DateTime(2025, 6, 4, 12, 0, 0, 0, DateTimeKind.Utc), "super.admin@superadmin.com.co", true, "Súper Administrador", "Usuario", "wGlDz9tGVWdASYi4y5tmRo9d8whwAkeirODO8ksI3rbiT8ZMoRfTo4WWhhqsKUy5cPDOBu6WL10RgVA+Rwb8ok5J5rbXJN5UF7l38C64s0JHKnXOnshOej54X2wRrSrAY2s1QqPD7dXjXXhemWg=", null });

            migrationBuilder.InsertData(
                table: "TblModule_SubModule",
                columns: new[] { "Id", "CreateAt", "IdModule", "IdSubModule" },
                values: new object[,]
                {
                    { new Guid("3fdef01b-7f33-4200-a983-beaa96548ee6"), new DateTime(2025, 9, 6, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("62af661b-7686-42db-ac90-8d3e801aded0"), new Guid("1d53feef-eb1a-4b4e-bd7b-163341b8e2fd") },
                    { new Guid("5b2f13a2-8abe-48ef-9fb6-3b2dcafaab6d"), new DateTime(2025, 9, 5, 12, 2, 0, 0, DateTimeKind.Utc), new Guid("0f96c167-ebcb-4083-a3e1-60332ca21827"), new Guid("8dd2ed3e-5d0e-435d-b1bd-b74bafbf8bf1") },
                    { new Guid("ad53c111-7434-4d26-ad12-06276f30687f"), new DateTime(2025, 9, 5, 12, 1, 0, 0, DateTimeKind.Utc), new Guid("0f96c167-ebcb-4083-a3e1-60332ca21827"), new Guid("2e4ab52e-95f0-4bc8-9273-1083305a5dd1") },
                    { new Guid("b44ecaf8-5a2a-4b53-9d76-ade2a0994703"), new DateTime(2025, 9, 5, 12, 3, 0, 0, DateTimeKind.Utc), new Guid("0f96c167-ebcb-4083-a3e1-60332ca21827"), new Guid("d66b1448-cbb8-483d-9dc3-9016b3b4c92f") }
                });

            migrationBuilder.InsertData(
                table: "TblProfile_Module",
                columns: new[] { "Id", "CreateAt", "IdModule", "IdProfile" },
                values: new object[,]
                {
                    { new Guid("28c9b1fc-2906-4d3f-9a6a-cbcfc64c727e"), new DateTime(2025, 9, 4, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("42690d34-5695-4b04-aa50-7c85ee34f18d"), new Guid("aa30317b-e63b-4ac0-bfde-1d97cdb38001") },
                    { new Guid("5360c6c3-7bf3-436a-b107-87e767638335"), new DateTime(2025, 9, 5, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("62af661b-7686-42db-ac90-8d3e801aded0"), new Guid("cd2b4165-a729-4f24-b218-c60f965cab21") },
                    { new Guid("5886b671-948b-46b8-9c8b-8e115021f7e1"), new DateTime(2025, 9, 4, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("42690d34-5695-4b04-aa50-7c85ee34f18d"), new Guid("cd2b4165-a729-4f24-b218-c60f965cab21") },
                    { new Guid("db9a7883-2dee-4f56-a75e-4b59345b64cd"), new DateTime(2025, 9, 5, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("0f96c167-ebcb-4083-a3e1-60332ca21827"), new Guid("aa30317b-e63b-4ac0-bfde-1d97cdb38001") }
                });

            migrationBuilder.InsertData(
                table: "TblProfile_SubModule",
                columns: new[] { "Id", "CreateAt", "IdProfile", "IdSubModule" },
                values: new object[,]
                {
                    { new Guid("0b25fea0-a5af-405f-a9ec-73e3609d8630"), new DateTime(2025, 6, 6, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("cd2b4165-a729-4f24-b218-c60f965cab21"), new Guid("1d53feef-eb1a-4b4e-bd7b-163341b8e2fd") },
                    { new Guid("7455cbac-dbfa-4b70-a093-03529da55eac"), new DateTime(2025, 6, 6, 12, 1, 0, 0, DateTimeKind.Utc), new Guid("aa30317b-e63b-4ac0-bfde-1d97cdb38001"), new Guid("2e4ab52e-95f0-4bc8-9273-1083305a5dd1") },
                    { new Guid("7e2be985-11ce-4bba-8ed2-1b233fc8feda"), new DateTime(2025, 6, 5, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("aa30317b-e63b-4ac0-bfde-1d97cdb38001"), new Guid("8dd2ed3e-5d0e-435d-b1bd-b74bafbf8bf1") },
                    { new Guid("e39e75d3-ab07-44c0-b123-2f7c549d9f2a"), new DateTime(2025, 6, 5, 12, 2, 0, 0, DateTimeKind.Utc), new Guid("aa30317b-e63b-4ac0-bfde-1d97cdb38001"), new Guid("d66b1448-cbb8-483d-9dc3-9016b3b4c92f") }
                });

            migrationBuilder.InsertData(
                table: "TblUser_Profile",
                columns: new[] { "Id", "CreateAt", "IdProfile", "IdUser" },
                values: new object[] { new Guid("39fa6836-cca2-4507-9629-b45a9f17e9d5"), new DateTime(2025, 6, 4, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("aa30317b-e63b-4ac0-bfde-1d97cdb38001"), new Guid("4b6045d7-dc71-42f4-8b32-43cc00cc75fb") });

            migrationBuilder.CreateIndex(
                name: "IX_TblModule_Name",
                table: "TblModule",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblModule_SubModule_IdModule",
                table: "TblModule_SubModule",
                column: "IdModule");

            migrationBuilder.CreateIndex(
                name: "IX_TblModule_SubModule_IdSubModule",
                table: "TblModule_SubModule",
                column: "IdSubModule");

            migrationBuilder.CreateIndex(
                name: "IX_TblMovementDebt_IdUserCreditor",
                table: "TblMovementDebt",
                column: "IdUserCreditor");

            migrationBuilder.CreateIndex(
                name: "IX_TblMovementDebt_IdUserDebtor",
                table: "TblMovementDebt",
                column: "IdUserDebtor");

            migrationBuilder.CreateIndex(
                name: "IX_TblMovementDebtMovement_IdDebt",
                table: "TblMovementDebtMovement",
                column: "IdDebt");

            migrationBuilder.CreateIndex(
                name: "IX_TblProfile_Code",
                table: "TblProfile",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblProfile_Name",
                table: "TblProfile",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblProfile_Module_IdModule",
                table: "TblProfile_Module",
                column: "IdModule");

            migrationBuilder.CreateIndex(
                name: "IX_TblProfile_Module_IdProfile",
                table: "TblProfile_Module",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_TblProfile_SubModule_IdProfile",
                table: "TblProfile_SubModule",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_TblProfile_SubModule_IdSubModule",
                table: "TblProfile_SubModule",
                column: "IdSubModule");

            migrationBuilder.CreateIndex(
                name: "IX_TblRol_Code",
                table: "TblRol",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblRol_Name",
                table: "TblRol",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblSubModule_Name",
                table: "TblSubModule",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblTokenUser_IdUser",
                table: "TblTokenUser",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TblTokenUser_Token",
                table: "TblTokenUser",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblUser_Email",
                table: "TblUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblUser_Profile_IdProfile",
                table: "TblUser_Profile",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_TblUser_Profile_IdUser",
                table: "TblUser_Profile",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TblUser_Rol_IdRol",
                table: "TblUser_Rol",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_TblUser_Rol_IdUser",
                table: "TblUser_Rol",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblModule_SubModule");

            migrationBuilder.DropTable(
                name: "TblMovementDebtMovement");

            migrationBuilder.DropTable(
                name: "TblProfile_Module");

            migrationBuilder.DropTable(
                name: "TblProfile_SubModule");

            migrationBuilder.DropTable(
                name: "TblTokenUser");

            migrationBuilder.DropTable(
                name: "TblUser_Profile");

            migrationBuilder.DropTable(
                name: "TblUser_Rol");

            migrationBuilder.DropTable(
                name: "TblMovementDebt");

            migrationBuilder.DropTable(
                name: "TblModule");

            migrationBuilder.DropTable(
                name: "TblSubModule");

            migrationBuilder.DropTable(
                name: "TblProfile");

            migrationBuilder.DropTable(
                name: "TblRol");

            migrationBuilder.DropTable(
                name: "TblUser");
        }
    }
}
