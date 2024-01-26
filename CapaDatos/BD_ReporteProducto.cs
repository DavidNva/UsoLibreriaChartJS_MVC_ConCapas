using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
namespace CapaDatos
{
    public class BD_ReporteProducto
    {
        public List<EN_ReporteProducto> RetornarProductos()
        {
            List<EN_ReporteProducto> objLista = new List<EN_ReporteProducto>();

            //Data Source=;Initial Catalog= ; User ID= ; Password=
            using (SqlConnection oconexion = new SqlConnection("Data Source=David\\DAVIDN4; Initial Catalog=AdventureWorks2014; Integrated Security=True"))
            {
                string query = "SP_RetornarProductos";

                SqlCommand cmd = new SqlCommand(query, oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objLista.Add(new EN_ReporteProducto()
                        {
                            producto = dr["producto"].ToString(),
                            cantidad = int.Parse(dr["cantidad"].ToString()),
                        });
                    }
                }
            }

            return objLista;
        }
    }
}
