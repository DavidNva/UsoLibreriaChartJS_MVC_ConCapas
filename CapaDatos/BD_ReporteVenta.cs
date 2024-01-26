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
    public class BD_ReporteVenta
    {
        //public List<EN_ReporteVenta> RetornarVentas()
        //{
        //    List<EN_ReporteVenta> objLista = new List<EN_ReporteVenta>();

        //        using (SqlConnection oConexion = new SqlConnection(BD_Conexion.cn))
        //        {
        //            SqlCommand cmd = new SqlCommand("SP_RetornarVentas", oConexion);

        //            cmd.CommandType = CommandType.StoredProcedure;

        //            oConexion.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    objLista.Add(new EN_ReporteVenta()
        //                    {
        //                        mes = dr["mes"].ToString(),
        //                        cantidad = int.Parse(dr["cantidad"].ToString()),
        //                    });
        //                }
        //            }
        //        cmd.ExecuteNonQuery();
        //    }

        //    return objLista;

        //}
        public List<EN_ReporteVenta> RetornarVentas()
        {
            List<EN_ReporteVenta> objLista = new List<EN_ReporteVenta>();

            //Data Source=;Initial Catalog= ; User ID= ; Password=
            //using (SqlConnection oconexion = new SqlConnection("Data Source=(local); Initial Catalog=AdventureWorks2014; Integrated Security=True"))
            using (SqlConnection oconexion = new SqlConnection(BD_Conexion.cn))
            {
                string query = "SP_RetornarVentas";

                SqlCommand cmd = new SqlCommand(query, oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objLista.Add(new EN_ReporteVenta()
                        {
                            mes = dr["mes"].ToString(),
                            cantidad = int.Parse(dr["cantidad"].ToString()),
                        });
                    }
                }
            }

            return objLista;
        }

        //public List<EN_ReporteVenta> RetornarVentas()
        //{
        //    List<EN_ReporteVenta> objLista = new List<EN_ReporteVenta>();

        //    //Data Source=;Initial Catalog= ; User ID= ; Password=
        //    using (SqlConnection oConexion = new SqlConnection(BD_Conexion.cn))
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_RetornarVentas", oConexion);

        //        cmd.CommandType = CommandType.StoredProcedure;

        //        oconexion.Open();

        //        using (SqlDataReader dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                objLista.Add(new EN_ReporteVenta()
        //                {
        //                    mes = dr["mes"].ToString(),
        //                    cantidad = int.Parse(dr["cantidad"].ToString()),
        //                });
        //            }
        //        }
        //    }

        //    return objLista;
        //}




    }
}
