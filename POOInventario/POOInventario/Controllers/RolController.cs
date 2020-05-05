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
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            var _roles = new dom.RolD().RolesList();
            return View(_roles);
        }
        //Controlador para CREAR clientes
        [HttpGet]
        public ActionResult Crear()
        {
            var _rol = new ent.RolE();
            return PartialView("Crear", _rol);
        }
        [HttpPost]
        public ActionResult Crear(ent.RolE rol)
        {
            new dom.RolD().CrearRol(rol);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _rol = new dom.RolD().RolesPorID(id);
            return PartialView("Editar", _rol);
        }
        [HttpPost]
        public ActionResult Editar(ent.RolE RolEditado)
        {
            new dom.RolD().ModificarRol(RolEditado);
            return RedirectToAction("Index");
        }
    }
}