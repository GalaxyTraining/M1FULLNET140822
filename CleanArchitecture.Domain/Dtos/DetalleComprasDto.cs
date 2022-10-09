using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Dtos
{
    public class DetalleComprasDto
    {
        public int Id { get; set; }
        public int OrdenSecuencia { get;set;}

        public int IdCompra { get; set; }

        public int Cantidad { get; set; }

        public string  NumeroDocumento { get; set; }

        public string RazonSocial { get; set; }


        public decimal TotalCompra { get; set; }


        public string Producto { get; set; }


        public decimal Precio { get; set; }


        public decimal Total { get; set; }
    }
}
