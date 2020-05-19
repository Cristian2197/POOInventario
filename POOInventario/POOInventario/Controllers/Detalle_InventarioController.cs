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
    public class Detalle_InventarioController : Controller
    {
        // GET: Detalle_Inventario
        public ActionResult Index()
        {
            var _detale_inventario = new dom.Detalle_InventaroD().Detalle_InventarioList();
            return View(_detale_inventario);
        }
        [HttpGet]
        public ActionResult Crear()
        {
            var _inventario = new ent.Detalle_InventarioE();
            return PartialView("Crear", _inventario);
        }
        [HttpPost]
        public ActionResult Crear(ent.Detalle_InventarioE detalle_inventario)
        {
            new dom.Detalle_InventaroD().CrearDetalleInventario(detalle_inventario);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _inverario = new dom.Detalle_InventaroD().Detalle_InventarioPorID(id);
            return PartialView("Editar", _inverario);
        }
        [HttpPost]
        public ActionResult Editar(ent.Detalle_InventarioE detalle_invetarioEditado)
        {
            new dom.Detalle_InventaroD().ModificarDetalleInventario(detalle_invetarioEditado);
            return RedirectToAction("Index");
        }
    }
}