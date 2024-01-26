using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
namespace GraficosChartJs_Practica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpGet]
        //public JsonResult ReporteVentas()
        //{
        //    DT_Reporte objDT_Reporte = new DT_Reporte();

        //    List<EN_ReporteVenta> objLista = objDT_Reporte.RetornarVentas();

        //    return Json(objLista, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public JsonResult ReporteVentas()
        {
            List<EN_ReporteVenta> oLista = new List<EN_ReporteVenta>();
            oLista = new RN_ReporteVenta().ListarReporteVentas();
            return Json(oLista, JsonRequestBehavior.AllowGet);
            //return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ReporteProductos()
        {
            List<EN_ReporteProducto> oLista = new List<EN_ReporteProducto>();
            oLista = new RN_ReporteProductos().ListarReporteProductos();
            //return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            return Json(oLista, JsonRequestBehavior.AllowGet);
        }

      
    }
}