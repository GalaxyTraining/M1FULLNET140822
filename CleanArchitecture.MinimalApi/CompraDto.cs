namespace CleanArchitecture.MinimalApi
{
    public class CompraDto
    {
        public int Id { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? RazonSocial { get; set; }
        public decimal? Total { get; set; }

        public virtual ICollection<DetalleCompraDto> DetalleCompras { get; set; }
    }
    public class DetalleCompraDto
    {
        public int Id { get; set; }
        public int? IdCompra { get; set; }
        public string? Producto { get; set; }
        public decimal? Precio { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Total { get; set; }
    }
}
