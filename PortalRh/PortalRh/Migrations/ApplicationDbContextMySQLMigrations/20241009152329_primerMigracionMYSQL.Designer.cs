﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalRh.Data;

#nullable disable

namespace PortalRh.Migrations.ApplicationDbContextMySQLMigrations
{
    [DbContext(typeof(ApplicationDbContextMySQL))]
    [Migration("20241009152329_primerMigracionMYSQL")]
    partial class primerMigracionMYSQL
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PortalRh.Models.Expediente", b =>
                {
                    b.Property<string>("ExpedienteID")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CURP")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18)");

                    b.Property<string>("Calle")
                        .HasColumnType("longtext");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CodigoPostal")
                        .HasColumnType("longtext");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaValidacionRFC")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("GradoEstudios")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GrupoSanguineo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Localidad")
                        .HasColumnType("longtext");

                    b.Property<string>("Municipio")
                        .HasColumnType("longtext");

                    b.Property<string>("NSS")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroExterior")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroInterior")
                        .HasColumnType("longtext");

                    b.Property<string>("OtroEmpleo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RFC")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ExpedienteID");

                    b.ToTable("Expedientes");
                });

            modelBuilder.Entity("PortalRh.Models.FonacotReportModel", b =>
                {
                    b.Property<decimal>("IMPORTE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NOMBRE")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RFC")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("SDO_BASE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TIPO")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("fonacotReportsModels");
                });

            modelBuilder.Entity("PortalRh.Models.FovissteReportModel", b =>
                {
                    b.Property<decimal>("FOVISSSTE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FOVISSSTE_CF")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NOMBRE")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RFC")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("SDO_BASE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SDO_HON")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SEGURO_DE_DANOS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TIPO")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("fovissteReportModels");
                });

            modelBuilder.Entity("PortalRh.Models.LineaModel", b =>
                {
                    b.Property<string>("Linea")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("lineaModels");
                });

            modelBuilder.Entity("PortalRh.Models.PartidasModel", b =>
                {
                    b.Property<decimal>("Partida11301")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida11302")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida12101")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida13101")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida13102")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida13103")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida13201")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida13202")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida13204")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida1401")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida14201")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida14301")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida14401")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15301")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15401")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15402")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15404")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15405")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15406")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15408")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15409")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15501")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15502")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15901")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15902")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida15903")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida17101")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida17102")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Partida1711")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("partidasModels");
                });

            modelBuilder.Entity("PortalRh.Models.SatIdData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Colonia")
                        .HasColumnType("longtext");

                    b.Property<string>("Curp")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EntidadFederativa")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("FechaAlta")
                        .HasColumnType("date");

                    b.Property<string>("IdCif")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("LastUpdateSat")
                        .HasColumnType("date");

                    b.Property<string>("Municipio")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NombreVialidad")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroExterior")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroInterior")
                        .HasColumnType("longtext");

                    b.Property<string>("RegimenFiscal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rfc")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("SituacionContribuyente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoVialidad")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SatId");
                });

            modelBuilder.Entity("PortalRh.Models.SericaDetalleReporteModel", b =>
                {
                    b.Property<string>("APE_MAT")
                        .HasColumnType("longtext");

                    b.Property<string>("APE_PAT")
                        .HasColumnType("longtext");

                    b.Property<decimal>("CHC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CONCEPTO_10001")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_10002")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_11301")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_13102")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_15402")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_15403")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_20001")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_20002")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_20005")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_20006")
                        .HasColumnType("longtext");

                    b.Property<string>("CONCEPTO_20007")
                        .HasColumnType("longtext");

                    b.Property<string>("CP12201")
                        .HasColumnType("longtext");

                    b.Property<string>("CP12301")
                        .HasColumnType("longtext");

                    b.Property<string>("CP13101")
                        .HasColumnType("longtext");

                    b.Property<string>("CP20003")
                        .HasColumnType("longtext");

                    b.Property<string>("CP20004")
                        .HasColumnType("longtext");

                    b.Property<string>("CP20008")
                        .HasColumnType("longtext");

                    b.Property<string>("CURP")
                        .HasColumnType("longtext");

                    b.Property<decimal>("DESPENSA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ICP13401")
                        .HasColumnType("longtext");

                    b.Property<string>("ICP13402")
                        .HasColumnType("longtext");

                    b.Property<string>("ICP13407")
                        .HasColumnType("longtext");

                    b.Property<string>("ICP13408")
                        .HasColumnType("longtext");

                    b.Property<string>("ICP13411")
                        .HasColumnType("longtext");

                    b.Property<string>("IM12201")
                        .HasColumnType("longtext");

                    b.Property<string>("IM12301")
                        .HasColumnType("longtext");

                    b.Property<string>("IM13101")
                        .HasColumnType("longtext");

                    b.Property<string>("IM13401")
                        .HasColumnType("longtext");

                    b.Property<string>("IM13402")
                        .HasColumnType("longtext");

                    b.Property<string>("IM13407")
                        .HasColumnType("longtext");

                    b.Property<string>("IM13408")
                        .HasColumnType("longtext");

                    b.Property<string>("IM13411")
                        .HasColumnType("longtext");

                    b.Property<string>("IM20003")
                        .HasColumnType("longtext");

                    b.Property<string>("IM20004")
                        .HasColumnType("longtext");

                    b.Property<string>("IM20008")
                        .HasColumnType("longtext");

                    b.Property<decimal>("IMPORTE_10001")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_10002")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_11301")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_13102")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_15402")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_15403")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_20001")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_20002")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_20005")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_20006")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_20007")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("IPT13401")
                        .HasColumnType("longtext");

                    b.Property<string>("IPT13402")
                        .HasColumnType("longtext");

                    b.Property<string>("IPT13407")
                        .HasColumnType("longtext");

                    b.Property<string>("IPT13408")
                        .HasColumnType("longtext");

                    b.Property<string>("IPT13411")
                        .HasColumnType("longtext");

                    b.Property<string>("NOMBRE")
                        .HasColumnType("longtext");

                    b.Property<string>("NO_EMPLE")
                        .HasColumnType("longtext");

                    b.Property<string>("NSS")
                        .HasColumnType("longtext");

                    b.Property<string>("NUM_CHEQ")
                        .HasColumnType("longtext");

                    b.Property<string>("PAGADURIA")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_10001")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_10002")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_11301")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_13102")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_15402")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_15403")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_20001")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_20002")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_20005")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_20006")
                        .HasColumnType("longtext");

                    b.Property<string>("PARTIDA_20007")
                        .HasColumnType("longtext");

                    b.Property<decimal>("PENSION")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PRESTAMOS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PT12201")
                        .HasColumnType("longtext");

                    b.Property<string>("PT12301")
                        .HasColumnType("longtext");

                    b.Property<string>("PT13101")
                        .HasColumnType("longtext");

                    b.Property<string>("PT20003")
                        .HasColumnType("longtext");

                    b.Property<string>("PT20004")
                        .HasColumnType("longtext");

                    b.Property<string>("PT20008")
                        .HasColumnType("longtext");

                    b.Property<int?>("REGIMEN_ISSSTE")
                        .HasColumnType("int");

                    b.Property<string>("RFC")
                        .HasColumnType("longtext");

                    b.Property<decimal>("SDO_ISS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SEXO")
                        .HasColumnType("longtext");

                    b.Property<string>("TI")
                        .HasColumnType("longtext");

                    b.Property<int?>("TIPO_CONTRATO")
                        .HasColumnType("int");

                    b.Property<decimal>("TOT_DEDU")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TOT_DEDU1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TOT_NETO")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TOT_PERC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .HasColumnType("longtext");

                    b.ToTable("sericaDetalleReporteModels");
                });

            modelBuilder.Entity("PortalRh.Models.SericaHeaderModel", b =>
                {
                    b.Property<decimal>("CHC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ENC0")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ENC1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ENC2")
                        .HasColumnType("int");

                    b.Property<string>("FechaPago")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("IM12201")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IM12301")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IM13101")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IM13401")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IM13402")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IM13407")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IM13408")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IM13411")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_11301")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_13102")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_15402")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IMPORTE_15403")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TI")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TOT_PERC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ade_medico")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("despensa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("faltas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("pension")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("prestamos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("retardos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("superissste")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("tot_dedu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("tot_neto")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("sericaReporteModels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
