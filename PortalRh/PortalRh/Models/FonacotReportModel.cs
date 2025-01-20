﻿using Microsoft.EntityFrameworkCore;

namespace PortalRh.Models
{
    [Keyless]
    public class FonacotReportModel
    {
        public string TIPO { get; set; }
        public string RFC { get; set; }
        public string NOMBRE { get; set; }
        public decimal SDO_BASE { get; set; }
        public decimal IMPORTE { get; set; }
    }
}
