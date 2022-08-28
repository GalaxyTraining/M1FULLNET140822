using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public decimal? Precio { get; set; }
    }
}
