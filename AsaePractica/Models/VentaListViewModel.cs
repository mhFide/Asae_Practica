namespace AsaePractica.Models
{
    public class VentaListViewModel
    {
        public List<VentaModel>? Ventas { get; set; }
        public List<TipoPrecioModel>? TipoPrecios { get; set; }

        public List<ProductoModel>? Productos { get; set; }
    }
}
