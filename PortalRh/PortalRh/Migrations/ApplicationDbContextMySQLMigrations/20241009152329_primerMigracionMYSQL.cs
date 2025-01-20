using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace PortalRh.Migrations.ApplicationDbContextMySQLMigrations
{
    /// <inheritdoc />
    public partial class primerMigracionMYSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    ExpedienteID = table.Column<string>(type: "varchar(255)", nullable: false),
                    CURP = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    RFC = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    FechaValidacionRFC = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "longtext", nullable: false),
                    SegundoApellido = table.Column<string>(type: "longtext", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: true),
                    Municipio = table.Column<string>(type: "longtext", nullable: true),
                    Localidad = table.Column<string>(type: "longtext", nullable: true),
                    Calle = table.Column<string>(type: "longtext", nullable: true),
                    NumeroExterior = table.Column<string>(type: "longtext", nullable: true),
                    NumeroInterior = table.Column<string>(type: "longtext", nullable: true),
                    CodigoPostal = table.Column<string>(type: "longtext", nullable: true),
                    Telefono = table.Column<string>(type: "longtext", nullable: false),
                    Celular = table.Column<string>(type: "longtext", nullable: false),
                    Correo = table.Column<string>(type: "longtext", nullable: false),
                    NSS = table.Column<string>(type: "longtext", nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "longtext", nullable: false),
                    GradoEstudios = table.Column<string>(type: "longtext", nullable: false),
                    OtroEmpleo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.ExpedienteID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fonacotReportsModels",
                columns: table => new
                {
                    TIPO = table.Column<string>(type: "longtext", nullable: false),
                    RFC = table.Column<string>(type: "longtext", nullable: false),
                    NOMBRE = table.Column<string>(type: "longtext", nullable: false),
                    SDO_BASE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMPORTE = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fovissteReportModels",
                columns: table => new
                {
                    TIPO = table.Column<string>(type: "longtext", nullable: false),
                    NOMBRE = table.Column<string>(type: "longtext", nullable: false),
                    RFC = table.Column<string>(type: "longtext", nullable: false),
                    SDO_BASE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FOVISSSTE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SEGURO_DE_DANOS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FOVISSSTE_CF = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SDO_HON = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "lineaModels",
                columns: table => new
                {
                    Linea = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "partidasModels",
                columns: table => new
                {
                    Partida11301 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida11302 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida12101 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida13101 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida13102 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida13103 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida13201 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida13202 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida13204 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida1401 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida14201 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida14301 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida14401 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15301 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15401 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15402 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15404 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15405 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15406 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15408 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15409 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15501 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15502 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15901 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15902 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida15903 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida17101 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida17102 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Partida1711 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SatId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdCif = table.Column<string>(type: "longtext", nullable: true),
                    Rfc = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Curp = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Apellido1 = table.Column<string>(type: "longtext", nullable: false),
                    Apellido2 = table.Column<string>(type: "longtext", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    SituacionContribuyente = table.Column<string>(type: "longtext", nullable: false),
                    LastUpdateSat = table.Column<DateOnly>(type: "date", nullable: false),
                    RegimenFiscal = table.Column<string>(type: "longtext", nullable: false),
                    FechaAlta = table.Column<DateOnly>(type: "date", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    EntidadFederativa = table.Column<string>(type: "longtext", nullable: true),
                    Municipio = table.Column<string>(type: "longtext", nullable: true),
                    Colonia = table.Column<string>(type: "longtext", nullable: true),
                    TipoVialidad = table.Column<string>(type: "longtext", nullable: true),
                    NombreVialidad = table.Column<string>(type: "longtext", nullable: true),
                    NumeroExterior = table.Column<string>(type: "longtext", nullable: true),
                    NumeroInterior = table.Column<string>(type: "longtext", nullable: true),
                    CodigoPostal = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatId", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sericaDetalleReporteModels",
                columns: table => new
                {
                    TI = table.Column<string>(type: "longtext", nullable: true),
                    NSS = table.Column<string>(type: "longtext", nullable: true),
                    NOMBRE = table.Column<string>(type: "longtext", nullable: true),
                    APE_PAT = table.Column<string>(type: "longtext", nullable: true),
                    APE_MAT = table.Column<string>(type: "longtext", nullable: true),
                    RFC = table.Column<string>(type: "longtext", nullable: true),
                    CURP = table.Column<string>(type: "longtext", nullable: true),
                    SEXO = table.Column<string>(type: "longtext", nullable: true),
                    PAGADURIA = table.Column<string>(type: "longtext", nullable: true),
                    NO_EMPLE = table.Column<string>(type: "longtext", nullable: true),
                    NUM_CHEQ = table.Column<string>(type: "longtext", nullable: true),
                    REGIMEN_ISSSTE = table.Column<int>(type: "int", nullable: true),
                    TIPO_CONTRATO = table.Column<int>(type: "int", nullable: true),
                    TOT_PERC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOT_DEDU = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PARTIDA_11301 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_11301 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_11301 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PT12201 = table.Column<string>(type: "longtext", nullable: true),
                    CP12201 = table.Column<string>(type: "longtext", nullable: true),
                    IM12201 = table.Column<string>(type: "longtext", nullable: true),
                    PT12301 = table.Column<string>(type: "longtext", nullable: true),
                    CP12301 = table.Column<string>(type: "longtext", nullable: true),
                    IM12301 = table.Column<string>(type: "longtext", nullable: true),
                    PT13101 = table.Column<string>(type: "longtext", nullable: true),
                    CP13101 = table.Column<string>(type: "longtext", nullable: true),
                    IM13101 = table.Column<string>(type: "longtext", nullable: true),
                    PARTIDA_13102 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_13102 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_13102 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IPT13401 = table.Column<string>(type: "longtext", nullable: true),
                    ICP13401 = table.Column<string>(type: "longtext", nullable: true),
                    IM13401 = table.Column<string>(type: "longtext", nullable: true),
                    IPT13402 = table.Column<string>(type: "longtext", nullable: true),
                    ICP13402 = table.Column<string>(type: "longtext", nullable: true),
                    IM13402 = table.Column<string>(type: "longtext", nullable: true),
                    IPT13407 = table.Column<string>(type: "longtext", nullable: true),
                    ICP13407 = table.Column<string>(type: "longtext", nullable: true),
                    IM13407 = table.Column<string>(type: "longtext", nullable: true),
                    IPT13408 = table.Column<string>(type: "longtext", nullable: true),
                    ICP13408 = table.Column<string>(type: "longtext", nullable: true),
                    IM13408 = table.Column<string>(type: "longtext", nullable: true),
                    IPT13411 = table.Column<string>(type: "longtext", nullable: true),
                    ICP13411 = table.Column<string>(type: "longtext", nullable: true),
                    IM13411 = table.Column<string>(type: "longtext", nullable: true),
                    PARTIDA_15403 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_15403 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_15403 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PARTIDA_15402 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_15402 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_15402 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PARTIDA_10001 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_10001 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_10001 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PARTIDA_10002 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_10002 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_10002 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PARTIDA_20001 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_20001 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_20001 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PARTIDA_20002 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_20002 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_20002 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PT20003 = table.Column<string>(type: "longtext", nullable: true),
                    CP20003 = table.Column<string>(type: "longtext", nullable: true),
                    IM20003 = table.Column<string>(type: "longtext", nullable: true),
                    PT20004 = table.Column<string>(type: "longtext", nullable: true),
                    CP20004 = table.Column<string>(type: "longtext", nullable: true),
                    IM20004 = table.Column<string>(type: "longtext", nullable: true),
                    PARTIDA_20005 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_20005 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_20005 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PARTIDA_20006 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_20006 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_20006 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PARTIDA_20007 = table.Column<string>(type: "longtext", nullable: true),
                    CONCEPTO_20007 = table.Column<string>(type: "longtext", nullable: true),
                    IMPORTE_20007 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PT20008 = table.Column<string>(type: "longtext", nullable: true),
                    CP20008 = table.Column<string>(type: "longtext", nullable: true),
                    IM20008 = table.Column<string>(type: "longtext", nullable: true),
                    TOT_NETO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SDO_ISS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DESPENSA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRESTAMOS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CHC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PENSION = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: true),
                    TOT_DEDU1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sericaReporteModels",
                columns: table => new
                {
                    TI = table.Column<string>(type: "longtext", nullable: false),
                    ENC0 = table.Column<string>(type: "longtext", nullable: false),
                    FechaPago = table.Column<string>(type: "longtext", nullable: false),
                    ENC1 = table.Column<string>(type: "longtext", nullable: false),
                    ENC2 = table.Column<int>(type: "int", nullable: false),
                    IMPORTE_11301 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IM12201 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IM12301 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IM13101 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMPORTE_13102 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IM13401 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IM13402 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IM13407 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IM13408 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IM13411 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMPORTE_15403 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IMPORTE_15402 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    despensa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    prestamos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    superissste = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ade_medico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CHC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pension = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    faltas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    retardos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOT_PERC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tot_dedu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tot_neto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Expedientes");

            migrationBuilder.DropTable(
                name: "fonacotReportsModels");

            migrationBuilder.DropTable(
                name: "fovissteReportModels");

            migrationBuilder.DropTable(
                name: "lineaModels");

            migrationBuilder.DropTable(
                name: "partidasModels");

            migrationBuilder.DropTable(
                name: "SatId");

            migrationBuilder.DropTable(
                name: "sericaDetalleReporteModels");

            migrationBuilder.DropTable(
                name: "sericaReporteModels");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
