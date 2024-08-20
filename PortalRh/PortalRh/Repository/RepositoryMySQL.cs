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
        private readonly IConfiguration _configuration;

        public RepositoryMySQL(ApplicationDbContextMySQL context, IConfiguration configuration)
        {
            _contexto2 = context;
            _connectionString = configuration.GetConnectionString("MysqlConnection");
        }

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
            var connectionString = _connectionString;
            var result = new List<reg_nominas>();
            var query = @"
        SELECT 
            DbTable
        FROM 
            reg_nominas r
        WHERE 
            r.Status = 1;
    ";

           
            using (var connection = new MySqlConnection(connectionString))
            {
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

      
        public async Task<List<SericaHeaderModel>> GetHeaderSericaPrestamoAsync(string tabla)
        {
            var connectionString = _connectionString;
            var result = new List<SericaHeaderModel>();
            var query = @"
            SELECT 'C' as ENC0,
           '4212300' as ENC1,count(TIPO) as ENC2,
            DATE_FORMAT(STR_TO_DATE(FEC_PAGO, '%d/%m/%Y'), '%Y%m%d') AS FechaPago,
            0 as IMPORTE_11301,
            0 as IM12201,
            0 as IM12301,
            0 as IM13101,
            0 as IMPORTE_13102,
            0 as IM13401,
            0 as IM13402,
            0 as IM13407,
            0 as IM13408,
            0 as IM13411,
            0 as IMPORTE_15403,
            0 as IMPORTE_15402,
            0 as despensa,
            sum(prestamos) as prestamos,
            0 as superissste,
            0 as ade_medico,
            0 as CHC,
            0 as pension,
            0 as faltas,
            0 as retardos,
            0 as TOT_PERC,
            sum(prestamos) as tot_dedu,
            0 as tot_neto

            from
            (SELECT
	            'D' AS TIPO,
	            IF(confronta.nss is null,siri.nss,confronta.nss) as nss,
	            trim(nomina.nombre) as NOMBRE,
	            trim(nomina.ape_pat) as APE_PAT,
	            trim(nomina.ape_mat) as APE_MAT,
	            nomina.rfc,
	            nomina.curp,
            IF
	            ( SUBSTR( nomina.curp, 11, 1 ) = 'H', 'M', 'F' ) AS sexo,
	            '4212300' AS pagaduria,
	            siri.no_emple,
	            '9999999999' AS NUM_CHEQ,
	            CASE confronta.regimen_pensionario 
	            WHEN 'CUENTAS INDIVIDUALES' THEN
		            2
	            WHEN 'DECIMO TRANSITORIO' THEN
		            1
            END AS Regimen_ISSSTE,

            CASE
	            nomina.tipo 
	            WHEN 'ADM' THEN
	            2 
	            WHEN 'DOC' THEN
	            3 
	            WHEN 'HON' THEN
	            5 
	            END AS TIPO_CONTRATO,
	            nomina.tot_perc,
	            nomina.tot_dedu,
	            '11301' AS PARTIDA_11301,
              'P001A' AS CONCEPTO_11301,
              if(P001A>0,P001A,if( p001a = 0 and  tipo='DOC' and P001B>0,P001B,0)) AS IMPORTE_11301,
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
            #------------ BIEN -----------------------	 
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
	            (select * from " + tabla+@" where d004a >0) nomina
	            LEFT JOIN siri_vigente siri ON siri.rfc = nomina.rfc
	            left join confronta on confronta.curp = nomina.curp 
	            where p001a > 0 or ( p001a = 0 and  tipo='DOC' and P001B>0)
	            )  as resumen
	            GROUP BY QNA_PAGO;
    ";
           
            using (var connection = new MySqlConnection(connectionString))
            
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand(query, connection))
                {
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
        //ESTE
        public async Task<List<SericaDetalleReporteModel>> GetSericaPrestamoAsync(string tabla)
        {
            var connectionString = _connectionString;
            var result = new List<SericaDetalleReporteModel>();
            var query = @"
                SELECT
	            'D' AS TI,
	            IF(confronta.nss is null,siri.nss,confronta.nss) as NSS,
	            trim(nomina.nombre) as NOMBRE,
	            trim(nomina.ape_pat) as APE_PAT,
	            trim(nomina.ape_mat) as APE_MAT,
	            nomina.rfc as RFC,
	            nomina.curp as CURP,
            IF
	            ( SUBSTR( nomina.curp, 11, 1 ) = 'H', 'M', 'F' ) AS SEXO,
	            '4212300' AS PAGADURIA,
	            siri.no_emple as NO_EMPLE,
	            '9999999999' AS NUM_CHEQ,
	            CASE confronta.regimen_pensionario 
	            WHEN 'CUENTAS INDIVIDUALES' THEN
		            2
	            WHEN 'DECIMO TRANSITORIO' THEN
		            1
            END AS REGIMEN_ISSSTE,

	
	
            CASE
	            nomina.tipo 
	            WHEN 'ADM' THEN
	            2 
	            WHEN 'DOC' THEN
	            3 
	            WHEN 'HON' THEN
	            5 
	            END AS TIPO_CONTRATO,
	            0 as TOT_PERC,
	            d004a as TOT_DEDU,
	            '11301' AS PARTIDA_11301,
              'P001A' AS CONCEPTO_11301,
              0 AS IMPORTE_11301,
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
               0 AS IMPORTE_13102,
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
               0 AS IMPORTE_15403,
	 
	             '15402' AS PARTIDA_15402,
              'P016A' AS CONCEPTO_15402,
               0 AS IMPORTE_15402,
            #------------ BIEN -----------------------	 
		            '10001' AS PARTIDA_10001,
		            'PERCEP' AS CONCEPTO_10001,
	             0 as  IMPORTE_10001,

	             '10002' AS PARTIDA_10002,
	             'P016B' AS CONCEPTO_10002,
	              0 AS IMPORTE_10002,
		


            '20001' AS PARTIDA_20001,
            'DEDUC' AS CONCEPTO_20001,
            0 AS IMPORTE_20001,

		
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
               0 AS IMPORTE_20005,
	 
	            '20006' AS PARTIDA_20006,
              'D007A' AS CONCEPTO_20006,
               0 AS IMPORTE_20006,
	 
	            '20007' AS PARTIDA_20007,
              'D020A' AS CONCEPTO_20007,
               0 AS IMPORTE_20007,
	 
	             '' as PT20008,
	             '' as CP20008,
	             '' as IM20008,

	             0  as TOT_NETO,
	             round(SDOBAS_ISS)  as SDO_ISS ,
	             P016B as despensa,
	             D004A as prestamos,
		            D009A+D009C as CHC,
		            D007A as pension,
		            0 as TOT_PERC,
		            d004a as TOT_DEDU,
		            TOT_NETO,TIPO
            FROM
	            (SELECT * from "+tabla+@" where d004a>0) 	nomina
	            LEFT JOIN siri_vigente siri ON siri.rfc = nomina.rfc
	            left join confronta on confronta.curp = nomina.curp 
	            where p001a > 0 or ( p001a = 0 and  tipo='DOC' and P001B>0)
            ORDER BY CURP";

            //Console.WriteLine(query);

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand(query, connection))
                {
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
        //sin prestamo

        public async Task<List<SericaHeaderModel>> GetHeaderSericaSinPrestamo(string tabla)
        {
            var connectionString = _connectionString;
            var result = new List<SericaHeaderModel>();
            var query = @"
           SELECT
	            'C' AS ENC0,
	            DATE_FORMAT( STR_TO_DATE( FEC_PAGO, '%d/%m/%Y' ), '%Y%m%d' ) AS FechaPago,
	            '4212300' AS ENC1,
	            count( TIPO ) AS ENC2,
	            sum( IMPORTE_11301 ) AS IMPORTE_11301,
	            sum( IM12201 ) AS IM12201,
	            sum( IM12301 ) AS IM12301,
	            sum( IM13101 ) AS IM13101,
	            sum( IMPORTE_13102 ) AS IMPORTE_13102,
	            sum( IM13401 ) AS IM13401,
	            sum( IM13402 ) AS IM13402,
	            sum( IM13407 ) AS IM13407,
	            sum( IM13408 ) AS IM13408,
	            sum( IM13411 ) AS IM13411,
	            sum( IMPORTE_15403 ) AS IMPORTE_15403,
	            sum( IMPORTE_15402 ) AS IMPORTE_15402,
	            sum( despensa ) AS despensa,
	            0 AS prestamos,
	            0 AS superissste,
	            0 AS ade_medico,
	            sum( CHC ) AS CHC,
	            sum( pension ) AS pension,
	            sum( IMPORTE_20007 ) AS faltas,
	            0 AS retardos,
	            ROUND( sum( TOT_PERC ), 2 ) AS TOT_PERC,
	            sum( tot_dedu )- sum( prestamos ) AS tot_dedu,
	            sum( tot_neto ) AS tot_neto 
            FROM
	            (
	            SELECT
		            'D' AS TIPO,
	            IF
		            ( confronta.nss IS NULL, siri.nss, confronta.nss ) AS nss,
		            trim( nomina.nombre ) AS NOMBRE,
		            trim( nomina.ape_pat ) AS APE_PAT,
		            trim( nomina.ape_mat ) AS APE_MAT,
		            nomina.rfc,
		            nomina.curp,
	            IF
		            ( SUBSTR( nomina.curp, 11, 1 ) = 'H', 'M', 'F' ) AS sexo,
		            '4212300' AS pagaduria,
		            siri.no_emple,
		            '9999999999' AS NUM_CHEQ,
	            CASE
			            confronta.regimen_pensionario 
			            WHEN 'CUENTAS INDIVIDUALES' THEN
			            2 
			            WHEN 'DECIMO TRANSITORIO' THEN
			            1 
		            END AS Regimen_ISSSTE,
	            CASE
			            nomina.tipo 
			            WHEN 'ADM' THEN
			            2 
			            WHEN 'DOC' THEN
			            3 
			            WHEN 'HON' THEN
			            5 
		            END AS TIPO_CONTRATO,
		            nomina.tot_perc,
		            nomina.tot_dedu,
		            '11301' AS PARTIDA_11301,
		            'P001A' AS CONCEPTO_11301,
	            IF
		            (
			            P001A > 0,
			            P001A,
		            IF
		            ( p001a = 0 AND tipo = 'DOC' AND P001B > 0, P001B, 0 )) AS IMPORTE_11301,
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
		            P022A + P016K AS IMPORTE_13102,
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
		            P016D + P016E AS IMPORTE_15403,
		            '15402' AS PARTIDA_15402,
		            'P016A' AS CONCEPTO_15402,
		            P016A AS IMPORTE_15402,#------------ BIEN -----------------------
		            '10001' AS PARTIDA_10001,
		            'PERCEP' AS CONCEPTO_10001,
		            round(
			            P001A + P001B + P001C + P001D + P001E + P002A + P010A + P016C + P016F + P016G + P016H + P016I + P016J + P016L + + P016M + P016N + P021A + P023A + P034A + P035A + P038A + P038B + P038C + P038D + P038E + P038F + P038G + P038H + P038I + P038J + P038K + + P038L + P039A,
			            2 
		            ) AS IMPORTE_10001,
		            '10002' AS PARTIDA_10002,
		            'P016B' AS CONCEPTO_10002,
		            P016B AS IMPORTE_10002,
		            '20001' AS PARTIDA_20001,
		            'DEDUC' AS CONCEPTO_20001,
		            round(
			            D001A + D001B + D001C + D001D + D001E + D002A + D004B + D004C + D004D + D004E + D004F + D004G + D004H + + D004I + D009B + D011A + D012A + D013A + D014A + D019A + D019B,
			            2 
		            ) AS IMPORTE_20001,
		            '20002' AS PARTIDA_20002,
		            'D004A' AS CONCEPTO_20002,
		            D004A AS IMPORTE_20002,
		            '' AS PT20003,
		            '' AS CP20003,
		            '' AS IM20003,
		            '' AS PT20004,
		            '' AS CP20004,
		            '' AS IM20004,
		            '20005' AS PARTIDA_20005,
		            'D009A' AS CONCEPTO_20005,
		            D009A + D009C AS IMPORTE_20005,
		            '20006' AS PARTIDA_20006,
		            'D007A' AS CONCEPTO_20006,
		            D007A AS IMPORTE_20006,
		            '20007' AS PARTIDA_20007,
		            'D020A' AS CONCEPTO_20007,
		            D020A AS IMPORTE_20007,
		            '' AS PT20008,
		            '' AS CP20008,
		            '' AS IM20008,
		            round( TOT_PERC - TOT_DEDU, 2 ) AS TOT_NETO,
		            round( SDOBAS_ISS ) AS SDO_ISS,
		            P016B AS despensa,
		            D004A AS prestamos,
		            D009A + D009C AS CHC,
		            D007A AS pension,
		            FEC_PAGO,
		            QNA_PAGO 
	            FROM
		            "" + tabla + @"" nomina
		            LEFT JOIN siri_vigente siri ON siri.rfc = nomina.rfc
		            LEFT JOIN confronta ON confronta.curp = nomina.curp 
	            WHERE
		            d001a > 0 
	            ) AS resumen 
            GROUP BY
	            QNA_PAGO
                               ";


            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sueldo", "sueldo");
                    //Console.WriteLine(command.CommandText);

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
            var query = @"
            SELECT
            'D' AS TI,
            IF(confronta.nss is null,siri.nss,confronta.nss) as NSS,
            trim(nomina.nombre) as NOMBRE,
            trim(nomina.ape_pat) as APE_PAT,
            trim(nomina.ape_mat) as APE_MAT,
            nomina.rfc as RFC,
            nomina.curp as CURP,
            IF(SUBSTR(nomina.curp, 11, 1) = 'H', 'M', 'F') AS SEXO,
            '4212300' AS PAGADURIA,
            siri.no_emple as NO_EMPLE,
            '9999999999' AS NUM_CHEQ,
            CASE confronta.regimen_pensionario 
                WHEN 'CUENTAS INDIVIDUALES' THEN 2
                WHEN 'DECIMO TRANSITORIO' THEN 1
            END AS REGIMEN_ISSSTE,
            CASE nomina.tipo 
                WHEN 'ADM' THEN 2 
                WHEN 'DOC' THEN 3 
                WHEN 'HON' THEN 5 
            END AS TIPO_CONTRATO,
            nomina.tot_perc as TOT_PERC,
            nomina.tot_dedu as TOT_DEDU,
            '11301' AS PARTIDA_11301,
            'P001A' AS CONCEPTO_11301,
            IF(P001A>0, P001A, IF(P001A = 0 AND tipo='DOC' AND P001B>0, P001B, 0)) AS IMPORTE_11301,
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
            P022A + P016K AS IMPORTE_13102,
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
            P016D + P016E AS IMPORTE_15403,
            '15402' AS PARTIDA_15402,
            'P016A' AS CONCEPTO_15402,
            P016A AS IMPORTE_15402,
            '10001' AS PARTIDA_10001,
            'PERCEP' AS CONCEPTO_10001,
            IF(ROUND(TOT_PERC - IF(P001A>0, P001A, IF(P001A = 0 AND tipo='DOC' AND P001B>0, P001B, 0)) - P022A - P016D - P016E - P016A - P016B - P016K, 2) <= 0, 0.00, ROUND(TOT_PERC - IF(P001A>0, P001A, IF(P001A = 0 AND tipo='DOC' AND P001B>0, P001B, 0)) - P022A - P016D - P016E - P016A - P016B - P016K, 2)) AS IMPORTE_10001,
            '10002' AS PARTIDA_10002,
            'P016B' AS CONCEPTO_10002,
            P016B AS IMPORTE_10002,
            '20001' AS PARTIDA_20001,
            'DEDUC' AS CONCEPTO_20001,
            ROUND(TOT_DEDU - d004a - D009A - D009C - D007A - D020A, 2) AS IMPORTE_20001,
            '20002' AS PARTIDA_20002,
            'D004A' AS CONCEPTO_20002,
            0 AS IMPORTE_20002,
            '' as PT20003,
            '' as CP20003,
            '' as IM20003,
            '' as PT20004,
            '' as CP20004,
            '' as IM20004,
            '20005' AS PARTIDA_20005,
            'D009A' AS CONCEPTO_20005,
            D009A + D009C AS IMPORTE_20005,
            '20006' AS PARTIDA_20006,
            'D007A' AS CONCEPTO_20006,
            D007A AS IMPORTE_20006,
            '20007' AS PARTIDA_20007,
            'D020A' AS CONCEPTO_20007,
            D020A AS IMPORTE_20007,
            '' as PT20008,
            '' as CP20008,
            '' as IM20008,
            ROUND(TOT_PERC - TOT_DEDU, 2) as TOT_NETO,
            ROUND(SDOBAS_ISS) as SDO_ISS,
            P016B as despensa,
            0 as prestamos,
            D009A + D009C as CHC,
            D007A as pension,
            TOT_PERC,
            ROUND(tot_dedu - d004a, 2) as TOT_DEDU1,
            TOT_NETO + d004a,
            TIPO
            FROM "+tabla+@" nomina
            LEFT JOIN siri_vigente siri ON siri.rfc = nomina.rfc
            LEFT JOIN confronta ON confronta.curp = nomina.curp
            WHERE d001a > 0
            ORDER BY RFC
               ";


            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sueldo", "sueldo");
                    //Console.WriteLine(command.CommandText);

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
            var query = @"
                SELECT 'C' as ENC0 ,
                DATE_FORMAT(STR_TO_DATE(FEC_PAGO, '%d/%m/%Y'), '%Y%m%d') AS FechaPago,
                '4212300' as ENC1,
                count(TIPO) as ENC2,
                sum(IMPORTE_11301) as IMPORTE_11301,
                sum(IM12201) as IM12201,
                sum(IM12301) as IM12301,
                sum(IM13101) as IM13101,
                sum(IMPORTE_13102) as IMPORTE_13102,
                sum(IM13401) as IM13401,
                sum(IM13402) as IM13402,
                sum(IM13407) as IM13407,
                sum(IM13408) as IM13408,
                sum(IM13411) as IM13411,
                sum(IMPORTE_15403) as IMPORTE_15403,
                sum(IMPORTE_15402) as IMPORTE_15402,
                sum(despensa) as despensa,
                sum(prestamos) as prestamos,
                0 as superissste,
                0 as ade_medico,
                sum(CHC) as CHC,
                sum(pension) as pension,
                0 as faltas,
                0 as retardos,
                ROUND(sum(TOT_PERC),2) as TOT_PERC,
                sum(tot_dedu) as tot_dedu,
                sum(tot_neto) as tot_neto

                from
                (SELECT
                 'D' AS TIPO,
                 IF(confronta.nss is null,siri.nss,confronta.nss) as nss,
                 trim(nomina.nombre) as NOMBRE,
                 trim(nomina.ape_pat) as APE_PAT,
                 trim(nomina.ape_mat) as APE_MAT,
                 nomina.rfc,
                 nomina.curp,
                IF
                 ( SUBSTR( nomina.curp, 11, 1 ) = 'H', 'M', 'F' ) AS sexo,
                 '4212300' AS pagaduria,
                 siri.no_emple,
                 '9999999999' AS NUM_CHEQ,
                 CASE confronta.regimen_pensionario 
                 WHEN 'CUENTAS INDIVIDUALES' THEN
                  2
                 WHEN 'DECIMO TRANSITORIO' THEN
                  1
                END AS Regimen_ISSSTE,

                CASE
                 nomina.tipo 
                 WHEN 'ADM' THEN
                 2 
                 WHEN 'DOC' THEN
                 3 
                 WHEN 'HON' THEN
                 5 
                 END AS TIPO_CONTRATO,
                 nomina.tot_perc,
                 nomina.tot_dedu,
                 '11301' AS PARTIDA_11301,
                  'P001A' AS CONCEPTO_11301,
                  if(P001A>0,P001A,if( p001a = 0 and  tipo='DOC' and P001B>0,P001B,0)) AS IMPORTE_11301,
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
                #------------ BIEN -----------------------	 
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
                 " + tabla + @"	nomina
                 LEFT JOIN siri_vigente siri ON siri.rfc = nomina.rfc
                 left join confronta on confronta.curp = nomina.curp 
                 /* where P001A > 0 and SDOBAS_ISS>0 or ( p001a = 0 and  tipo='DOC' and P001B>0) */
                 )  as resumen
                 GROUP BY QNA_PAGO";


            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sueldo", "sueldo");
                    //Console.WriteLine(command.CommandText);

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
            var query = @"
            SELECT
	            'D' AS TI,
	            IF(confronta.nss is null,siri.nss,confronta.nss) as NSS,
	            trim(nomina.nombre) as NOMBRE,
	            trim(nomina.ape_pat) as APE_PAT,
	            trim(nomina.ape_mat) as APE_MAT,
	            nomina.rfc as RFC,
	            nomina.curp as CURP,
            IF
	            ( SUBSTR( nomina.curp, 11, 1 ) = 'H', 'M', 'F' ) AS SEXO,
	            '4212300' AS PAGADURIA,
	            siri.no_emple as NO_EMPLE,
	            '9999999999' AS NUM_CHEQ,
	            CASE confronta.regimen_pensionario 
	            WHEN 'CUENTAS INDIVIDUALES' THEN
		            2
	            WHEN 'DECIMO TRANSITORIO' THEN
		            1
            END AS REGIMEN_ISSSTE,
	
            CASE
	            nomina.tipo 
	            WHEN 'ADM' THEN
	            2 
	            WHEN 'DOC' THEN
	            3 
	            WHEN 'HON' THEN
	            5 
	            END AS TIPO_CONTRATO,
	            '20230101' AS FINI,
	            '20231031' AS FFIN,
	            nomina.tot_perc as TOT_PERC,
	            nomina.tot_dedu as TOT_DEDU,
	            '11301' AS PARTIDA_11301,
              'P001A' AS CONCEPTO_11301,
              if(P001A>0,P001A,if( p001a = 0 and  tipo='DOC' and P001B>0,P001B,0)) AS IMPORTE_11301,
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
            #------------ BIEN -----------------------	 
		            '10001' AS PARTIDA_10001,
		            'PERCEP' AS CONCEPTO_10001,
		            round(P001B+P001C+P001D+P001E+P002A+P009A+P010A+P016C+P016F+P016G+P016H+P016I+P016J+P016L+
		            +P016M+P016N+P021A+P023A+P034A+P035A+P038A+P038B+P038C+P038D+P038E+P038F+P038G+P038H+P038I+P038J+P038K+
		            +P038L+P039A,2)  as IMPORTE_10001,

	             '10002' AS PARTIDA_10002,
	             'P016B' AS CONCEPTO_10002,
	              P016B AS IMPORTE_10002,
		


            '20001' AS PARTIDA_20001,
            'DEDUC' AS CONCEPTO_20001,
            round(D001A+D001B+D001C+D001D+D001E+D002A+D003E+D004B+D004C+D004D+D004E+D004F+D004G+D004H+
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
		            TOT_PERC,
		            TOT_DEDU,
		            TOT_NETO,TIPO
            FROM
	            "+tabla+@"	nomina
	            LEFT JOIN siri_vigente siri ON siri.rfc = nomina.rfc
	            left join confronta on confronta.curp = nomina.curp 
	            /*where P001A > 0 and SDOBAS_ISS>0 or ( p001a = 0 and  tipo='DOC' and P001B>0)*/
               ";


            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand(query, connection))
                {
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
            var query = @"
                    SELECT
	                    TIPO,
	                    CT,
	                    RFC,
	                    CONCAT_ws( ' ', TRIM( APE_PAT ), TRIM( APE_MAT ), TRIM( NOMBRE ) ) AS nombre,
	                    D004E AS METLIFE,
	                    D004J AS KONDINERO,
	                    D004k AS CREDIFIEL,
	                    D011A AS FONACOT,
                    IF
	                    ( tipo = 'ADM', D019A, 0 ) AS SUTCONALEP,
                    IF
	                    ( tipo = 'DOC', D019A, 0 ) AS SITACONQROO,
	                    D019C AS SITEM 
                    FROM "+tabla+@" 
                    
                    ORDER BY
	                    tipo,
	                    ct,
	                    APE_PAT,
	                    APE_MAT,
	                    NOMBRE
          ";

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand(query, connection))
                {
                 
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
