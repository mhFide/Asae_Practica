using Microsoft.AspNetCore.Mvc;
using AsaePractica.Datos;
using AsaePractica.Models;

namespace AsaePractica.Controllers
{
    public class MantenedorController : Controller
    {
        VentaDatos _VentaDatos = new VentaDatos();
        TipoPrecioDatos _TipoPrecioDatos = new TipoPrecioDatos();
        ProductoDatos _TipoProdutos = new ProductoDatos();

        public IActionResult Listar(int idProducto)
        {
            
            var oLista = _VentaDatos.Listar();
            var oListaTipoPrecios = _TipoPrecioDatos.ListarPorProducto(idProducto);

            var oListaProductos = _TipoProdutos.Listar();

            // Crear un ViewModel para pasar las listas q se precargan
            var viewModel = new VentaListViewModel
            {
                Ventas = oLista,
                TipoPrecios = oListaTipoPrecios,
                Productos = oListaProductos
            };

            return View(viewModel);
        }
        public IActionResult Guardar()
        {
            //devuelve la vista
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(VentaModel oVenta)
        {
            if(!ModelState.IsValid)
                return View();  

            var respuesta = _VentaDatos.Guardar(oVenta);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }
        public IActionResult Editar(int idVenta)
        {
            //devuelve la vista
            var oventa = _VentaDatos.Obtener(idVenta);
            return View(oventa);
        }
        [HttpPost]
        public IActionResult Editar(VentaModel oVenta)
        {
            //if (!ModelState.IsValid)
            //    return View();

            var respuesta = _VentaDatos.Editar(oVenta);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }
        public IActionResult Eliminar(int idVenta)
        {
            //devuelve la vista
            var oventa = _VentaDatos.Obtener(idVenta);
            return View(oventa);
        }
        [HttpPost]
        public IActionResult Eliminar(VentaModel oVenta)
        {
            var respuesta = _VentaDatos.Eliminar(oVenta.IdVenta);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
           
        [HttpPost]
        public JsonResult GuardarVenta([FromBody] VentaModel venta)
        {
            var respuesta = new { success = false, message = "Error al guardar la venta", idVenta = 0 };
            var ventaDatos = new VentaDatos();
            int idVenta = ventaDatos.Guardar_obtenID(venta);

            if (idVenta > 0)
            {
                respuesta = new { success = true, message = "Venta guardada exitosamente", idVenta = idVenta };
            }

            return Json(respuesta);
        }
    }
}
