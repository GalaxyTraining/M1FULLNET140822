using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infraestructure.Data.Context
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Clave { get; set; }
        public string? Token { get; set; }
    }
}
