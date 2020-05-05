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
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            var _empleados = new dom.EmpleadosD().EmpleadosList();
            return View(_empleados);
        }
        //Controlador para CREAR clientes
        [HttpGet]
        public ActionResult Crear()
        {
            var _empleado = new ent.EmpleadosE();
            return PartialView("Crear", _empleado);
        }
        [HttpPost]
        public ActionResult Crear(ent.EmpleadosE empleado)
        {
            new dom.EmpleadosD().CrearEmpleado(empleado);
            return RedirectToAction("Index");
        }
        //Controlador para EDITAR las clientes

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _empleado = new dom.EmpleadosD().EmpleadosPorID(id);
            return PartialView("Editar", _empleado);
        }
        [HttpPost]
        public ActionResult Editar(ent.EmpleadosE empleadoEditado)
        {
            new dom.EmpleadosD().ModificarEmpleado(empleadoEditado);
            return RedirectToAction("Index");
        }
    }
}