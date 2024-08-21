using ClosedXML.Excel;
using Microsoft.JSInterop;
using PortalRh.Models;
using System.Text;

namespace PortalRh.Pages
{
    public partial class Nominas
    {
        private List<RegNominasInfo> regNominasInfo;
        private List<reg_nominas> ListNominas;
        private string selectedDbTable;

        protected override async Task OnInitializedAsync()
        {

            try

            {
                ListNominas = await myService.GetRegNominasDBTableAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexi�n: " + ex.Message);
            }
        }

        private async Task exportExcelConceptos()
        {
            if (string.IsNullOrEmpty(selectedDbTable))
            {
                Console.WriteLine("No se ha seleccionado ninguna tabla.");
                return;
            }

            var list = await myService.GetDetalleTerceros(selectedDbTable);

            try
            {
                // Ruta de la plantilla de Excel
                string rutaPlantilla = "wwwroot/Templates/PagoTerceros.xlsx";

                // Cargar la plantilla
                using (var book = new XLWorkbook(rutaPlantilla))
                {
                    // Acceder a la primera hoja de trabajo de la plantilla
                    IXLWorksheet sheet = book.Worksheet(1);

                    // Llenar datos en la primera hoja
                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];

                        sheet.Cell(row + 2, 1).Value = item.TIPO;
                        sheet.Cell(row + 2, 2).Value = item.CT;
                        sheet.Cell(row + 2, 3).Value = item.RFC;
                        sheet.Cell(row + 2, 4).Value = item.Nombre;
                        sheet.Cell(row + 2, 5).Value = item.METLIFE;
                        sheet.Cell(row + 2, 6).Value = item.KONDINERO;
                        sheet.Cell(row + 2, 7).Value = item.CREDIFIEL;
                        sheet.Cell(row + 2, 8).Value = item.FONACOT;
                        sheet.Cell(row + 2, 9).Value = item.SUTCONALEP;
                        sheet.Cell(row + 2, 10).Value = item.SITACONQROO;
                        sheet.Cell(row + 2, 11).Value = item.SITEM;
                    }

                    IXLWorksheet Metlifesheet = book.Worksheet(2);

                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];

                        Metlifesheet.Cell(row + 2, 1).Value = item.TIPO;
                        Metlifesheet.Cell(row + 2, 2).Value = item.CT;
                        Metlifesheet.Cell(row + 2, 3).Value = item.RFC;
                        Metlifesheet.Cell(row + 2, 4).Value = item.Nombre;
                        Metlifesheet.Cell(row + 2, 5).Value = item.METLIFE;
                    }

