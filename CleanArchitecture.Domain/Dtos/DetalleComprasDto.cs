using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Dtos
{
    public class DetalleComprasDto
    {
        public int CodigoDetalleCompra { get;set;}

        public int CodigoCompra { get; set; }

        public string  NumeroDocumento { get; set; }

        public string RazonSocial { get; set; }


        public decimal Total { get; set; }


        public string Producto { get; set; }


        public decimal Precio { get; set; }


        public decimal TotalDetalle { get; set; }
    }
}
