namespace AsaePractica.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public decimal Precio { get; set; }

        // Propiedades de navegación 
        public ICollection<VentaModel>? Ventas { get; set; }
    }
}
