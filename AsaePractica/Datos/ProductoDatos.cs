using System.Data.SqlClient;
using System.Data;
using AsaePractica.Models;

namespace AsaePractica.Datos
{
    public class ProductoDatos
    {
        public List<ProductoModel> Listar()
        {

            var oLista = new List<ProductoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spSetProduct", conexion);
                cmd.Parameters.AddWithValue("@Accion", 6);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ProductoModel()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            Categoria = dr["Categoria"].ToString(),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }

            }
            return oLista;
        }
    }
}
