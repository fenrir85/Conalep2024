using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
using PortalRh.Data;
using PortalRh.Models;
using System.Data;
namespace PortalRh.Repository
{
    public class RepositoryMySQL : IrepositoryMySQL
    {
        private readonly ApplicationDbContextMySQL _contexto2;
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public RepositoryMySQL(ApplicationDbContextMySQL context, IConfiguration configuration)
        {
            _contexto2 = context;
            _connectionString = configuration.GetConnectionString("MysqlConnection");
        }

        public async Task<List<RegNominasInfo>> GetRegNominasInfoAsync()
        {
            var result = new List<RegNominasInfo>();
            var connectionString = _connectionString;
         
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand("GetRegNominasInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new RegNominasInfo
                            {
                                Info = reader.GetString("Info")
                            });
                        }
                    }
                }
            }

            return result;
        }
        public async Task<List<reg_nominas>> GetRegNominasDBTableAsync()
        {
            var connectionString = _connectionString;
            var result = new List<reg_nominas>();
      
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
             
                using (var command = new MySqlCommand("GetRegNominasDBTable", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new reg_nominas
                            {
                                DbTable = reader.GetString("DbTable")
                            });
                        }
                    }
                }
            }

            return result;
        }
      
        public async Task<List<SericaHeaderModel>> GetHeaderSericaPrestamoAsync(string tabla)
        {
            var connectionString = _connectionString;
            var result = new List<SericaHeaderModel>();
         
            using (var connection = new MySqlConnection(connectionString))
            
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand("GetHeaderSericaPrestamo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tabla", tabla);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new SericaHeaderModel
                            {
                                ENC0 = reader.GetString("ENC0"),
                                FechaPago = reader.GetString("FechaPago"),
                                ENC1 = reader.GetString("ENC1"),
                                ENC2 = reader.GetInt32("ENC2"),
                                IMPORTE_11301 = reader.GetDecimal("IMPORTE_11301"),
                                IM12201 = reader.GetInt32("IM12201"),
                                IM12301 = reader.GetInt32("IM12301"),
                                IM13101 = reader.GetInt32("IM13101"),
                                IMPORTE_13102 = reader.GetDecimal("IMPORTE_13102"),
                                IM13401 = reader.GetInt32("IM13401"),
                                IM13402 = reader.GetInt32("IM13402"),
                                IM13407 = reader.GetInt32("IM13407"),
                                IM13408 = reader.GetDecimal("IM13408"),
                                IM13411 = reader.GetDecimal("IM13411"),
                                IMPORTE_15403 = reader.GetDecimal("IMPORTE_15403"),
                                IMPORTE_15402 = reader.GetDecimal("IMPORTE_15402"),
                                despensa = reader.GetDecimal("despensa"),
                                prestamos = reader.GetDecimal("prestamos"),
                                superissste = reader.GetDecimal("superissste"),
                                ade_medico = reader.GetDecimal("ade_medico"),
                                CHC = reader.GetDecimal("CHC"),
                                pension = reader.GetDecimal("pension"),
                                faltas = reader.GetDecimal("faltas"),
                                retardos = reader.GetDecimal("retardos"),
                                TOT_PERC = reader.GetDecimal("TOT_PERC"),
                                tot_dedu = reader.GetDecimal("tot_dedu"),
                                tot_neto = reader.GetDecimal("tot_neto")
                            });
                        }
                    }
                }
            }

            return result;
        }

        public async Task<List<SericaDetalleReporteModel>> GetSericaPrestamoAsync(string tabla)
        {
            var connectionString = _connectionString;
            var result = new List<SericaDetalleReporteModel>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

          
                using (var command = new MySqlCommand("GetSericaPrestamos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tabla", tabla);
                    command.Parameters.AddWithValue("@sueldo", "sueldo");
         
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {

                                result.Add(new SericaDetalleReporteModel
                                {
                                    TI = reader.GetString("TI"),
                                    NSS = reader.IsDBNull("NSS") ? string.Empty : reader.GetString("NSS"),
                                    NOMBRE = reader.IsDBNull("NOMBRE") ? string.Empty : reader.GetString("NOMBRE"),
                                    APE_PAT = reader.IsDBNull("APE_PAT") ? string.Empty : reader.GetString("APE_PAT"),
                                    APE_MAT = reader.IsDBNull("APE_MAT") ? string.Empty : reader.GetString("APE_MAT"),
                                    RFC = reader.IsDBNull("RFC") ? string.Empty : reader.GetString("RFC"),
                                    CURP = reader.IsDBNull("CURP") ? string.Empty : reader.GetString("CURP"),
                                    SEXO = reader.IsDBNull("SEXO") ? string.Empty : reader.GetString("SEXO"),
                                    PAGADURIA = reader.IsDBNull("PAGADURIA") ? string.Empty : reader.GetString("PAGADURIA"),
                                    NO_EMPLE = reader.IsDBNull("NO_EMPLE") ? string.Empty : reader.GetString("NO_EMPLE"),
                                    NUM_CHEQ = reader.IsDBNull("NUM_CHEQ") ? string.Empty : reader.GetString("NUM_CHEQ"),
                                    REGIMEN_ISSSTE = reader.IsDBNull("REGIMEN_ISSSTE") ? (int?)null : reader.GetInt32("REGIMEN_ISSSTE"),
                                    TIPO_CONTRATO = reader.IsDBNull("TIPO_CONTRATO") ? (int?)null : reader.GetInt32("TIPO_CONTRATO"),
                                    TOT_PERC = (decimal)(reader.IsDBNull("TOT_PERC") ? (decimal?)null : reader.GetDecimal("TOT_PERC")),
                                    TOT_DEDU = (decimal)(reader.IsDBNull("TOT_DEDU") ? (decimal?)null : reader.GetDecimal("TOT_DEDU")),
                                    PARTIDA_11301 = reader.IsDBNull("PARTIDA_11301") ? string.Empty : reader.GetString("PARTIDA_11301"),
                                    CONCEPTO_11301 = reader.IsDBNull("CONCEPTO_11301") ? string.Empty : reader.GetString("CONCEPTO_11301"),
                                    IMPORTE_11301 = (decimal)(reader.IsDBNull("IMPORTE_11301") ? (decimal?)null : reader.GetDecimal("IMPORTE_11301")),
                                    PT12201 = reader.IsDBNull("PT12201") ? string.Empty : reader.GetString("PT12201"),
                                    CP12201 = reader.IsDBNull("CP12201") ? string.Empty : reader.GetString("CP12201"),
                                    IM12201 = reader.IsDBNull("IM12201") ? string.Empty : reader.GetString("IM12201"),
                                    PT12301 = reader.IsDBNull("PT12301") ? string.Empty : reader.GetString("PT12301"),
                                    CP12301 = reader.IsDBNull("CP12301") ? string.Empty : reader.GetString("CP12301"),
                                    IM12301 = reader.IsDBNull("IM12301") ? string.Empty : reader.GetString("IM12301"),
                                    PT13101 = reader.IsDBNull("PT13101") ? string.Empty : reader.GetString("PT13101"),
                                    CP13101 = reader.IsDBNull("CP13101") ? string.Empty : reader.GetString("CP13101"),
                                    IM13101 = reader.IsDBNull("IM13101") ? string.Empty : reader.GetString("IM13101"),
                                    PARTIDA_13102 = reader.IsDBNull("PARTIDA_13102") ? string.Empty : reader.GetString("PARTIDA_13102"),
                                    CONCEPTO_13102 = reader.IsDBNull("CONCEPTO_13102") ? string.Empty : reader.GetString("CONCEPTO_13102"),
                                    IMPORTE_13102 = (decimal)(reader.IsDBNull("IMPORTE_13102") ? (decimal?)null : reader.GetDecimal("IMPORTE_13102")),
                                    IPT13401 = reader.IsDBNull("IPT13401") ? string.Empty : reader.GetString("IPT13401"),
                                    ICP13401 = reader.IsDBNull("ICP13401") ? string.Empty : reader.GetString("ICP13401"),
                                    IM13401 = reader.IsDBNull("IM13401") ? string.Empty : reader.GetString("IM13401"),
                                    IPT13402 = reader.IsDBNull("IPT13402") ? string.Empty : reader.GetString("IPT13402"),
                                    ICP13402 = reader.IsDBNull("ICP13402") ? string.Empty : reader.GetString("ICP13402"),
                                    IM13402 = reader.IsDBNull("IM13402") ? string.Empty : reader.GetString("IM13402"),
                                    IPT13407 = reader.IsDBNull("IPT13407") ? string.Empty : reader.GetString("IPT13407"),
                                    ICP13407 = reader.IsDBNull("ICP13407") ? string.Empty : reader.GetString("ICP13407"),
                                    IM13407 = reader.IsDBNull("IM13407") ? string.Empty : reader.GetString("IM13407"),
                                    IPT13408 = reader.IsDBNull("IPT13408") ? string.Empty : reader.GetString("IPT13408"),
                                    ICP13408 = reader.IsDBNull("ICP13408") ? string.Empty : reader.GetString("ICP13408"),
                                    IM13408 = reader.IsDBNull("IM13408") ? string.Empty : reader.GetString("IM13408"),
                                    IPT13411 = reader.IsDBNull("IPT13411") ? string.Empty : reader.GetString("IPT13411"),
                                    ICP13411 = reader.IsDBNull("ICP13411") ? string.Empty : reader.GetString("ICP13411"),
                                    IM13411 = reader.IsDBNull("IM13411") ? string.Empty : reader.GetString("IM13411"),
                                    PARTIDA_15403 = reader.IsDBNull("PARTIDA_15403") ? string.Empty : reader.GetString("PARTIDA_15403"),
                                    CONCEPTO_15403 = reader.IsDBNull("CONCEPTO_15403") ? string.Empty : reader.GetString("CONCEPTO_15403"),
                                    IMPORTE_15403 = (decimal)(reader.IsDBNull("IMPORTE_15403") ? (decimal?)null : reader.GetDecimal("IMPORTE_15403")),
                                    PARTIDA_15402 = reader.IsDBNull("PARTIDA_15402") ? string.Empty : reader.GetString("PARTIDA_15402"),
                                    CONCEPTO_15402 = reader.IsDBNull("CONCEPTO_15402") ? string.Empty : reader.GetString("CONCEPTO_15402"),
                                    IMPORTE_15402 = (decimal)(reader.IsDBNull("IMPORTE_15402") ? (decimal?)null : reader.GetDecimal("IMPORTE_15402")),
                                    PARTIDA_10001 = reader.IsDBNull("PARTIDA_10001") ? string.Empty : reader.GetString("PARTIDA_10001"),
                                    CONCEPTO_10001 = reader.IsDBNull("CONCEPTO_10001") ? string.Empty : reader.GetString("CONCEPTO_10001"),
                                    IMPORTE_10001 = (decimal)(reader.IsDBNull("IMPORTE_10001") ? (decimal?)null : reader.GetDecimal("IMPORTE_10001")),
                                    PARTIDA_10002 = reader.IsDBNull("PARTIDA_10002") ? string.Empty : reader.GetString("PARTIDA_10002"),
                                    CONCEPTO_10002 = reader.IsDBNull("CONCEPTO_10002") ? string.Empty : reader.GetString("CONCEPTO_10002"),
                                    IMPORTE_10002 = (decimal)(reader.IsDBNull("IMPORTE_10002") ? (decimal?)null : reader.GetDecimal("IMPORTE_10002")),
                                    PARTIDA_20001 = reader.IsDBNull("PARTIDA_20001") ? string.Empty : reader.GetString("PARTIDA_20001"),
                                    CONCEPTO_20001 = reader.IsDBNull("CONCEPTO_20001") ? string.Empty : reader.GetString("CONCEPTO_20001"),
                                    IMPORTE_20001 = (decimal)(reader.IsDBNull("IMPORTE_20001") ? (decimal?)null : reader.GetDecimal("IMPORTE_20001")),
                                    PARTIDA_20002 = reader.IsDBNull("PARTIDA_20002") ? string.Empty : reader.GetString("PARTIDA_20002"),
                                    CONCEPTO_20002 = reader.IsDBNull("CONCEPTO_20002") ? string.Empty : reader.GetString("CONCEPTO_20002"),
                                    IMPORTE_20002 = (decimal)(reader.IsDBNull("IMPORTE_20002") ? (decimal?)null : reader.GetDecimal("IMPORTE_20002")),
                                    PT20003 = reader.IsDBNull("PT20003") ? string.Empty : reader.GetString("PT20003"),
                                    CP20003 = reader.IsDBNull("CP20003") ? string.Empty : reader.GetString("CP20003"),
                                    IM20003 = reader.IsDBNull("IM20003") ? string.Empty : reader.GetString("IM20003"),
                                    PT20004 = reader.IsDBNull("PT20004") ? string.Empty : reader.GetString("PT20004"),
                                    CP20004 = reader.IsDBNull("CP20004") ? string.Empty : reader.GetString("CP20004"),
                                    IM20004 = reader.IsDBNull("IM20004") ? string.Empty : reader.GetString("IM20004"),
                                    PARTIDA_20005 = reader.IsDBNull("PARTIDA_20005") ? string.Empty : reader.GetString("PARTIDA_20005"),
                                    CONCEPTO_20005 = reader.IsDBNull("CONCEPTO_20005") ? string.Empty : reader.GetString("CONCEPTO_20005"),
                                    IMPORTE_20005 = (decimal)(reader.IsDBNull("IMPORTE_20005") ? (decimal?)null : reader.GetDecimal("IMPORTE_20005")),
                                    PARTIDA_20006 = reader.IsDBNull("PARTIDA_20006") ? string.Empty : reader.GetString("PARTIDA_20006"),
                                    CONCEPTO_20006 = reader.IsDBNull("CONCEPTO_20006") ? string.Empty : reader.GetString("CONCEPTO_20006"),
                                    IMPORTE_20006 = (decimal)(reader.IsDBNull("IMPORTE_20006") ? (decimal?)null : reader.GetDecimal("IMPORTE_20006")),
                                    PARTIDA_20007 = reader.IsDBNull("PARTIDA_20007") ? string.Empty : reader.GetString("PARTIDA_20007"),
                                    CONCEPTO_20007 = reader.IsDBNull("CONCEPTO_20007") ? string.Empty : reader.GetString("CONCEPTO_20007"),
                                    IMPORTE_20007 = (decimal)(reader.IsDBNull("IMPORTE_20007") ? (decimal?)null : reader.GetDecimal("IMPORTE_20007")),
                                    PT20008 = reader.IsDBNull("PT20008") ? string.Empty : reader.GetString("PT20008"),
                                    CP20008 = reader.IsDBNull("CP20008") ? string.Empty : reader.GetString("CP20008"),
                                    IM20008 = reader.IsDBNull("IM20008") ? string.Empty : reader.GetString("IM20008"),
                                    TOT_NETO = (decimal)(reader.IsDBNull("TOT_NETO") ? (decimal?)null : reader.GetDecimal("TOT_NETO")),
                                    SDO_ISS = (decimal)(reader.IsDBNull("SDO_ISS") ? (decimal?)null : reader.GetDecimal("SDO_ISS")),
                                    DESPENSA = (decimal)(reader.IsDBNull("DESPENSA") ? (decimal?)null : reader.GetDecimal("DESPENSA")),
                                    PRESTAMOS = (decimal)(reader.IsDBNull("PRESTAMOS") ? (decimal?)null : reader.GetDecimal("PRESTAMOS")),
                                    CHC = (decimal)(reader.IsDBNull("CHC") ? (decimal?)null : reader.GetDecimal("CHC")),
                                    PENSION = (decimal)(reader.IsDBNull("PENSION") ? (decimal?)null : reader.GetDecimal("PENSION")),
                                    Tipo= reader.GetString("Tipo"),
                                });

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }
            return result;
        }
     
        public async Task<List<SericaHeaderModel>> GetHeaderSericaSinPrestamo(string tabla)
        {
            var connectionString = _connectionString;
            var result = new List<SericaHeaderModel>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand("GetHeaderSericaSinPrestamos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tabla", tabla);
                    command.Parameters.AddWithValue("@sueldo", "sueldo");

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {

                                result.Add(new SericaHeaderModel
                                {
                                    
                                    ENC0 = reader.GetString("ENC0"),
                                    FechaPago = reader.GetString("FechaPago"),
                                    ENC1 = reader.GetString("ENC1"),
                                    ENC2 = reader.GetInt32("ENC2"),
                                    IMPORTE_11301 = reader.GetDecimal("IMPORTE_11301"),
                                    IM12201 = reader.GetInt32("IM12201"),
                                    IM12301 = reader.GetInt32("IM12301"),
                                    IM13101 = reader.GetInt32("IM13101"),
                                    IMPORTE_13102 = reader.GetDecimal("IMPORTE_13102"),
                                    IM13401 = reader.GetInt32("IM13401"),
                                    IM13402 = reader.GetInt32("IM13402"),
                                    IM13407 = reader.GetInt32("IM13407"),
                                    IM13408 = reader.GetDecimal("IM13408"),
                                    IM13411 = reader.GetDecimal("IM13411"),
                                    IMPORTE_15403 = reader.GetDecimal("IMPORTE_15403"),
                                    IMPORTE_15402 = reader.GetDecimal("IMPORTE_15402"),
                                    despensa = reader.GetDecimal("despensa"),
                                    prestamos = reader.GetDecimal("prestamos"),
                                    superissste = reader.GetDecimal("superissste"),
                                    ade_medico = reader.GetDecimal("ade_medico"),
                                    CHC = reader.GetDecimal("CHC"),
                                    pension = reader.GetDecimal("pension"),
                                    faltas = reader.GetDecimal("faltas"),
                                    retardos = reader.GetDecimal("retardos"),
                                    TOT_PERC = reader.GetDecimal("TOT_PERC"),
                                    tot_dedu = reader.GetDecimal("tot_dedu"),
                                    tot_neto = reader.GetDecimal("tot_neto")
                                });

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }
            return result;
        }

        public async Task<List<SericaDetalleReporteModel>> GetSericaSinPrestamo(string tabla)
        {
            var connectionString = _connectionString;
            var result = new List<SericaDetalleReporteModel>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand("GetSericaSinPrestamos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tabla", tabla);
                    command.Parameters.AddWithValue("@sueldo", "sueldo");

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {

                                result.Add(new SericaDetalleReporteModel
                                {
                                    TI = reader.GetString("TI"),
                                    NSS = reader.IsDBNull("NSS") ? string.Empty : reader.GetString("NSS"),
                                    NOMBRE = reader.IsDBNull("NOMBRE") ? string.Empty : reader.GetString("NOMBRE"),
                                    APE_PAT = reader.IsDBNull("APE_PAT") ? string.Empty : reader.GetString("APE_PAT"),
                                    APE_MAT = reader.IsDBNull("APE_MAT") ? string.Empty : reader.GetString("APE_MAT"),
                                    RFC = reader.IsDBNull("RFC") ? string.Empty : reader.GetString("RFC"),
                                    CURP = reader.IsDBNull("CURP") ? string.Empty : reader.GetString("CURP"),
                                    SEXO = reader.IsDBNull("SEXO") ? string.Empty : reader.GetString("SEXO"),
                                    PAGADURIA = reader.IsDBNull("PAGADURIA") ? string.Empty : reader.GetString("PAGADURIA"),
                                    NO_EMPLE = reader.IsDBNull("NO_EMPLE") ? string.Empty : reader.GetString("NO_EMPLE"),
                                    NUM_CHEQ = reader.IsDBNull("NUM_CHEQ") ? string.Empty : reader.GetString("NUM_CHEQ"),
                                    REGIMEN_ISSSTE = reader.IsDBNull("REGIMEN_ISSSTE") ? (int?)null : reader.GetInt32("REGIMEN_ISSSTE"),
                                    TIPO_CONTRATO = reader.IsDBNull("TIPO_CONTRATO") ? (int?)null : reader.GetInt32("TIPO_CONTRATO"),
                                    TOT_PERC = (decimal)(reader.IsDBNull("TOT_PERC") ? (decimal?)null : reader.GetDecimal("TOT_PERC")),
                                    TOT_DEDU = (decimal)(reader.IsDBNull("TOT_DEDU") ? (decimal?)null : reader.GetDecimal("TOT_DEDU")),
                                    PARTIDA_11301 = reader.IsDBNull("PARTIDA_11301") ? string.Empty : reader.GetString("PARTIDA_11301"),
                                    CONCEPTO_11301 = reader.IsDBNull("CONCEPTO_11301") ? string.Empty : reader.GetString("CONCEPTO_11301"),
                                    IMPORTE_11301 = (decimal)(reader.IsDBNull("IMPORTE_11301") ? (decimal?)null : reader.GetDecimal("IMPORTE_11301")),
                                    PT12201 = reader.IsDBNull("PT12201") ? string.Empty : reader.GetString("PT12201"),
                                    CP12201 = reader.IsDBNull("CP12201") ? string.Empty : reader.GetString("CP12201"),
                                    IM12201 = reader.IsDBNull("IM12201") ? string.Empty : reader.GetString("IM12201"),
                                    PT12301 = reader.IsDBNull("PT12301") ? string.Empty : reader.GetString("PT12301"),
                                    CP12301 = reader.IsDBNull("CP12301") ? string.Empty : reader.GetString("CP12301"),
                                    IM12301 = reader.IsDBNull("IM12301") ? string.Empty : reader.GetString("IM12301"),
                                    PT13101 = reader.IsDBNull("PT13101") ? string.Empty : reader.GetString("PT13101"),
                                    CP13101 = reader.IsDBNull("CP13101") ? string.Empty : reader.GetString("CP13101"),
                                    IM13101 = reader.IsDBNull("IM13101") ? string.Empty : reader.GetString("IM13101"),
                                    PARTIDA_13102 = reader.IsDBNull("PARTIDA_13102") ? string.Empty : reader.GetString("PARTIDA_13102"),
                                    CONCEPTO_13102 = reader.IsDBNull("CONCEPTO_13102") ? string.Empty : reader.GetString("CONCEPTO_13102"),
                                    IMPORTE_13102 = (decimal)(reader.IsDBNull("IMPORTE_13102") ? (decimal?)null : reader.GetDecimal("IMPORTE_13102")),
                                    IPT13401 = reader.IsDBNull("IPT13401") ? string.Empty : reader.GetString("IPT13401"),
                                    ICP13401 = reader.IsDBNull("ICP13401") ? string.Empty : reader.GetString("ICP13401"),
                                    IM13401 = reader.IsDBNull("IM13401") ? string.Empty : reader.GetString("IM13401"),
                                    IPT13402 = reader.IsDBNull("IPT13402") ? string.Empty : reader.GetString("IPT13402"),
                                    ICP13402 = reader.IsDBNull("ICP13402") ? string.Empty : reader.GetString("ICP13402"),
                                    IM13402 = reader.IsDBNull("IM13402") ? string.Empty : reader.GetString("IM13402"),
                                    IPT13407 = reader.IsDBNull("IPT13407") ? string.Empty : reader.GetString("IPT13407"),
                                    ICP13407 = reader.IsDBNull("ICP13407") ? string.Empty : reader.GetString("ICP13407"),
                                    IM13407 = reader.IsDBNull("IM13407") ? string.Empty : reader.GetString("IM13407"),
                                    IPT13408 = reader.IsDBNull("IPT13408") ? string.Empty : reader.GetString("IPT13408"),
                                    ICP13408 = reader.IsDBNull("ICP13408") ? string.Empty : reader.GetString("ICP13408"),
                                    IM13408 = reader.IsDBNull("IM13408") ? string.Empty : reader.GetString("IM13408"),
                                    IPT13411 = reader.IsDBNull("IPT13411") ? string.Empty : reader.GetString("IPT13411"),
                                    ICP13411 = reader.IsDBNull("ICP13411") ? string.Empty : reader.GetString("ICP13411"),
                                    IM13411 = reader.IsDBNull("IM13411") ? string.Empty : reader.GetString("IM13411"),
                                    PARTIDA_15403 = reader.IsDBNull("PARTIDA_15403") ? string.Empty : reader.GetString("PARTIDA_15403"),
                                    CONCEPTO_15403 = reader.IsDBNull("CONCEPTO_15403") ? string.Empty : reader.GetString("CONCEPTO_15403"),
                                    IMPORTE_15403 = (decimal)(reader.IsDBNull("IMPORTE_15403") ? (decimal?)null : reader.GetDecimal("IMPORTE_15403")),
                                    PARTIDA_15402 = reader.IsDBNull("PARTIDA_15402") ? string.Empty : reader.GetString("PARTIDA_15402"),
                                    CONCEPTO_15402 = reader.IsDBNull("CONCEPTO_15402") ? string.Empty : reader.GetString("CONCEPTO_15402"),
                                    IMPORTE_15402 = (decimal)(reader.IsDBNull("IMPORTE_15402") ? (decimal?)null : reader.GetDecimal("IMPORTE_15402")),
                                    PARTIDA_10001 = reader.IsDBNull("PARTIDA_10001") ? string.Empty : reader.GetString("PARTIDA_10001"),
                                    CONCEPTO_10001 = reader.IsDBNull("CONCEPTO_10001") ? string.Empty : reader.GetString("CONCEPTO_10001"),
                                    IMPORTE_10001 = (decimal)(reader.IsDBNull("IMPORTE_10001") ? (decimal?)null : reader.GetDecimal("IMPORTE_10001")),
                                    PARTIDA_10002 = reader.IsDBNull("PARTIDA_10002") ? string.Empty : reader.GetString("PARTIDA_10002"),
                                    CONCEPTO_10002 = reader.IsDBNull("CONCEPTO_10002") ? string.Empty : reader.GetString("CONCEPTO_10002"),
                                    IMPORTE_10002 = (decimal)(reader.IsDBNull("IMPORTE_10002") ? (decimal?)null : reader.GetDecimal("IMPORTE_10002")),
                                    PARTIDA_20001 = reader.IsDBNull("PARTIDA_20001") ? string.Empty : reader.GetString("PARTIDA_20001"),
                                    CONCEPTO_20001 = reader.IsDBNull("CONCEPTO_20001") ? string.Empty : reader.GetString("CONCEPTO_20001"),
                                    IMPORTE_20001 = (decimal)(reader.IsDBNull("IMPORTE_20001") ? (decimal?)null : reader.GetDecimal("IMPORTE_20001")),
                                    PARTIDA_20002 = reader.IsDBNull("PARTIDA_20002") ? string.Empty : reader.GetString("PARTIDA_20002"),
                                    CONCEPTO_20002 = reader.IsDBNull("CONCEPTO_20002") ? string.Empty : reader.GetString("CONCEPTO_20002"),
                                    IMPORTE_20002 = (decimal)(reader.IsDBNull("IMPORTE_20002") ? (decimal?)null : reader.GetDecimal("IMPORTE_20002")),
                                    PT20003 = reader.IsDBNull("PT20003") ? string.Empty : reader.GetString("PT20003"),
                                    CP20003 = reader.IsDBNull("CP20003") ? string.Empty : reader.GetString("CP20003"),
                                    IM20003 = reader.IsDBNull("IM20003") ? string.Empty : reader.GetString("IM20003"),
                                    PT20004 = reader.IsDBNull("PT20004") ? string.Empty : reader.GetString("PT20004"),
                                    CP20004 = reader.IsDBNull("CP20004") ? string.Empty : reader.GetString("CP20004"),
                                    IM20004 = reader.IsDBNull("IM20004") ? string.Empty : reader.GetString("IM20004"),
                                    PARTIDA_20005 = reader.IsDBNull("PARTIDA_20005") ? string.Empty : reader.GetString("PARTIDA_20005"),
                                    CONCEPTO_20005 = reader.IsDBNull("CONCEPTO_20005") ? string.Empty : reader.GetString("CONCEPTO_20005"),
                                    IMPORTE_20005 = (decimal)(reader.IsDBNull("IMPORTE_20005") ? (decimal?)null : reader.GetDecimal("IMPORTE_20005")),
                                    PARTIDA_20006 = reader.IsDBNull("PARTIDA_20006") ? string.Empty : reader.GetString("PARTIDA_20006"),
                                    CONCEPTO_20006 = reader.IsDBNull("CONCEPTO_20006") ? string.Empty : reader.GetString("CONCEPTO_20006"),
                                    IMPORTE_20006 = (decimal)(reader.IsDBNull("IMPORTE_20006") ? (decimal?)null : reader.GetDecimal("IMPORTE_20006")),
                                    PARTIDA_20007 = reader.IsDBNull("PARTIDA_20007") ? string.Empty : reader.GetString("PARTIDA_20007"),
                                    CONCEPTO_20007 = reader.IsDBNull("CONCEPTO_20007") ? string.Empty : reader.GetString("CONCEPTO_20007"),
                                    IMPORTE_20007 = (decimal)(reader.IsDBNull("IMPORTE_20007") ? (decimal?)null : reader.GetDecimal("IMPORTE_20007")),
                                    PT20008 = reader.IsDBNull("PT20008") ? string.Empty : reader.GetString("PT20008"),
                                    CP20008 = reader.IsDBNull("CP20008") ? string.Empty : reader.GetString("CP20008"),
                                    IM20008 = reader.IsDBNull("IM20008") ? string.Empty : reader.GetString("IM20008"),
                                    TOT_NETO = (decimal)(reader.IsDBNull("TOT_NETO") ? (decimal?)null : reader.GetDecimal("TOT_NETO")),
                                    SDO_ISS = (decimal)(reader.IsDBNull("SDO_ISS") ? (decimal?)null : reader.GetDecimal("SDO_ISS")),
                                    DESPENSA = (decimal)(reader.IsDBNull("DESPENSA") ? (decimal?)null : reader.GetDecimal("DESPENSA")),
                                    PRESTAMOS = (decimal)(reader.IsDBNull("PRESTAMOS") ? (decimal?)null : reader.GetDecimal("PRESTAMOS")),
                                    CHC = (decimal)(reader.IsDBNull("CHC") ? (decimal?)null : reader.GetDecimal("CHC")),
                                    PENSION = (decimal)(reader.IsDBNull("PENSION") ? (decimal?)null : reader.GetDecimal("PENSION")),
                                    Tipo = reader.GetString("Tipo"),
                                    TOT_DEDU1 =reader.GetDecimal("TOT_DEDU1")
                                });

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }
            return result;
        }

        public async Task<List<SericaHeaderModel>> GetHeaderSericaIncremento(string tabla)
        {
            var connectionString = _connectionString;
            var result = new List<SericaHeaderModel>();
   
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand("GetHeaderSericaIncremento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tabla", tabla);
                    command.Parameters.AddWithValue("@sueldo", "sueldo");

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {

                                result.Add(new SericaHeaderModel
                                {

                                    ENC0 = reader.GetString("ENC0"),
                                    FechaPago = reader.GetString("FechaPago"),
                                    ENC1 = reader.GetString("ENC1"),
                                    ENC2 = reader.GetInt32("ENC2"),
                                    IMPORTE_11301 = reader.GetDecimal("IMPORTE_11301"),
                                    IM12201 = reader.GetInt32("IM12201"),
                                    IM12301 = reader.GetInt32("IM12301"),
                                    IM13101 = reader.GetInt32("IM13101"),
                                    IMPORTE_13102 = reader.GetDecimal("IMPORTE_13102"),
                                    IM13401 = reader.GetInt32("IM13401"),
                                    IM13402 = reader.GetInt32("IM13402"),
                                    IM13407 = reader.GetInt32("IM13407"),
                                    IM13408 = reader.GetDecimal("IM13408"),
                                    IM13411 = reader.GetDecimal("IM13411"),
                                    IMPORTE_15403 = reader.GetDecimal("IMPORTE_15403"),
                                    IMPORTE_15402 = reader.GetDecimal("IMPORTE_15402"),
                                    despensa = reader.GetDecimal("despensa"),
                                    prestamos = reader.GetDecimal("prestamos"),
                                    superissste = reader.GetDecimal("superissste"),
                                    ade_medico = reader.GetDecimal("ade_medico"),
                                    CHC = reader.GetDecimal("CHC"),
                                    pension = reader.GetDecimal("pension"),
                                    faltas = reader.GetDecimal("faltas"),
                                    retardos = reader.GetDecimal("retardos"),
                                    TOT_PERC = reader.GetDecimal("TOT_PERC"),
                                    tot_dedu = reader.GetDecimal("tot_dedu"),
                                    tot_neto = reader.GetDecimal("tot_neto")
                                });

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }
            return result;
        }

        public async Task<List<SericaDetalleReporteModel>> GetSericaIncremento(string tabla)
        {

            var connectionString = _connectionString;
            var result = new List<SericaDetalleReporteModel>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
 
                using (var command = new MySqlCommand("GetSericaIncremento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tabla", tabla);
                    command.Parameters.AddWithValue("@sueldo", "sueldo");

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {

                                result.Add(new SericaDetalleReporteModel
                                {
                                    TI = reader.GetString("TI"),
                                    NSS = reader.IsDBNull("NSS") ? string.Empty : reader.GetString("NSS"),
                                    NOMBRE = reader.IsDBNull("NOMBRE") ? string.Empty : reader.GetString("NOMBRE"),
                                    APE_PAT = reader.IsDBNull("APE_PAT") ? string.Empty : reader.GetString("APE_PAT"),
                                    APE_MAT = reader.IsDBNull("APE_MAT") ? string.Empty : reader.GetString("APE_MAT"),
                                    RFC = reader.IsDBNull("RFC") ? string.Empty : reader.GetString("RFC"),
                                    CURP = reader.IsDBNull("CURP") ? string.Empty : reader.GetString("CURP"),
                                    SEXO = reader.IsDBNull("SEXO") ? string.Empty : reader.GetString("SEXO"),
                                    PAGADURIA = reader.IsDBNull("PAGADURIA") ? string.Empty : reader.GetString("PAGADURIA"),
                                    NO_EMPLE = reader.IsDBNull("NO_EMPLE") ? string.Empty : reader.GetString("NO_EMPLE"),
                                    NUM_CHEQ = reader.IsDBNull("NUM_CHEQ") ? string.Empty : reader.GetString("NUM_CHEQ"),
                                    REGIMEN_ISSSTE = reader.IsDBNull("REGIMEN_ISSSTE") ? (int?)null : reader.GetInt32("REGIMEN_ISSSTE"),
                                    TIPO_CONTRATO = reader.IsDBNull("TIPO_CONTRATO") ? (int?)null : reader.GetInt32("TIPO_CONTRATO"),
                                    TOT_PERC = (decimal)(reader.IsDBNull("TOT_PERC") ? (decimal?)null : reader.GetDecimal("TOT_PERC")),
                                    TOT_DEDU = (decimal)(reader.IsDBNull("TOT_DEDU") ? (decimal?)null : reader.GetDecimal("TOT_DEDU")),
                                    PARTIDA_11301 = reader.IsDBNull("PARTIDA_11301") ? string.Empty : reader.GetString("PARTIDA_11301"),
                                    CONCEPTO_11301 = reader.IsDBNull("CONCEPTO_11301") ? string.Empty : reader.GetString("CONCEPTO_11301"),
                                    IMPORTE_11301 = (decimal)(reader.IsDBNull("IMPORTE_11301") ? (decimal?)null : reader.GetDecimal("IMPORTE_11301")),
                                    PT12201 = reader.IsDBNull("PT12201") ? string.Empty : reader.GetString("PT12201"),
                                    CP12201 = reader.IsDBNull("CP12201") ? string.Empty : reader.GetString("CP12201"),
                                    IM12201 = reader.IsDBNull("IM12201") ? string.Empty : reader.GetString("IM12201"),
                                    PT12301 = reader.IsDBNull("PT12301") ? string.Empty : reader.GetString("PT12301"),
                                    CP12301 = reader.IsDBNull("CP12301") ? string.Empty : reader.GetString("CP12301"),
                                    IM12301 = reader.IsDBNull("IM12301") ? string.Empty : reader.GetString("IM12301"),
                                    PT13101 = reader.IsDBNull("PT13101") ? string.Empty : reader.GetString("PT13101"),
                                    CP13101 = reader.IsDBNull("CP13101") ? string.Empty : reader.GetString("CP13101"),
                                    IM13101 = reader.IsDBNull("IM13101") ? string.Empty : reader.GetString("IM13101"),
                                    PARTIDA_13102 = reader.IsDBNull("PARTIDA_13102") ? string.Empty : reader.GetString("PARTIDA_13102"),
                                    CONCEPTO_13102 = reader.IsDBNull("CONCEPTO_13102") ? string.Empty : reader.GetString("CONCEPTO_13102"),
                                    IMPORTE_13102 = (decimal)(reader.IsDBNull("IMPORTE_13102") ? (decimal?)null : reader.GetDecimal("IMPORTE_13102")),
                                    IPT13401 = reader.IsDBNull("IPT13401") ? string.Empty : reader.GetString("IPT13401"),
                                    ICP13401 = reader.IsDBNull("ICP13401") ? string.Empty : reader.GetString("ICP13401"),
                                    IM13401 = reader.IsDBNull("IM13401") ? string.Empty : reader.GetString("IM13401"),
                                    IPT13402 = reader.IsDBNull("IPT13402") ? string.Empty : reader.GetString("IPT13402"),
                                    ICP13402 = reader.IsDBNull("ICP13402") ? string.Empty : reader.GetString("ICP13402"),
                                    IM13402 = reader.IsDBNull("IM13402") ? string.Empty : reader.GetString("IM13402"),
                                    IPT13407 = reader.IsDBNull("IPT13407") ? string.Empty : reader.GetString("IPT13407"),
                                    ICP13407 = reader.IsDBNull("ICP13407") ? string.Empty : reader.GetString("ICP13407"),
                                    IM13407 = reader.IsDBNull("IM13407") ? string.Empty : reader.GetString("IM13407"),
                                    IPT13408 = reader.IsDBNull("IPT13408") ? string.Empty : reader.GetString("IPT13408"),
                                    ICP13408 = reader.IsDBNull("ICP13408") ? string.Empty : reader.GetString("ICP13408"),
                                    IM13408 = reader.IsDBNull("IM13408") ? string.Empty : reader.GetString("IM13408"),
                                    IPT13411 = reader.IsDBNull("IPT13411") ? string.Empty : reader.GetString("IPT13411"),
                                    ICP13411 = reader.IsDBNull("ICP13411") ? string.Empty : reader.GetString("ICP13411"),
                                    IM13411 = reader.IsDBNull("IM13411") ? string.Empty : reader.GetString("IM13411"),
                                    PARTIDA_15403 = reader.IsDBNull("PARTIDA_15403") ? string.Empty : reader.GetString("PARTIDA_15403"),
                                    CONCEPTO_15403 = reader.IsDBNull("CONCEPTO_15403") ? string.Empty : reader.GetString("CONCEPTO_15403"),
                                    IMPORTE_15403 = (decimal)(reader.IsDBNull("IMPORTE_15403") ? (decimal?)null : reader.GetDecimal("IMPORTE_15403")),
                                    PARTIDA_15402 = reader.IsDBNull("PARTIDA_15402") ? string.Empty : reader.GetString("PARTIDA_15402"),
                                    CONCEPTO_15402 = reader.IsDBNull("CONCEPTO_15402") ? string.Empty : reader.GetString("CONCEPTO_15402"),
                                    IMPORTE_15402 = (decimal)(reader.IsDBNull("IMPORTE_15402") ? (decimal?)null : reader.GetDecimal("IMPORTE_15402")),
                                    PARTIDA_10001 = reader.IsDBNull("PARTIDA_10001") ? string.Empty : reader.GetString("PARTIDA_10001"),
                                    CONCEPTO_10001 = reader.IsDBNull("CONCEPTO_10001") ? string.Empty : reader.GetString("CONCEPTO_10001"),
                                    IMPORTE_10001 = (decimal)(reader.IsDBNull("IMPORTE_10001") ? (decimal?)null : reader.GetDecimal("IMPORTE_10001")),
                                    PARTIDA_10002 = reader.IsDBNull("PARTIDA_10002") ? string.Empty : reader.GetString("PARTIDA_10002"),
                                    CONCEPTO_10002 = reader.IsDBNull("CONCEPTO_10002") ? string.Empty : reader.GetString("CONCEPTO_10002"),
                                    IMPORTE_10002 = (decimal)(reader.IsDBNull("IMPORTE_10002") ? (decimal?)null : reader.GetDecimal("IMPORTE_10002")),
                                    PARTIDA_20001 = reader.IsDBNull("PARTIDA_20001") ? string.Empty : reader.GetString("PARTIDA_20001"),
                                    CONCEPTO_20001 = reader.IsDBNull("CONCEPTO_20001") ? string.Empty : reader.GetString("CONCEPTO_20001"),
                                    IMPORTE_20001 = (decimal)(reader.IsDBNull("IMPORTE_20001") ? (decimal?)null : reader.GetDecimal("IMPORTE_20001")),
                                    PARTIDA_20002 = reader.IsDBNull("PARTIDA_20002") ? string.Empty : reader.GetString("PARTIDA_20002"),
                                    CONCEPTO_20002 = reader.IsDBNull("CONCEPTO_20002") ? string.Empty : reader.GetString("CONCEPTO_20002"),
                                    IMPORTE_20002 = (decimal)(reader.IsDBNull("IMPORTE_20002") ? (decimal?)null : reader.GetDecimal("IMPORTE_20002")),
                                    PT20003 = reader.IsDBNull("PT20003") ? string.Empty : reader.GetString("PT20003"),
                                    CP20003 = reader.IsDBNull("CP20003") ? string.Empty : reader.GetString("CP20003"),
                                    IM20003 = reader.IsDBNull("IM20003") ? string.Empty : reader.GetString("IM20003"),
                                    PT20004 = reader.IsDBNull("PT20004") ? string.Empty : reader.GetString("PT20004"),
                                    CP20004 = reader.IsDBNull("CP20004") ? string.Empty : reader.GetString("CP20004"),
                                    IM20004 = reader.IsDBNull("IM20004") ? string.Empty : reader.GetString("IM20004"),
                                    PARTIDA_20005 = reader.IsDBNull("PARTIDA_20005") ? string.Empty : reader.GetString("PARTIDA_20005"),
                                    CONCEPTO_20005 = reader.IsDBNull("CONCEPTO_20005") ? string.Empty : reader.GetString("CONCEPTO_20005"),
                                    IMPORTE_20005 = (decimal)(reader.IsDBNull("IMPORTE_20005") ? (decimal?)null : reader.GetDecimal("IMPORTE_20005")),
                                    PARTIDA_20006 = reader.IsDBNull("PARTIDA_20006") ? string.Empty : reader.GetString("PARTIDA_20006"),
                                    CONCEPTO_20006 = reader.IsDBNull("CONCEPTO_20006") ? string.Empty : reader.GetString("CONCEPTO_20006"),
                                    IMPORTE_20006 = (decimal)(reader.IsDBNull("IMPORTE_20006") ? (decimal?)null : reader.GetDecimal("IMPORTE_20006")),
                                    PARTIDA_20007 = reader.IsDBNull("PARTIDA_20007") ? string.Empty : reader.GetString("PARTIDA_20007"),
                                    CONCEPTO_20007 = reader.IsDBNull("CONCEPTO_20007") ? string.Empty : reader.GetString("CONCEPTO_20007"),
                                    IMPORTE_20007 = (decimal)(reader.IsDBNull("IMPORTE_20007") ? (decimal?)null : reader.GetDecimal("IMPORTE_20007")),
                                    PT20008 = reader.IsDBNull("PT20008") ? string.Empty : reader.GetString("PT20008"),
                                    CP20008 = reader.IsDBNull("CP20008") ? string.Empty : reader.GetString("CP20008"),
                                    IM20008 = reader.IsDBNull("IM20008") ? string.Empty : reader.GetString("IM20008"),
                                    TOT_NETO = (decimal)(reader.IsDBNull("TOT_NETO") ? (decimal?)null : reader.GetDecimal("TOT_NETO")),
                                    SDO_ISS = (decimal)(reader.IsDBNull("SDO_ISS") ? (decimal?)null : reader.GetDecimal("SDO_ISS")),
                                    DESPENSA = (decimal)(reader.IsDBNull("DESPENSA") ? (decimal?)null : reader.GetDecimal("DESPENSA")),
                                    PRESTAMOS = (decimal)(reader.IsDBNull("PRESTAMOS") ? (decimal?)null : reader.GetDecimal("PRESTAMOS")),
                                    CHC = (decimal)(reader.IsDBNull("CHC") ? (decimal?)null : reader.GetDecimal("CHC")),
                                    PENSION = (decimal)(reader.IsDBNull("PENSION") ? (decimal?)null : reader.GetDecimal("PENSION")),
                                    Tipo = reader.GetString("Tipo"),
                                    //TOT_DEDU1 = reader.GetDecimal("TOT_DEDU1")
                                });

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }
            return result;
        }

        public async Task<List<ResumenConceptos>> GetDetalleTerceros(string tabla)
        {

            var connectionString = _connectionString;
            var result = new List<ResumenConceptos>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand("GetResumenConceptos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tabla", tabla);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {

                                result.Add(new ResumenConceptos
                                {
                                    TIPO = reader.GetString("TIPO"),
                                    CT = reader.GetString("CT"),
                                    RFC = reader.GetString("RFC"),
                                    Nombre = reader.GetString("Nombre"),
                                    METLIFE = reader.GetDecimal("METLIFE"),
                                    KONDINERO = reader.GetDecimal("KONDINERO"),
                                    CREDIFIEL = reader.GetDecimal("CREDIFIEL"),
                                    FONACOT = reader.GetDecimal("FONACOT"),
                                    SUTCONALEP = reader.GetDecimal("SUTCONALEP"),
                                    SITACONQROO = reader.GetDecimal("SITACONQROO"),
                                    SITEM = reader.GetDecimal("SITEM")
                               
                                });

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
            }
            return result;
        }
    }
}
