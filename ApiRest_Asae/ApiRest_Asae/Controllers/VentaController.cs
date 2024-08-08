using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiRest_Asae.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ApiRest_Asae.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly string cadenaSQL;

        public VentaController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<VentaModel> oLista = new List<VentaModel>(); 
            try {
                using (var conexion = new SqlConnection(cadenaSQL)) {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spSetProduct", conexion);
                    cmd.Parameters.AddWithValue("@Accion", 1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oProducto = new ProductoModel();
                            oProducto.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                            oProducto.Nombre = dr["Nombre"].ToString();
                            oProducto.Descripcion = dr["Descripcion"].ToString();

                            oLista.Add(new VentaModel()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Total = Convert.ToDecimal(dr["Total"]),
                                Producto = oProducto
                            });
                        }
                    }

                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = oLista });

            } 
            catch (Exception err) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = err.Message, response = oLista });
            }

        }

        [HttpGet]
        [Route("Obtener/{idVenta}")]
        public IActionResult Obtener(int idVenta)
        {
            var oVenta = new VentaModel();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spSetProduct", conexion);
                    cmd.Parameters.AddWithValue("@Accion", 2);
                    cmd.Parameters.AddWithValue("IdVenta", idVenta);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var oProducto = new ProductoModel();
                            oProducto.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                            oProducto.Nombre = dr["Nombre"].ToString();
                            oProducto.Descripcion = dr["Descripcion"].ToString();

                            oVenta.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                            oVenta.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                            oVenta.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                            oVenta.Precio = Convert.ToDecimal(dr["Precio"]);
                            oVenta.Total = Convert.ToDecimal(dr["Total"]);
                            oVenta.Producto = oProducto;
                        }
                    }

                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = oVenta });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = err.Message, response = oVenta });
            }

        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] VentaModel oVenta)
        {            
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {

                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spSetProduct", conexion);
                    cmd.Parameters.AddWithValue("@Accion", 3);
                    cmd.Parameters.AddWithValue("IdVenta", oVenta.IdVenta);
                    cmd.Parameters.AddWithValue("IdProducto", oVenta.IdProducto);
                    cmd.Parameters.AddWithValue("IdCliente", oVenta.IdCliente);
                    cmd.Parameters.AddWithValue("IdTipoPrecio", oVenta.IdTipoPrecio);
                    cmd.Parameters.AddWithValue("Cantidad", oVenta.Cantidad);
                    cmd.Parameters.AddWithValue("Precio", oVenta.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok" });

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = err.Message});
            }

        }

    }
}
