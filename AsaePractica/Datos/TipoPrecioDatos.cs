using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AsaePractica.Models;

namespace AsaePractica.Datos
{
    public class TipoPrecioDatos
    {
        public List<TipoPrecioModel> Listar()
        {
            var oLista = new List<TipoPrecioModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IdTipoPrecio], [Nombre], [Precio] FROM [dbo].[TipoPrecio]", conexion);
                cmd.CommandType = CommandType.Text;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new TipoPrecioModel
                        {
                            IdTipoPrecio = Convert.ToInt32(dr["IdTipoPrecio"]),
                            Nombre = dr["Nombre"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"])
                        });
                    }
                }
            }
            return oLista;
        }

        public List<TipoPrecioModel> ListarPorProducto(int idProducto)
        {
            var oLista = new List<TipoPrecioModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT TP.IdTipoPrecio, TP.Nombre, P.Precio FROM TipoPrecio AS TP INNER JOIN Precio AS P ON TP.IdTipoPrecio = P.IdTipoPrecio WHERE  P.IdProducto =  1", conexion);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cmd.CommandType = CommandType.Text;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new TipoPrecioModel
                        {
                            IdTipoPrecio = Convert.ToInt32(dr["IdTipoPrecio"]),
                            Nombre = dr["Nombre"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"])
                        });
                    }
                }
            }
            return oLista;
        }
    }
}
