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
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult Index()
        {
            var _inventario = new dom.InventarioD().InventarioList();
            return View(_inventario);
        }
        //Controlador para CREAR Inventarop
        [HttpGet]
        public ActionResult Crear()
        {
            var _inventario = new ent.InventarioE();
            return PartialView("Crear", _inventario);
        }
        [HttpPost]
        public ActionResult Crear(ent.InventarioE inventario)
        {
            new dom.InventarioD().CrearInventario(inventario);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _inverario = new dom.InventarioD().InventarioPorID(id);
            return PartialView("Editar", _inverario);
        }
        [HttpPost]
        public ActionResult Editar(ent.InventarioE invetarioEditado)
        {
            new dom.InventarioD().ModificarInventario(invetarioEditado);
            return RedirectToAction("Index");
        }
    }
}