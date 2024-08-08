using System.Data.SqlClient;
using System.Data;
using AsaePractica.Models;

namespace AsaePractica.Datos
{
    public class VentaDatos
    {
        public List<VentaModel> Listar()
        {

            var oLista = new List<VentaModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
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
            return oLista;
        }

        public VentaModel Obtener(int IdVenta)
        {

            var oVenta = new VentaModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spSetProduct", conexion);
                cmd.Parameters.AddWithValue("@Accion", 2);
                cmd.Parameters.AddWithValue("IdVenta", IdVenta);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oVenta.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                        oVenta.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        oVenta.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        oVenta.Precio = Convert.ToDecimal(dr["Precio"]);

                    }
                }

            }
            return oVenta;
        }
        public bool Guardar(VentaModel oVenta)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
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
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }
        public int Guardar_obtenID(VentaModel oVenta)
        {
            int idVenta = 0;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spSetProduct", conexion);
                    cmd.Parameters.AddWithValue("@Accion", 3);
                    cmd.Parameters.AddWithValue("@IdVenta", oVenta.IdVenta);
                    cmd.Parameters.AddWithValue("@IdProducto", oVenta.IdProducto);
                    cmd.Parameters.AddWithValue("@IdCliente", oVenta.IdCliente);
                    cmd.Parameters.AddWithValue("@IdTipoPrecio", oVenta.IdTipoPrecio);
                    cmd.Parameters.AddWithValue("@Cantidad", oVenta.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", oVenta.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            idVenta = Convert.ToInt32(dr["IdVenta"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                idVenta = 0;
            }

            return idVenta;
        }

        public bool Editar(VentaModel oVenta)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spSetProduct", conexion);
                    cmd.Parameters.AddWithValue("@Accion", 5);
                    cmd.Parameters.AddWithValue("IdVenta", oVenta.IdVenta);
                    cmd.Parameters.AddWithValue("IdProducto", oVenta.IdProducto);
                    cmd.Parameters.AddWithValue("IdCliente", oVenta.IdCliente);
                    cmd.Parameters.AddWithValue("IdTipoPrecio", oVenta.IdTipoPrecio);
                    cmd.Parameters.AddWithValue("Cantidad", oVenta.Cantidad);
                    cmd.Parameters.AddWithValue("Precio", oVenta.Precio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdVenta)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spSetProduct", conexion);
                    cmd.Parameters.AddWithValue("@Accion", 4);
                    cmd.Parameters.AddWithValue("IdVenta", IdVenta);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

    }
}
