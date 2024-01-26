using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
namespace CapaNegocio
{
    public class RN_ReporteVenta
    {
        BD_ReporteVenta bd_reporteVenta = new BD_ReporteVenta();
        public List<EN_ReporteVenta> ListarReporteVentas()
        {
            return bd_reporteVenta.RetornarVentas();
        }

    }
}
