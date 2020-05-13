using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ent = Capa_de_Entidades;
using dom = Dominio;

namespace POOInventario.Controllers
{
    public class ClasificacionController : Controller
    {
        // GET: Clasificacion
        public ActionResult Index()
        {
            var _clasificacion = new dom.ClasificacionD().ClasificacionList();
            return View(_clasificacion);
        }
        //Controlador para CREAR Clasificacion
        [HttpGet]
        public ActionResult Crear()
        {
            var _clasificacion = new ent.ClasificacionE();
            return PartialView("Crear", _clasificacion);
        }
        [HttpPost]
        public ActionResult Crear(ent.ClasificacionE clasificacion)
        {
            new dom.ClasificacionD().CrearClasificacion(clasificacion);
            return RedirectToAction("Index");
        }
        //Controlador para EDITAR las clasificacion

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _clasificacion = new dom.ClasificacionD().ClasificacionPorID(id);
            return PartialView("Editar", _clasificacion);
        }
        [HttpPost]
        public ActionResult Editar(ent.ClasificacionE clasificacionEditado)
        {
            new dom.ClasificacionD().ModificarClasificacion(clasificacionEditado);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Eliminar(int? id)
        {
            var clasificacion = new dom.ClasificacionD().ClasificacionPorID((int)id);
            return PartialView(clasificacion);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            var Clasificacion = new dom.ClasificacionD().ClasificacionPorID(id);
            new dom.ClasificacionD().EliminarClasificacion(Clasificacion);
            return RedirectToAction("Index");
        }
    }
}