                    IXLWorksheet Kondinerosheet = book.Worksheet(3);

                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];

                        Kondinerosheet.Cell(row + 2, 1).Value = item.TIPO;
                        Kondinerosheet.Cell(row + 2, 2).Value = item.CT;
                        Kondinerosheet.Cell(row + 2, 3).Value = item.RFC;
                        Kondinerosheet.Cell(row + 2, 4).Value = item.Nombre;
                        Kondinerosheet.Cell(row + 2, 5).Value = item.KONDINERO;
                    }

                    IXLWorksheet Credifielsheet = book.Worksheet(4);

                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];

                        Credifielsheet.Cell(row + 2, 1).Value = item.TIPO;
                        Credifielsheet.Cell(row + 2, 2).Value = item.CT;
                        Credifielsheet.Cell(row + 2, 3).Value = item.RFC;
                        Credifielsheet.Cell(row + 2, 4).Value = item.Nombre;
                        Credifielsheet.Cell(row + 2, 5).Value = item.CREDIFIEL;
                    }

                    IXLWorksheet Fonacotsheet = book.Worksheet(5);

                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];

                        Fonacotsheet.Cell(row + 2, 1).Value = item.TIPO;
                        Fonacotsheet.Cell(row + 2, 2).Value = item.CT;
                        Fonacotsheet.Cell(row + 2, 3).Value = item.RFC;
                        Fonacotsheet.Cell(row + 2, 4).Value = item.Nombre;
                        Fonacotsheet.Cell(row + 2, 5).Value = item.FONACOT;
                    }

                    IXLWorksheet SutConalepsheet = book.Worksheet(6);

                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];

                        SutConalepsheet.Cell(row + 2, 1).Value = item.TIPO;
                        SutConalepsheet.Cell(row + 2, 2).Value = item.CT;
                        SutConalepsheet.Cell(row + 2, 3).Value = item.RFC;
                        SutConalepsheet.Cell(row + 2, 4).Value = item.Nombre;
                        SutConalepsheet.Cell(row + 2, 5).Value = item.SUTCONALEP;
                    }

                    IXLWorksheet SitaConQroosheet = book.Worksheet(7);

                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];

                        SitaConQroosheet.Cell(row + 2, 1).Value = item.TIPO;
                        SitaConQroosheet.Cell(row + 2, 2).Value = item.CT;
                        SitaConQroosheet.Cell(row + 2, 3).Value = item.RFC;
                        SitaConQroosheet.Cell(row + 2, 4).Value = item.Nombre;
                        SitaConQroosheet.Cell(row + 2, 5).Value = item.SITACONQROO;
                    }

                    IXLWorksheet Sitemsheet = book.Worksheet(8);

                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];

                        Sitemsheet.Cell(row + 2, 1).Value = item.TIPO;
                        Sitemsheet.Cell(row + 2, 2).Value = item.CT;
                        Sitemsheet.Cell(row + 2, 3).Value = item.RFC;
                        Sitemsheet.Cell(row + 2, 4).Value = item.Nombre;
                        Sitemsheet.Cell(row + 2, 5).Value = item.SITEM;
                    }

                    using (var memory = new MemoryStream())
                    {
                        book.SaveAs(memory);
                        var nombreExcel = string.Concat("NOM ", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"), ".xlsx");

                        await _JsService.InvokeAsync<object>(
                            "DownloadExcel",
                            nombreExcel,
                            Convert.ToBase64String(memory.ToArray())
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private async Task ExportarExcelSerica()
        {

            if (string.IsNullOrEmpty(selectedDbTable))
            {
                Console.WriteLine("No se ha seleccionado ninguna tabla.");
                return;
            }
            var list = await myService.GetHeaderSericaPrestamoAsync(selectedDbTable);
            try
            {
                using (var book = new XLWorkbook())
                {

                    IXLWorksheet sheet = book.Worksheets.Add("empleados");

                    sheet.Cell(1, 1).Value = "ENC0";
                    sheet.Cell(1, 2).Value = "ENC1";
                    sheet.Cell(1, 3).Value = "ENC2";
                    sheet.Cell(1, 4).Value = "IMPORTE_11301";
                    sheet.Cell(1, 5).Value = "IM12201";
                    sheet.Cell(1, 6).Value = "IM12301";
                    sheet.Cell(1, 7).Value = "IM13101";
                    sheet.Cell(1, 8).Value = "IMPORTE_13102";
                    sheet.Cell(1, 9).Value = "IM13401";
                    sheet.Cell(1, 10).Value = "IM13402";
                    sheet.Cell(1, 11).Value = "IM13407";
                    sheet.Cell(1, 12).Value = "IM13408";
                    sheet.Cell(1, 13).Value = "IM13411";
                    sheet.Cell(1, 14).Value = "IMPORTE_15403";
                    sheet.Cell(1, 15).Value = "IMPORTE_15402";
                    sheet.Cell(1, 16).Value = "despensa";
                    sheet.Cell(1, 17).Value = "prestamos";
                    sheet.Cell(1, 18).Value = "superissste";
                    sheet.Cell(1, 19).Value = "ade_medico";
                    sheet.Cell(1, 20).Value = "CHC";
                    sheet.Cell(1, 21).Value = "pension";
                    sheet.Cell(1, 22).Value = "faltas";
                    sheet.Cell(1, 23).Value = "retardos";
                    sheet.Cell(1, 24).Value = "TOT_PERC";
                    sheet.Cell(1, 25).Value = "tot_dedu";
                    sheet.Cell(1, 26).Value = "tot_neto";

                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];

                        sheet.Cell(row + 1, 1).Value = item.ENC0;
                        sheet.Cell(row + 1, 2).Value = item.ENC1;
                        sheet.Cell(row + 1, 3).Value = item.ENC2;
                        sheet.Cell(row + 1, 4).Value = item.IMPORTE_11301;
                        sheet.Cell(row + 1, 5).Value = item.IM12201;
                        sheet.Cell(row + 1, 6).Value = item.IM12301;
                        sheet.Cell(row + 1, 7).Value = item.IM13101;
                        sheet.Cell(row + 1, 8).Value = item.IMPORTE_13102;
                        sheet.Cell(row + 1, 9).Value = item.IM13401;
                        sheet.Cell(row + 1, 10).Value = item.IM13402;
                        sheet.Cell(row + 1, 11).Value = item.IM13407;
                        sheet.Cell(row + 1, 12).Value = item.IM13408;
                        sheet.Cell(row + 1, 13).Value = item.IM13411;
                        sheet.Cell(row + 1, 14).Value = item.IMPORTE_15403;
                        sheet.Cell(row + 1, 15).Value = item.IMPORTE_15402;
                        sheet.Cell(row + 1, 16).Value = item.despensa;
                        sheet.Cell(row + 1, 17).Value = item.prestamos;
                        sheet.Cell(row + 1, 18).Value = item.superissste;
                        sheet.Cell(row + 1, 19).Value = item.ade_medico;
                        sheet.Cell(row + 1, 20).Value = item.CHC;
                        sheet.Cell(row + 1, 21).Value = item.pension;
                        sheet.Cell(row + 1, 22).Value = item.faltas;
                        sheet.Cell(row + 1, 23).Value = item.retardos;
                        sheet.Cell(row + 1, 24).Value = item.TOT_PERC;
                        sheet.Cell(row + 1, 25).Value = item.tot_dedu;
                        sheet.Cell(row + 1, 26).Value = item.tot_neto;
                    }

                    using (var Memory = new MemoryStream())
                    {
                        book.SaveAs(Memory);
                        var nombreExcel = string.Concat("NOM-42123004Q ", DateTime.Now.ToString(), ".xlsx");

                        await _JsService.InvokeAsync<object>(
                            "DownloadExcel",
                            nombreExcel,
                            Convert.ToBase64String(Memory.ToArray())
                        );
                    }

                }


            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        private async Task ExportarExcelDetalleSerica()
        {


            if (string.IsNullOrEmpty(selectedDbTable))
            {
                Console.WriteLine("No se ha seleccionado ninguna tabla.");
                return;
            }
            var list = await myService.GetSericaPrestamoAsync(selectedDbTable);
            try
            {

                using (var book = new XLWorkbook())
                {
                    IXLWorksheet sheet = book.Worksheets.Add("empleados");

                    // A�adiendo encabezados
                    sheet.Cell(1, 1).Value = "TIPO";
                    sheet.Cell(1, 2).Value = "NSS";
                    sheet.Cell(1, 3).Value = "NOMBRE";
                    sheet.Cell(1, 4).Value = "APE_PAT";
                    sheet.Cell(1, 5).Value = "APE_MAT";
                    sheet.Cell(1, 6).Value = "RFC";
                    sheet.Cell(1, 7).Value = "CURP";
                    sheet.Cell(1, 8).Value = "SEXO";
                    sheet.Cell(1, 9).Value = "PAGADURIA";
                    sheet.Cell(1, 10).Value = "NO_EMPLE";
                    sheet.Cell(1, 11).Value = "NUM_CHEQ";
                    sheet.Cell(1, 12).Value = "REGIMEN_ISSSTE";
                    sheet.Cell(1, 13).Value = "TIPO_CONTRATO";
                    sheet.Cell(1, 14).Value = "TOT_PERC";
                    sheet.Cell(1, 15).Value = "TOT_DEDU";
                    sheet.Cell(1, 16).Value = "PARTIDA_11301";
                    sheet.Cell(1, 17).Value = "CONCEPTO_11301";
                    sheet.Cell(1, 18).Value = "IMPORTE_11301";
                    sheet.Cell(1, 19).Value = "PT12201";
                    sheet.Cell(1, 20).Value = "CP12201";
                    sheet.Cell(1, 21).Value = "IM12201";
                    sheet.Cell(1, 22).Value = "PT12301";
                    sheet.Cell(1, 23).Value = "CP12301";
                    sheet.Cell(1, 24).Value = "IM12301";
                    sheet.Cell(1, 25).Value = "PT13101";
                    sheet.Cell(1, 26).Value = "CP13101";
                    sheet.Cell(1, 27).Value = "IM13101";
                    sheet.Cell(1, 28).Value = "PARTIDA_13102";
                    sheet.Cell(1, 29).Value = "CONCEPTO_13102";
                    sheet.Cell(1, 30).Value = "IMPORTE_13102";
                    sheet.Cell(1, 31).Value = "IPT13401";
                    sheet.Cell(1, 32).Value = "ICP13401";
                    sheet.Cell(1, 33).Value = "IM13401";
                    sheet.Cell(1, 34).Value = "IPT13402";
                    sheet.Cell(1, 35).Value = "ICP13402";
                    sheet.Cell(1, 36).Value = "IM13402";
                    sheet.Cell(1, 37).Value = "IPT13407";
                    sheet.Cell(1, 38).Value = "ICP13407";
                    sheet.Cell(1, 39).Value = "IM13407";
                    sheet.Cell(1, 40).Value = "IPT13408";
                    sheet.Cell(1, 41).Value = "ICP13408";
                    sheet.Cell(1, 42).Value = "IM13408";
                    sheet.Cell(1, 43).Value = "IPT13411";
                    sheet.Cell(1, 44).Value = "ICP13411";
                    sheet.Cell(1, 45).Value = "IM13411";
                    sheet.Cell(1, 46).Value = "PARTIDA_15403";
                    sheet.Cell(1, 47).Value = "CONCEPTO_15403";
                    sheet.Cell(1, 48).Value = "IMPORTE_15403";
                    sheet.Cell(1, 49).Value = "PARTIDA_15402";
                    sheet.Cell(1, 50).Value = "CONCEPTO_15402";
                    sheet.Cell(1, 51).Value = "IMPORTE_15402";
                    sheet.Cell(1, 52).Value = "PARTIDA_10001";
                    sheet.Cell(1, 53).Value = "CONCEPTO_10001";
                    sheet.Cell(1, 54).Value = "IMPORTE_10001";
                    sheet.Cell(1, 55).Value = "PARTIDA_10002";
                    sheet.Cell(1, 56).Value = "CONCEPTO_10002";
                    sheet.Cell(1, 57).Value = "IMPORTE_10002";
                    sheet.Cell(1, 58).Value = "PARTIDA_20001";
                    sheet.Cell(1, 59).Value = "CONCEPTO_20001";
                    sheet.Cell(1, 60).Value = "IMPORTE_20001";
                    sheet.Cell(1, 61).Value = "PARTIDA_20002";
                    sheet.Cell(1, 62).Value = "CONCEPTO_20002";
                    sheet.Cell(1, 63).Value = "IMPORTE_20002";
                    sheet.Cell(1, 64).Value = "PT20003";
                    sheet.Cell(1, 65).Value = "CP20003";
                    sheet.Cell(1, 66).Value = "IM20003";
                    sheet.Cell(1, 67).Value = "PT20004";
                    sheet.Cell(1, 68).Value = "CP20004";
                    sheet.Cell(1, 69).Value = "IM20004";
                    sheet.Cell(1, 70).Value = "PARTIDA_20005";
                    sheet.Cell(1, 71).Value = "CONCEPTO_20005";
                    sheet.Cell(1, 72).Value = "IMPORTE_20005";
                    sheet.Cell(1, 73).Value = "PARTIDA_20006";
                    sheet.Cell(1, 74).Value = "CONCEPTO_20006";
                    sheet.Cell(1, 75).Value = "IMPORTE_20006";
                    sheet.Cell(1, 76).Value = "PARTIDA_20007";
                    sheet.Cell(1, 77).Value = "CONCEPTO_20007";
                    sheet.Cell(1, 78).Value = "IMPORTE_20007";
                    sheet.Cell(1, 79).Value = "PT20008";
                    sheet.Cell(1, 80).Value = "CP20008";
                    sheet.Cell(1, 81).Value = "IM20008";
                    sheet.Cell(1, 82).Value = "TOT_NETO";
                    sheet.Cell(1, 83).Value = "SDO_ISS";
                    sheet.Cell(1, 84).Value = "DESPENSA";
                    sheet.Cell(1, 85).Value = "PRESTAMOS";
                    sheet.Cell(1, 86).Value = "CHC";
                    sheet.Cell(1, 87).Value = "PENSION";
                    sheet.Cell(1, 88).Value = "TOT_PERC";
                    sheet.Cell(1, 89).Value = "TOT_DEDU";
                    sheet.Cell(1, 90).Value = "TOT_NETO";
                    sheet.Cell(1, 91).Value = "TIPO";
                    // A�adiendo datos
                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];
                        sheet.Cell(row + 1, 1).Value = item.TI;
                        sheet.Cell(row + 1, 2).Value = item.NSS;
                        sheet.Cell(row + 1, 3).Value = item.NOMBRE;
                        sheet.Cell(row + 1, 4).Value = item.APE_PAT;
                        sheet.Cell(row + 1, 5).Value = item.APE_MAT;
                        sheet.Cell(row + 1, 6).Value = item.RFC;
                        sheet.Cell(row + 1, 7).Value = item.CURP;
                        sheet.Cell(row + 1, 8).Value = item.SEXO;
                        sheet.Cell(row + 1, 9).Value = item.PAGADURIA;
                        sheet.Cell(row + 1, 10).Value = item.NO_EMPLE;
                        sheet.Cell(row + 1, 11).Value = item.NUM_CHEQ;
                        sheet.Cell(row + 1, 12).Value = item.REGIMEN_ISSSTE;
                        sheet.Cell(row + 1, 13).Value = item.TIPO_CONTRATO;
                        sheet.Cell(row + 1, 14).Value = item.TOT_PERC;
                        sheet.Cell(row + 1, 15).Value = item.TOT_DEDU;
                        sheet.Cell(row + 1, 16).Value = item.PARTIDA_11301;
                        sheet.Cell(row + 1, 17).Value = item.CONCEPTO_11301;
                        sheet.Cell(row + 1, 18).Value = item.IMPORTE_11301;
                        sheet.Cell(row + 1, 19).Value = item.PT12201;
                        sheet.Cell(row + 1, 20).Value = item.CP12201;
                        sheet.Cell(row + 1, 21).Value = item.IM12201;
                        sheet.Cell(row + 1, 22).Value = item.PT12301;
                        sheet.Cell(row + 1, 23).Value = item.CP12301;
                        sheet.Cell(row + 1, 24).Value = item.IM12301;
                        sheet.Cell(row + 1, 25).Value = item.PT13101;
                        sheet.Cell(row + 1, 26).Value = item.CP13101;
                        sheet.Cell(row + 1, 27).Value = item.IM13101;
                        sheet.Cell(row + 1, 28).Value = item.PARTIDA_13102;
                        sheet.Cell(row + 1, 29).Value = item.CONCEPTO_13102;
                        sheet.Cell(row + 1, 30).Value = item.IMPORTE_13102;
                        sheet.Cell(row + 1, 31).Value = item.IPT13401;
                        sheet.Cell(row + 1, 32).Value = item.ICP13401;
                        sheet.Cell(row + 1, 33).Value = item.IM13401;
                        sheet.Cell(row + 1, 34).Value = item.IPT13402;
                        sheet.Cell(row + 1, 35).Value = item.ICP13402;
                        sheet.Cell(row + 1, 36).Value = item.IM13402;
                        sheet.Cell(row + 1, 37).Value = item.IPT13407;
                        sheet.Cell(row + 1, 38).Value = item.ICP13407;
                        sheet.Cell(row + 1, 39).Value = item.IM13407;
                        sheet.Cell(row + 1, 40).Value = item.IPT13408;
                        sheet.Cell(row + 1, 41).Value = item.ICP13408;
                        sheet.Cell(row + 1, 42).Value = item.IM13408;
                        sheet.Cell(row + 1, 43).Value = item.IPT13411;
                        sheet.Cell(row + 1, 44).Value = item.ICP13411;
                        sheet.Cell(row + 1, 45).Value = item.IM13411;
                        sheet.Cell(row + 1, 46).Value = item.PARTIDA_15403;
                        sheet.Cell(row + 1, 47).Value = item.CONCEPTO_15403;
                        sheet.Cell(row + 1, 48).Value = item.IMPORTE_15403;
                        sheet.Cell(row + 1, 49).Value = item.PARTIDA_15402;
                        sheet.Cell(row + 1, 50).Value = item.CONCEPTO_15402;
                        sheet.Cell(row + 1, 51).Value = item.IMPORTE_15402;
                        sheet.Cell(row + 1, 52).Value = item.PARTIDA_10001;
                        sheet.Cell(row + 1, 53).Value = item.CONCEPTO_10001;
                        sheet.Cell(row + 1, 54).Value = item.IMPORTE_10001;
                        sheet.Cell(row + 1, 55).Value = item.PARTIDA_10002;
                        sheet.Cell(row + 1, 56).Value = item.CONCEPTO_10002;
                        sheet.Cell(row + 1, 57).Value = item.IMPORTE_10002;
                        sheet.Cell(row + 1, 58).Value = item.PARTIDA_20001;
                        sheet.Cell(row + 1, 59).Value = item.CONCEPTO_20001;
                        sheet.Cell(row + 1, 60).Value = item.IMPORTE_20001;
                        sheet.Cell(row + 1, 61).Value = item.PARTIDA_20002;
                        sheet.Cell(row + 1, 62).Value = item.CONCEPTO_20002;
                        sheet.Cell(row + 1, 63).Value = item.IMPORTE_20002;
                        sheet.Cell(row + 1, 64).Value = item.PT20003;
                        sheet.Cell(row + 1, 65).Value = item.CP20003;
                        sheet.Cell(row + 1, 66).Value = item.IM20003;
                        sheet.Cell(row + 1, 67).Value = item.PT20004;
                        sheet.Cell(row + 1, 68).Value = item.CP20004;
                        sheet.Cell(row + 1, 69).Value = item.IM20004;
                        sheet.Cell(row + 1, 70).Value = item.PARTIDA_20005;
                        sheet.Cell(row + 1, 71).Value = item.CONCEPTO_20005;
                        sheet.Cell(row + 1, 72).Value = item.IMPORTE_20005;
                        sheet.Cell(row + 1, 73).Value = item.PARTIDA_20006;
                        sheet.Cell(row + 1, 74).Value = item.CONCEPTO_20006;
                        sheet.Cell(row + 1, 75).Value = item.IMPORTE_20006;
                        sheet.Cell(row + 1, 76).Value = item.PARTIDA_20007;
                        sheet.Cell(row + 1, 77).Value = item.CONCEPTO_20007;
                        sheet.Cell(row + 1, 78).Value = item.IMPORTE_20007;
                        sheet.Cell(row + 1, 79).Value = item.PT20008;
                        sheet.Cell(row + 1, 80).Value = item.CP20008;
                        sheet.Cell(row + 1, 81).Value = item.IM20008;
                        sheet.Cell(row + 1, 82).Value = item.TOT_NETO;
                        sheet.Cell(row + 1, 83).Value = item.SDO_ISS;
                        sheet.Cell(row + 1, 84).Value = item.DESPENSA;
                        sheet.Cell(row + 1, 85).Value = item.PRESTAMOS;
                        sheet.Cell(row + 1, 86).Value = item.CHC;
                        sheet.Cell(row + 1, 87).Value = item.PENSION;
                        sheet.Cell(row + 1, 88).Value = item.TOT_PERC;
                        sheet.Cell(row + 1, 89).Value = item.TOT_DEDU;
                        sheet.Cell(row + 1, 90).Value = item.TOT_NETO;
                        sheet.Cell(row + 1, 91).Value = item.Tipo;

                    }

                    using (var Memory = new MemoryStream())
                    {
                        book.SaveAs(Memory);
                        var nombreExcel = string.Concat("NOM-42123004Q ", DateTime.Now.ToString("yyyyMMdd_HHmmss"), ".xlsx");

                        await _JsService.InvokeAsync<object>(
                            "DownloadExcel",
                            nombreExcel,
                            Convert.ToBase64String(Memory.ToArray())
                        );
                    }


                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }



        private async Task ExportarTxtSerica()
        {

            if (string.IsNullOrEmpty(selectedDbTable))
            {
                Console.WriteLine("No se ha seleccionado ninguna tabla.");
                return;
            }
            var header = await myService.GetHeaderSericaPrestamoAsync(selectedDbTable);
            var list = await myService.GetSericaPrestamoAsync(selectedDbTable);

            try
            {
                var sb = new StringBuilder();
                //A�ade encabezado
                foreach (var item in header)

                    sb.AppendLine($"{item.ENC0}|{item.ENC1}|{item.ENC2}|{item.IMPORTE_11301}|{item.IM12201}|{item.IM12301}|{item.IM13101}|{item.IMPORTE_13102}|{item.IM13401}|{item.IM13402}|{item.IM13407}|{item.IM13408}|{item.IM13411}|{item.IMPORTE_15403}|{item.IMPORTE_15402}|{item.despensa}|{item.prestamos}|{item.superissste}|{item.ade_medico}|{item.CHC}|{item.pension}|{item.faltas}|{item.retardos}|{item.TOT_PERC}|{item.tot_dedu}|{item.tot_neto}");

                // a�ade datos
                foreach (var item in list)
                {
                    sb.AppendLine($"{item.TI}|{item.NSS}|{item.NOMBRE}|{item.APE_PAT}|{item.APE_MAT}|{item.RFC}|{item.CURP}|{item.SEXO}|{item.PAGADURIA}|{item.NO_EMPLE}|{item.NUM_CHEQ}|{item.REGIMEN_ISSSTE}|{item.TIPO_CONTRATO}|{item.TOT_PERC}|{item.TOT_DEDU}|{item.PARTIDA_11301}|{item.CONCEPTO_11301}|{item.IMPORTE_11301}|{item.PT12201}|{item.CP12201}|{item.IM12201}|{item.PT12301}|{item.CP12301}|{item.IM12301}|{item.PT13101}|{item.CP13101}|{item.IM13101}|{item.PARTIDA_13102}|{item.CONCEPTO_13102}|{item.IMPORTE_13102}|{item.IPT13401}|{item.ICP13401}|{item.IM13401}|{item.IPT13402}|{item.ICP13402}|{item.IM13402}|{item.IPT13407}|{item.ICP13407}|{item.IM13407}|{item.IPT13408}|{item.ICP13408}|{item.IM13408}|{item.IPT13411}|{item.ICP13411}|{item.IM13411}|{item.PARTIDA_15403}|{item.CONCEPTO_15403}|{item.IMPORTE_15403}|{item.PARTIDA_15402}|{item.CONCEPTO_15402}|{item.IMPORTE_15402}|{item.PARTIDA_10001}|{item.CONCEPTO_10001}|{item.IMPORTE_10001}|{item.PARTIDA_10002}|{item.CONCEPTO_10002}|{item.IMPORTE_10002}|{item.PARTIDA_20001}|{item.CONCEPTO_20001}|{item.IMPORTE_20001}|{item.PARTIDA_20002}|{item.CONCEPTO_20002}|{item.IMPORTE_20002}|{item.PT20003}|{item.CP20003}|{item.IM20003}|{item.PT20004}|{item.CP20004}|{item.IM20004}|{item.PARTIDA_20005}|{item.CONCEPTO_20005}|{item.IMPORTE_20005}|{item.PARTIDA_20006}|{item.CONCEPTO_20006}|{item.IMPORTE_20006}|{item.PARTIDA_20007}|{item.CONCEPTO_20007}|{item.IMPORTE_20007}|{item.PT20008}|{item.CP20008}|{item.IM20008}|{item.TOT_NETO}|{item.SDO_ISS}|{item.DESPENSA}|{item.PRESTAMOS}|{item.CHC}|{item.PENSION}|{item.TOT_PERC}|{item.TOT_DEDU}|{item.TOT_NETO}|{item.Tipo}");
                }

                var TxtName = string.Concat("NOM-42123004Q", DateTime.Now.ToString("yyyyMMdd_HHmmss"), ".txt");
                var byteArray = Encoding.UTF8.GetBytes(sb.ToString());

                await _JsService.InvokeAsync<object>(
                    "DownloadTxt",
                    TxtName,
                    Convert.ToBase64String(byteArray)
                );
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private async Task ExportarTxtSericaPrestamos()
        {


            if (string.IsNullOrEmpty(selectedDbTable))
            {
                Console.WriteLine("No se ha seleccionado ninguna tabla.");
                return;
            }
            var header = await myService.GetHeaderSericaPrestamoAsync(selectedDbTable);
            var list = await myService.GetSericaPrestamoAsync(selectedDbTable);


            var A�oQuincena = "4Q" + selectedDbTable.Substring(7, 4) + selectedDbTable.Substring(12, 2) + "O2";
            try
            {
                var sb = new StringBuilder();
                //A�ade encabezado
                foreach (var item in header)

                    sb.AppendLine($"{item.ENC0}|{item.ENC1 + A�oQuincena}|{item.FechaPago}|{item.ENC1}|{item.ENC2}|{item.ENC2}|{item.ENC2}|{item.IMPORTE_11301}|{item.IM12201}|{item.IM12301}|{item.IM13101}|{item.IMPORTE_13102}|{item.IM13401}|{item.IM13402}|{item.IM13407}|{item.IM13408}|{item.IM13411}|{item.IMPORTE_15403}|{item.IMPORTE_15402}|{item.despensa}|{item.prestamos}|{item.superissste}|{item.ade_medico}|{item.CHC}|{item.pension}|{item.faltas}|{item.retardos}|{item.TOT_PERC}|{item.tot_dedu}|{item.tot_neto}");

                // a�ade datos
                foreach (var item in list)
                {
                    sb.AppendLine($"{item.TI}|{item.NSS}|{item.NOMBRE}|{item.APE_PAT}|{item.APE_MAT}|{item.RFC}|{item.CURP}|{item.SEXO}|{item.PAGADURIA}|{item.NO_EMPLE}|{item.NUM_CHEQ}|{item.REGIMEN_ISSSTE}|{item.TIPO_CONTRATO}|{item.TOT_PERC}|{item.TOT_DEDU}|{item.PARTIDA_11301}|{item.CONCEPTO_11301}|{item.IMPORTE_11301}|{item.PT12201}|{item.CP12201}|{item.IM12201}|{item.PT12301}|{item.CP12301}|{item.IM12301}|{item.PT13101}|{item.CP13101}|{item.IM13101}|{item.PARTIDA_13102}|{item.CONCEPTO_13102}|{item.IMPORTE_13102}|{item.IPT13401}|{item.ICP13401}|{item.IM13401}|{item.IPT13402}|{item.ICP13402}|{item.IM13402}|{item.IPT13407}|{item.ICP13407}|{item.IM13407}|{item.IPT13408}|{item.ICP13408}|{item.IM13408}|{item.IPT13411}|{item.ICP13411}|{item.IM13411}|{item.PARTIDA_15403}|{item.CONCEPTO_15403}|{item.IMPORTE_15403}|{item.PARTIDA_15402}|{item.CONCEPTO_15402}|{item.IMPORTE_15402}|{item.PARTIDA_10001}|{item.CONCEPTO_10001}|{item.IMPORTE_10001}|{item.PARTIDA_10002}|{item.CONCEPTO_10002}|{item.IMPORTE_10002}|{item.PARTIDA_20001}|{item.CONCEPTO_20001}|{item.IMPORTE_20001}|{item.PARTIDA_20002}|{item.CONCEPTO_20002}|{item.IMPORTE_20002}|{item.PT20003}|{item.CP20003}|{item.IM20003}|{item.PT20004}|{item.CP20004}|{item.IM20004}|{item.PARTIDA_20005}|{item.CONCEPTO_20005}|{item.IMPORTE_20005}|{item.PARTIDA_20006}|{item.CONCEPTO_20006}|{item.IMPORTE_20006}|{item.PARTIDA_20007}|{item.CONCEPTO_20007}|{item.IMPORTE_20007}");
                }

                var TxtName = string.Concat("NOM-4212300", A�oQuincena, ".txt");
                var byteArray = Encoding.UTF8.GetBytes(sb.ToString());

                await _JsService.InvokeAsync<object>(
                    "DownloadTxt",
                    TxtName,
                    Convert.ToBase64String(byteArray)
                );
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        //listo
        private async Task ExportarTxtSericaSPrestamos()
        {

            if (string.IsNullOrEmpty(selectedDbTable))
            {
                Console.WriteLine("No se ha seleccionado ninguna tabla.");
                return;
            }
            var header = await myService.GetHeaderSericaSinPrestamo(selectedDbTable);
            var list = await myService.GetSericaSinPrestamo(selectedDbTable);
            var A�oQuincena = "4Q" + selectedDbTable.Substring(7, 4) + selectedDbTable.Substring(12, 2) + "O1";
            try
            {
                var sb = new StringBuilder();
                //A�ade encabezado
                foreach (var item in header)

                    sb.AppendLine($"{item.ENC0}|{item.ENC1 + A�oQuincena}|{item.FechaPago}|{item.ENC1}|{item.ENC2}|{item.ENC2}|{item.ENC2}|{item.IMPORTE_11301}|{item.IM12201}|{item.IM12301}|{item.IM13101}|{item.IMPORTE_13102}|{item.IM13401}|{item.IM13402}|{item.IM13407}|{item.IM13408}|{item.IM13411}|{item.IMPORTE_15403}|{item.IMPORTE_15402}|{item.despensa}|{item.prestamos}|{item.superissste}|{item.ade_medico}|{item.CHC}|{item.pension}|{item.faltas}|{item.retardos}|{item.TOT_PERC}|{item.tot_dedu}|{item.tot_neto}");

                // a�ade datos
                foreach (var item in list)
                {
                    sb.AppendLine($"{item.TI}|{item.NSS}|{item.NOMBRE}|{item.APE_PAT}|{item.APE_MAT}|{item.RFC}|{item.CURP}|{item.SEXO}|{item.PAGADURIA}|{item.NO_EMPLE}|{item.NUM_CHEQ}|{item.REGIMEN_ISSSTE}|{item.TIPO_CONTRATO}|{item.TOT_PERC}|{item.TOT_DEDU1}|{item.PARTIDA_11301}|{item.CONCEPTO_11301}|{item.IMPORTE_11301}|{item.PT12201}|{item.CP12201}|{item.IM12201}|{item.PT12301}|{item.CP12301}|{item.IM12301}|{item.PT13101}|{item.CP13101}|{item.IM13101}|{item.PARTIDA_13102}|{item.CONCEPTO_13102}|{item.IMPORTE_13102}|{item.IPT13401}|{item.ICP13401}|{item.IM13401}|{item.IPT13402}|{item.ICP13402}|{item.IM13402}|{item.IPT13407}|{item.ICP13407}|{item.IM13407}|{item.IPT13408}|{item.ICP13408}|{item.IM13408}|{item.IPT13411}|{item.ICP13411}|{item.IM13411}|{item.PARTIDA_15403}|{item.CONCEPTO_15403}|{item.IMPORTE_15403}|{item.PARTIDA_15402}|{item.CONCEPTO_15402}|{item.IMPORTE_15402}|{item.PARTIDA_10001}|{item.CONCEPTO_10001}|{item.IMPORTE_10001}|{item.PARTIDA_10002}|{item.CONCEPTO_10002}|{item.IMPORTE_10002}|{item.PARTIDA_20001}|{item.CONCEPTO_20001}|{item.IMPORTE_20001}|{item.PARTIDA_20002}|{item.CONCEPTO_20002}|{item.IMPORTE_20002}|{item.PT20003}|{item.CP20003}|{item.IM20003}|{item.PT20004}|{item.CP20004}|{item.IM20004}|{item.PARTIDA_20005}|{item.CONCEPTO_20005}|{item.IMPORTE_20005}|{item.PARTIDA_20006}|{item.CONCEPTO_20006}|{item.IMPORTE_20006}|{item.PARTIDA_20007}|{item.CONCEPTO_20007}|{item.IMPORTE_20007}");
                }

                var TxtName = string.Concat("NOM-4212300", A�oQuincena, ".txt");
                var byteArray = Encoding.UTF8.GetBytes(sb.ToString());

                await _JsService.InvokeAsync<object>(
                    "DownloadTxt",
                    TxtName,
                    Convert.ToBase64String(byteArray)
                );
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private async Task ExportarTxtSericaIncremento()
        {


            if (string.IsNullOrEmpty(selectedDbTable))
            {
                Console.WriteLine("No se ha seleccionado ninguna tabla.");
                return;
            }
            var header = await myService.GetHeaderSericaIncremento(selectedDbTable);
            var list = await myService.GetSericaIncremento(selectedDbTable);
            var A�oQuincena = "4Q" + selectedDbTable.Substring(7, 4) + selectedDbTable.Substring(12, 2) + "I1";
            try
            {
                var sb = new StringBuilder();
                //A�ade encabezado
                foreach (var item in header)

                    sb.AppendLine($"{item.ENC0}|{item.ENC1 + A�oQuincena}|{item.FechaPago}|{item.ENC1}|{item.ENC2}|{item.ENC2}|{item.ENC2}|{item.IMPORTE_11301}|{item.IM12201}|{item.IM12301}|{item.IM13101}|{item.IMPORTE_13102}|{item.IM13401}|{item.IM13402}|{item.IM13407}|{item.IM13408}|{item.IM13411}|{item.IMPORTE_15403}|{item.IMPORTE_15402}|{item.despensa}|{item.prestamos}|{item.superissste}|{item.ade_medico}|{item.CHC}|{item.pension}|{item.faltas}|{item.retardos}|{item.TOT_PERC}|{item.tot_dedu}|{item.tot_neto}");

                // a�ade datos
                foreach (var item in list)
                {
                    sb.AppendLine($"{item.TI}|{item.NSS}|{item.NOMBRE}|{item.APE_PAT}|{item.APE_MAT}|{item.RFC}|{item.CURP}|{item.SEXO}|{item.PAGADURIA}|{item.NO_EMPLE}|{item.NUM_CHEQ}|{item.REGIMEN_ISSSTE}|{item.TIPO_CONTRATO}|{item.TOT_PERC}|{item.TOT_DEDU1}|{item.PARTIDA_11301}|{item.CONCEPTO_11301}|{item.IMPORTE_11301}|{item.PT12201}|{item.CP12201}|{item.IM12201}|{item.PT12301}|{item.CP12301}|{item.IM12301}|{item.PT13101}|{item.CP13101}|{item.IM13101}|{item.PARTIDA_13102}|{item.CONCEPTO_13102}|{item.IMPORTE_13102}|{item.IPT13401}|{item.ICP13401}|{item.IM13401}|{item.IPT13402}|{item.ICP13402}|{item.IM13402}|{item.IPT13407}|{item.ICP13407}|{item.IM13407}|{item.IPT13408}|{item.ICP13408}|{item.IM13408}|{item.IPT13411}|{item.ICP13411}|{item.IM13411}|{item.PARTIDA_15403}|{item.CONCEPTO_15403}|{item.IMPORTE_15403}|{item.PARTIDA_15402}|{item.CONCEPTO_15402}|{item.IMPORTE_15402}|{item.PARTIDA_10001}|{item.CONCEPTO_10001}|{item.IMPORTE_10001}|{item.PARTIDA_10002}|{item.CONCEPTO_10002}|{item.IMPORTE_10002}|{item.PARTIDA_20001}|{item.CONCEPTO_20001}|{item.IMPORTE_20001}|{item.PARTIDA_20002}|{item.CONCEPTO_20002}|{item.IMPORTE_20002}|{item.PT20003}|{item.CP20003}|{item.IM20003}|{item.PT20004}|{item.CP20004}|{item.IM20004}|{item.PARTIDA_20005}|{item.CONCEPTO_20005}|{item.IMPORTE_20005}|{item.PARTIDA_20006}|{item.CONCEPTO_20006}|{item.IMPORTE_20006}|{item.PARTIDA_20007}|{item.CONCEPTO_20007}|{item.IMPORTE_20007}");
                }

                var TxtName = string.Concat("NOM-4212300", A�oQuincena, ".txt");
                var byteArray = Encoding.UTF8.GetBytes(sb.ToString());

                await _JsService.InvokeAsync<object>(
                    "DownloadTxt",
                    TxtName,
                    Convert.ToBase64String(byteArray)
                );
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        private async Task ExportarExcelDetalleTerceros()
        {


            if (string.IsNullOrEmpty(selectedDbTable))
            {
                Console.WriteLine("No se ha seleccionado ninguna tabla.");
                return;
            }
            var list = await myService.GetSericaPrestamoAsync(selectedDbTable);
            try
            {

                using (var book = new XLWorkbook())
                {
                    IXLWorksheet sheet = book.Worksheets.Add("empleados");

                    // A�adiendo encabezados
                    sheet.Cell(1, 1).Value = "TIPO";
                    sheet.Cell(1, 2).Value = "NSS";
                    sheet.Cell(1, 3).Value = "NOMBRE";
                    sheet.Cell(1, 4).Value = "APE_PAT";
                    sheet.Cell(1, 5).Value = "APE_MAT";
                    sheet.Cell(1, 6).Value = "RFC";
                    sheet.Cell(1, 7).Value = "CURP";
                    sheet.Cell(1, 8).Value = "SEXO";
                    sheet.Cell(1, 9).Value = "PAGADURIA";
                    sheet.Cell(1, 10).Value = "NO_EMPLE";
                    sheet.Cell(1, 11).Value = "NUM_CHEQ";
                    sheet.Cell(1, 12).Value = "REGIMEN_ISSSTE";
                    sheet.Cell(1, 13).Value = "TIPO_CONTRATO";
                    sheet.Cell(1, 14).Value = "TOT_PERC";
                    sheet.Cell(1, 15).Value = "TOT_DEDU";
                    sheet.Cell(1, 16).Value = "PARTIDA_11301";
                    sheet.Cell(1, 17).Value = "CONCEPTO_11301";
                    sheet.Cell(1, 18).Value = "IMPORTE_11301";
                    sheet.Cell(1, 19).Value = "PT12201";
                    sheet.Cell(1, 20).Value = "CP12201";
                    sheet.Cell(1, 21).Value = "IM12201";
                    sheet.Cell(1, 22).Value = "PT12301";
                    sheet.Cell(1, 23).Value = "CP12301";
                    sheet.Cell(1, 24).Value = "IM12301";
                    sheet.Cell(1, 25).Value = "PT13101";
                    sheet.Cell(1, 26).Value = "CP13101";
                    sheet.Cell(1, 27).Value = "IM13101";
                    sheet.Cell(1, 28).Value = "PARTIDA_13102";
                    sheet.Cell(1, 29).Value = "CONCEPTO_13102";
                    sheet.Cell(1, 30).Value = "IMPORTE_13102";
                    sheet.Cell(1, 31).Value = "IPT13401";
                    sheet.Cell(1, 32).Value = "ICP13401";
                    sheet.Cell(1, 33).Value = "IM13401";
                    sheet.Cell(1, 34).Value = "IPT13402";
                    sheet.Cell(1, 35).Value = "ICP13402";
                    sheet.Cell(1, 36).Value = "IM13402";
                    sheet.Cell(1, 37).Value = "IPT13407";
                    sheet.Cell(1, 38).Value = "ICP13407";
                    sheet.Cell(1, 39).Value = "IM13407";
                    sheet.Cell(1, 40).Value = "IPT13408";
                    sheet.Cell(1, 41).Value = "ICP13408";
                    sheet.Cell(1, 42).Value = "IM13408";
                    sheet.Cell(1, 43).Value = "IPT13411";
                    sheet.Cell(1, 44).Value = "ICP13411";
                    sheet.Cell(1, 45).Value = "IM13411";
                    sheet.Cell(1, 46).Value = "PARTIDA_15403";
                    sheet.Cell(1, 47).Value = "CONCEPTO_15403";
                    sheet.Cell(1, 48).Value = "IMPORTE_15403";
                    sheet.Cell(1, 49).Value = "PARTIDA_15402";
                    sheet.Cell(1, 50).Value = "CONCEPTO_15402";
                    sheet.Cell(1, 51).Value = "IMPORTE_15402";
                    sheet.Cell(1, 52).Value = "PARTIDA_10001";
                    sheet.Cell(1, 53).Value = "CONCEPTO_10001";
                    sheet.Cell(1, 54).Value = "IMPORTE_10001";
                    sheet.Cell(1, 55).Value = "PARTIDA_10002";
                    sheet.Cell(1, 56).Value = "CONCEPTO_10002";
                    sheet.Cell(1, 57).Value = "IMPORTE_10002";
                    sheet.Cell(1, 58).Value = "PARTIDA_20001";
                    sheet.Cell(1, 59).Value = "CONCEPTO_20001";
                    sheet.Cell(1, 60).Value = "IMPORTE_20001";
                    sheet.Cell(1, 61).Value = "PARTIDA_20002";
                    sheet.Cell(1, 62).Value = "CONCEPTO_20002";
                    sheet.Cell(1, 63).Value = "IMPORTE_20002";
                    sheet.Cell(1, 64).Value = "PT20003";
                    sheet.Cell(1, 65).Value = "CP20003";
                    sheet.Cell(1, 66).Value = "IM20003";
                    sheet.Cell(1, 67).Value = "PT20004";
                    sheet.Cell(1, 68).Value = "CP20004";
                    sheet.Cell(1, 69).Value = "IM20004";
                    sheet.Cell(1, 70).Value = "PARTIDA_20005";
                    sheet.Cell(1, 71).Value = "CONCEPTO_20005";
                    sheet.Cell(1, 72).Value = "IMPORTE_20005";
                    sheet.Cell(1, 73).Value = "PARTIDA_20006";
                    sheet.Cell(1, 74).Value = "CONCEPTO_20006";
                    sheet.Cell(1, 75).Value = "IMPORTE_20006";
                    sheet.Cell(1, 76).Value = "PARTIDA_20007";
                    sheet.Cell(1, 77).Value = "CONCEPTO_20007";
                    sheet.Cell(1, 78).Value = "IMPORTE_20007";
                    sheet.Cell(1, 79).Value = "PT20008";
                    sheet.Cell(1, 80).Value = "CP20008";
                    sheet.Cell(1, 81).Value = "IM20008";
                    sheet.Cell(1, 82).Value = "TOT_NETO";
                    sheet.Cell(1, 83).Value = "SDO_ISS";
                    sheet.Cell(1, 84).Value = "DESPENSA";
                    sheet.Cell(1, 85).Value = "PRESTAMOS";
                    sheet.Cell(1, 86).Value = "CHC";
                    sheet.Cell(1, 87).Value = "PENSION";
                    sheet.Cell(1, 88).Value = "TOT_PERC";
                    sheet.Cell(1, 89).Value = "TOT_DEDU";
                    sheet.Cell(1, 90).Value = "TOT_NETO";
                    sheet.Cell(1, 91).Value = "TIPO";
                    // A�adiendo datos
                    for (int row = 1; row <= list.Count; row++)
                    {
                        var item = list[row - 1];
                        sheet.Cell(row + 1, 1).Value = item.TI;
                        sheet.Cell(row + 1, 2).Value = item.NSS;
                        sheet.Cell(row + 1, 3).Value = item.NOMBRE;
                        sheet.Cell(row + 1, 4).Value = item.APE_PAT;
                        sheet.Cell(row + 1, 5).Value = item.APE_MAT;
                        sheet.Cell(row + 1, 6).Value = item.RFC;
                        sheet.Cell(row + 1, 7).Value = item.CURP;
                        sheet.Cell(row + 1, 8).Value = item.SEXO;
                        sheet.Cell(row + 1, 9).Value = item.PAGADURIA;
                        sheet.Cell(row + 1, 10).Value = item.NO_EMPLE;
                        sheet.Cell(row + 1, 11).Value = item.NUM_CHEQ;
                        sheet.Cell(row + 1, 12).Value = item.REGIMEN_ISSSTE;
                        sheet.Cell(row + 1, 13).Value = item.TIPO_CONTRATO;
                        sheet.Cell(row + 1, 14).Value = item.TOT_PERC;
                        sheet.Cell(row + 1, 15).Value = item.TOT_DEDU;
                        sheet.Cell(row + 1, 16).Value = item.PARTIDA_11301;
                        sheet.Cell(row + 1, 17).Value = item.CONCEPTO_11301;
                        sheet.Cell(row + 1, 18).Value = item.IMPORTE_11301;
                        sheet.Cell(row + 1, 19).Value = item.PT12201;
                        sheet.Cell(row + 1, 20).Value = item.CP12201;
                        sheet.Cell(row + 1, 21).Value = item.IM12201;
                        sheet.Cell(row + 1, 22).Value = item.PT12301;
                        sheet.Cell(row + 1, 23).Value = item.CP12301;
                        sheet.Cell(row + 1, 24).Value = item.IM12301;
                        sheet.Cell(row + 1, 25).Value = item.PT13101;
                        sheet.Cell(row + 1, 26).Value = item.CP13101;
                        sheet.Cell(row + 1, 27).Value = item.IM13101;
                        sheet.Cell(row + 1, 28).Value = item.PARTIDA_13102;
                        sheet.Cell(row + 1, 29).Value = item.CONCEPTO_13102;
                        sheet.Cell(row + 1, 30).Value = item.IMPORTE_13102;
                        sheet.Cell(row + 1, 31).Value = item.IPT13401;
                        sheet.Cell(row + 1, 32).Value = item.ICP13401;
                        sheet.Cell(row + 1, 33).Value = item.IM13401;
                        sheet.Cell(row + 1, 34).Value = item.IPT13402;
                        sheet.Cell(row + 1, 35).Value = item.ICP13402;
                        sheet.Cell(row + 1, 36).Value = item.IM13402;
                        sheet.Cell(row + 1, 37).Value = item.IPT13407;
                        sheet.Cell(row + 1, 38).Value = item.ICP13407;
                        sheet.Cell(row + 1, 39).Value = item.IM13407;
                        sheet.Cell(row + 1, 40).Value = item.IPT13408;
                        sheet.Cell(row + 1, 41).Value = item.ICP13408;
                        sheet.Cell(row + 1, 42).Value = item.IM13408;
                        sheet.Cell(row + 1, 43).Value = item.IPT13411;
                        sheet.Cell(row + 1, 44).Value = item.ICP13411;
                        sheet.Cell(row + 1, 45).Value = item.IM13411;
                        sheet.Cell(row + 1, 46).Value = item.PARTIDA_15403;
                        sheet.Cell(row + 1, 47).Value = item.CONCEPTO_15403;
                        sheet.Cell(row + 1, 48).Value = item.IMPORTE_15403;
                        sheet.Cell(row + 1, 49).Value = item.PARTIDA_15402;
                        sheet.Cell(row + 1, 50).Value = item.CONCEPTO_15402;
                        sheet.Cell(row + 1, 51).Value = item.IMPORTE_15402;
                        sheet.Cell(row + 1, 52).Value = item.PARTIDA_10001;
                        sheet.Cell(row + 1, 53).Value = item.CONCEPTO_10001;
                        sheet.Cell(row + 1, 54).Value = item.IMPORTE_10001;
                        sheet.Cell(row + 1, 55).Value = item.PARTIDA_10002;
                        sheet.Cell(row + 1, 56).Value = item.CONCEPTO_10002;
                        sheet.Cell(row + 1, 57).Value = item.IMPORTE_10002;
                        sheet.Cell(row + 1, 58).Value = item.PARTIDA_20001;
                        sheet.Cell(row + 1, 59).Value = item.CONCEPTO_20001;
                        sheet.Cell(row + 1, 60).Value = item.IMPORTE_20001;
                        sheet.Cell(row + 1, 61).Value = item.PARTIDA_20002;
                        sheet.Cell(row + 1, 62).Value = item.CONCEPTO_20002;
                        sheet.Cell(row + 1, 63).Value = item.IMPORTE_20002;
                        sheet.Cell(row + 1, 64).Value = item.PT20003;
                        sheet.Cell(row + 1, 65).Value = item.CP20003;
                        sheet.Cell(row + 1, 66).Value = item.IM20003;
                        sheet.Cell(row + 1, 67).Value = item.PT20004;
                        sheet.Cell(row + 1, 68).Value = item.CP20004;
                        sheet.Cell(row + 1, 69).Value = item.IM20004;
                        sheet.Cell(row + 1, 70).Value = item.PARTIDA_20005;
                        sheet.Cell(row + 1, 71).Value = item.CONCEPTO_20005;
                        sheet.Cell(row + 1, 72).Value = item.IMPORTE_20005;
                        sheet.Cell(row + 1, 73).Value = item.PARTIDA_20006;
                        sheet.Cell(row + 1, 74).Value = item.CONCEPTO_20006;
                        sheet.Cell(row + 1, 75).Value = item.IMPORTE_20006;
                        sheet.Cell(row + 1, 76).Value = item.PARTIDA_20007;
                        sheet.Cell(row + 1, 77).Value = item.CONCEPTO_20007;
                        sheet.Cell(row + 1, 78).Value = item.IMPORTE_20007;
                        sheet.Cell(row + 1, 79).Value = item.PT20008;
                        sheet.Cell(row + 1, 80).Value = item.CP20008;
                        sheet.Cell(row + 1, 81).Value = item.IM20008;
                        sheet.Cell(row + 1, 82).Value = item.TOT_NETO;
                        sheet.Cell(row + 1, 83).Value = item.SDO_ISS;
                        sheet.Cell(row + 1, 84).Value = item.DESPENSA;
                        sheet.Cell(row + 1, 85).Value = item.PRESTAMOS;
                        sheet.Cell(row + 1, 86).Value = item.CHC;
                        sheet.Cell(row + 1, 87).Value = item.PENSION;
                        sheet.Cell(row + 1, 88).Value = item.TOT_PERC;
                        sheet.Cell(row + 1, 89).Value = item.TOT_DEDU;
                        sheet.Cell(row + 1, 90).Value = item.TOT_NETO;
                        sheet.Cell(row + 1, 91).Value = item.Tipo;

                    }

                    using (var Memory = new MemoryStream())
                    {
                        book.SaveAs(Memory);
                        var nombreExcel = string.Concat("NOM-42123004Q ", DateTime.Now.ToString("yyyyMMdd_HHmmss"), ".xlsx");

                        await _JsService.InvokeAsync<object>(
                            "DownloadExcel",
                            nombreExcel,
                            Convert.ToBase64String(Memory.ToArray())
                        );
                    }

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

    }
}