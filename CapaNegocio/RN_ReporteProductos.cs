using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class RN_ReporteProductos
    {
        BD_ReporteProducto bd_reporteProducto = new BD_ReporteProducto();
        public List<EN_ReporteProducto> ListarReporteProductos()
        {
            return bd_reporteProducto.RetornarProductos();
        }
    }
}
