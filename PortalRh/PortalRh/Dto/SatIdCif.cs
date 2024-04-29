using System.ComponentModel.DataAnnotations;

namespace PortalRh.Dto
{
    public class SatIdCif
    {
        public string? IdCif { get; set; }
        [StringLength(13)]
        public string Rfc { get; set; }
       
    }
}
