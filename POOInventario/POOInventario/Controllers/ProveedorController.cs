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
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            var _proveedor = new dom.ProveedorD().ProveedorList();
            return View(_proveedor);
        }
        //Controlador para CREAR proveedores
        [HttpGet]
        public ActionResult Crear()
        {
            var _proveedor = new ent.ProveedorE();
            return PartialView("Crear", _proveedor);
        }
        [HttpPost]
        public ActionResult Crear(ent.ProveedorE proveedor)
        {
            new dom.ProveedorD().CrearProveedor(proveedor);
            return RedirectToAction("Index");
        }
        //Controlador para EDITAR los proveedores

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _proveedor = new dom.ProveedorD().ProveedorPorID(id);
            return PartialView("Editar", _proveedor);
        }
        [HttpPost]
        public ActionResult Editar(ent.ProveedorE proveedorEditado)
        {
            new dom.ProveedorD().ModificarProveedor(proveedorEditado);
            return RedirectToAction("Index");
        }
    }
}