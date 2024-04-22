using System;
using System.ComponentModel.DataAnnotations;

namespace PortalRh.Models
{


    public class Expediente
    {
        [Key]
        public string ExpedienteID { get; set; }

        [MaxLength(18)]
        public string CURP { get; set; }

        [MaxLength(13)]
        public string RFC { get; set; }

        public DateTime FechaValidacionRFC { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Edad { get; set; }

        // Cambiado a tipo Sexo
        public string Sexo { get; set; }

        public string Estado { get; set; }

        public string Municipio { get; set; }

        public string Localidad { get; set; }

        public string Calle { get; set; }

        public int NumeroExterior { get; set; }

        public int NumeroInterior { get; set; }

        public string CodigoPostal { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Correo { get; set; }

        public string NSS { get; set; }

        //ENUM
        public string GrupoSanguineo { get; set; }

        //ENUM
        public string GradoEstudios { get; set; }

        public string OtroEmpleo { get; set; }
    }
}