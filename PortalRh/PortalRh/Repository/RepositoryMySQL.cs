using Microsoft.EntityFrameworkCore;
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

        public RepositoryMySQL(ApplicationDbContextMySQL context, IConfiguration configuration)
        {
            _contexto2 = context;
            _connectionString = configuration.GetConnectionString("mysqlconnectionString");
        }

        public void DoSomething()
        {
            // Usar la cadena de conexión
            Console.Write("la cadena es");

            Console.WriteLine(_connectionString);
            // Implementa la lógica de tu repositorio aquí
        }
        private readonly IConfiguration _configuration;


        public async Task<List<RegNominasInfo>> GetRegNominasInfoAsync()
        {
            var result = new List<RegNominasInfo>();
            var query = @"
                SELECT 
                    CONCAT_WS('|', r.DbTable, r.Qna, r.Year, r.Descripcion, r.FecPago) AS Info
                FROM 
                    reg_nominas r
                WHERE 
                    r.Status = 1;
            ";
            Console.Write(query);
            using (var connection = (MySqlConnection)_contexto2.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand(query, connection))
                {
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
            var result = new List<reg_nominas>();
            var query = @"
                SELECT 
                    Dbtable
                FROM 
                    reg_nominas r
                WHERE 
                    r.Status = 1;
            ";
            //string connectionString = _configuration.GetConnectionString("MysqlConnection");
            //builder.Configuration.GetConnectionString("MysqlConnection");
            var connectionString = "server=192.168.11.31;database=sandbox;user=josep;password=JosePadi11a";
            Console.Write(query);
            using (var connection = new MySqlConnection(connectionString))
            //using (var connection = (MySqlConnection)_contexto2.Database.GetDbConnection())

            {
                Console.Write(connectionString);
                await connection.OpenAsync();
                using (var command = new MySqlCommand(query, connection))
                {
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

        public async Task<List<SericaReporteModel>> GetReportSericaAsync(string tabla)
        {
            var result = new List<SericaReporteModel>();
            var query = @"
            SELECT 'C' as ENC0 ,
            '4212300' as ENC1,
            count(TIPO) as ENC2,
            SUM(IMPORTE_11301) as IMPORTE_11301,
            SUM(IM12201) as IM12201,
            SUM(IM12301) as IM12301,
            SUM(IM13101) as IM13101,
            SUM(IMPORTE_13102) as IMPORTE_13102,
            SUM(IM13401) as IM13401,
            SUM(IM13402) as IM13402,
            SUM(IM13407) as IM13407,
            SUM(IM13408) as IM13408,
            SUM(IM13411) as IM13411,
            SUM(IMPORTE_15403) as IMPORTE_15403,
            SUM(IMPORTE_15402) as IMPORTE_15402,
            SUM(despensa) as despensa,
            SUM(prestamos) as prestamos,
            0 as superissste,
            0 as ade_medico,
            SUM(CHC) as CHC,
            SUM(pension) as pension,
            0 as faltas,
            0 as retardos,
            SUM(TOT_PERC) as TOT_PERC,
            SUM(tot_dedu) as tot_dedu,
            SUM(tot_neto) as tot_neto
        FROM
        (SELECT
            'D' AS TIPO,
            IF(confronta.nss is null,siri.nss,confronta.nss) as nss,
            trim(nomina.nombre) as NOMBRE,
            trim(nomina.ape_pat) as APE_PAT,
            trim(nomina.ape_mat) as APE_MAT,
            nomina.rfc,
            nomina.curp,
            IF(SUBSTR(nomina.curp, 11, 1) = 'H', 'M', 'F') AS sexo,
            '4212300' AS pagaduria,
            siri.Numero_Empleado,
            '9999999999' AS NUM_CHEQ,
            CASE confronta.regimen_pensionario 
                WHEN 'CUENTAS INDIVIDUALES' THEN 2
                WHEN 'DECIMO TRANSITORIO' THEN 1
            END AS Regimen_ISSSTE,
            CASE nomina.tipo 
                WHEN 'ADM' THEN 2 
                WHEN 'DOC' THEN 3 
                WHEN 'HON' THEN 5 
            END AS TIPO_CONTRATO,
            nomina.tot_perc,
            nomina.tot_dedu,
            '11301' AS PARTIDA_11301,
            'P001A' AS CONCEPTO_11301,
            if(P001A>0,P001A,if(p001a = 0 and tipo='DOC' and P001B>0,P001B,0)) AS IMPORTE_11301,
            '' AS PT12201,
            '' AS CP12201,
            '' AS IM12201,
            '' AS PT12301,
            '' AS CP12301,
            '' AS IM12301,
            '' AS PT13101,
            '' AS CP13101,
            '' AS IM13101,
            '13102' AS PARTIDA_13102,
            'P022A' AS CONCEPTO_13102,
            P022A+P016K AS IMPORTE_13102,
            '' AS IPT13401,
            '' AS ICP13401,
            '' AS IM13401,
            '' AS IPT13402,
            '' AS ICP13402,
            '' AS IM13402,
            '' AS IPT13407,
            '' AS ICP13407,
            '' AS IM13407,
            '' AS IPT13408,
            '' AS ICP13408,
            '' AS IM13408,
            '' AS IPT13411,
            '' AS ICP13411,
            '' AS IM13411,
            '15403' AS PARTIDA_15403,
            'P016D' AS CONCEPTO_15403,
            P016D+P016E AS IMPORTE_15403,
            '15402' AS PARTIDA_15402,
            'P016A' AS CONCEPTO_15402,
            P016A AS IMPORTE_15402,
            '10001' AS PARTIDA_10001,
            'PERCEP' AS CONCEPTO_10001,
            round(P001A+P001B+P001C+P001D+P001E+P002A+P010A+P016C+P016F+P016G+P016H+P016I+P016J+P016L+
            +P016M+P016N+P021A+P023A+P034A+P035A+P038A+P038B+P038C+P038D+P038E+P038F+P038G+P038H+P038I+P038J+P038K+
            +P038L+P039A,2)  as IMPORTE_10001,
            '10002' AS PARTIDA_10002,
            'P016B' AS CONCEPTO_10002,
            P016B AS IMPORTE_10002,
            '20001' AS PARTIDA_20001,
            'DEDUC' AS CONCEPTO_20001,
            round(D001A+D001B+D001C+D001D+D001E+D002A+D004B+D004C+D004D+D004E+D004F+D004G+D004H+
            +D004I+D009B+D011A+D012A+D013A+D014A+D019A+D019B,2) AS IMPORTE_20001,
            '20002' AS PARTIDA_20002,
            'D004A' AS CONCEPTO_20002,
            D004A AS IMPORTE_20002,
            '' as PT20003,
            '' as CP20003,
            '' as IM20003,
            '' as PT20004,
            '' as CP20004,
            '' as IM20004,
            '20005' AS PARTIDA_20005,
            'D009A' AS CONCEPTO_20005,
            D009A+D009C AS IMPORTE_20005,
            '20006' AS PARTIDA_20006,
            'D007A' AS CONCEPTO_20006,
            D007A AS IMPORTE_20006,
            '20007' AS PARTIDA_20007,
            'D020A' AS CONCEPTO_20007,
            D020A AS IMPORTE_20007,
            '' as PT20008,
            '' as CP20008,
            '' as IM20008,
            round(TOT_PERC-TOT_DEDU,2)  as TOT_NETO,
            round(SDOBAS_ISS)  as SDO_ISS ,
            P016B as despensa,
            D004A as prestamos,
            D009A+D009C as CHC,
            D007A as pension,
            FEC_PAGO,QNA_PAGO
        FROM
            " + tabla + @" nomina
            LEFT JOIN siri_trabajadores siri ON siri.rfc = nomina.rfc
            left join confronta on confronta.curp = nomina.curp 
            where D001a > 0
        ) as resumen
        GROUP BY QNA_PAGO;
    ";

            using (var connection = (MySqlConnection)_contexto2.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new SericaReporteModel
                            {
                                ENC0 = reader.GetString("ENC0"),
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

    }
}
