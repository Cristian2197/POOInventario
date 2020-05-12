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
    public class CargosController : Controller
    {
        // GET: Cargos
        public ActionResult Index()
        {
            var _cargos = new dom.CargosD().CargosList();
            return View(_cargos);
        }
        //Controlador para CREAR clientes
        [HttpGet]
        public ActionResult Crear()
        {
            var _cargo = new ent.CargosE();
            return PartialView("Crear", _cargo);
        }
        [HttpPost]
        public ActionResult Crear(ent.CargosE _cargo)
        {
            new dom.CargosD().CrearCargo(_cargo);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _cargo = new dom.CargosD().CargosPorID(id);
            return PartialView("Editar", _cargo);
        }
        [HttpPost]
        public ActionResult Editar(ent.CargosE CargoEditado)
        {
            new dom.CargosD().ModificarCargo(CargoEditado);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Eliminar(int? id)
        {
            var roles = new dom.CargosD().CargosPorID((int)id);
            return PartialView(roles);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            var Cargo = new dom.CargosD().CargosPorID(id);
            new dom.CargosD().EliminarCargo(Cargo);
            return RedirectToAction("Index");
        }
    }
}