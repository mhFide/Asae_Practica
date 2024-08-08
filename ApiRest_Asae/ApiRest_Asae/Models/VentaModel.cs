using System.ComponentModel.DataAnnotations;

namespace ApiRest_Asae.Models
{
    public class VentaModel
    {
        public int IdVenta { get; set; }
        [Required(ErrorMessage = "Es obligatorio el Producto")]
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Es obligatorio la cantidad")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Es obligatorio la precio")]
        public decimal Precio { get; set; }
        public DateTime FechaVenta { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTipoPrecio { get; set; }
        public decimal Total { get; set; }

        // Propiedades de navegación 
        public ProductoModel? Producto { get; set; }

        //public Cliente Cliente { get; set; }
    }
}
