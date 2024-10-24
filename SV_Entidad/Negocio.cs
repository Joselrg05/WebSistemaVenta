using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SV_Entidad
{
    public partial class Negocio
    {
        [Key]
        public int IdNegocio { get; set; }
        public string? UrlLogo { get; set; }
        public string? NombreLogo { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? PorcentajeImpuesto { get; set; }
        public string? SimboloMoneda { get; set; }
    }
}
