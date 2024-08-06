using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalRh.Migrations
{
    /// <inheritdoc />
    public partial class aceptanull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumeroInterior",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroExterior",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Municipio",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Localidad",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostal",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Calle",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SatId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rfc = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Curp = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    SituacionContribuyente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateSat = table.Column<DateOnly>(type: "date", nullable: false),
                    RegimenFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateOnly>(type: "date", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadFederativa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoVialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreVialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroExterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroInterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatId", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SatId");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroInterior",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroExterior",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Municipio",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Localidad",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostal",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Calle",
                table: "Expedientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
