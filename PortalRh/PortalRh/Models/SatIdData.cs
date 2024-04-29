using PortalRh.Dto;
using System.ComponentModel.DataAnnotations;

namespace PortalRh.Models
{
    public class SatIdData
    {
        [Key]
        public Guid Id { get; set; }
        public string? IdCif { get; set; }
        [StringLength(13)]
        public string Rfc { get; set; }
        [StringLength(18)]
        public string Curp { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateOnly Birthday { get; set; }
        public string SituacionContribuyente { get; set; }
        public DateOnly LastUpdateSat { get; set; }
        public Domicilio Domicilio { get; set; }
        public string RegimenFiscal { get; set; }
        public DateOnly FechaAlta { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
    }
}

