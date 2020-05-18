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
    public class PagosController : Controller
    {
        // GET: Pagos
        public ActionResult Index()
        {
            var _pagos = new dom.PagosD().PagosList();
            return View(_pagos);
        }
        //Controlador para CREAR pagos
        [HttpGet]
        public ActionResult Crear()
        {
            var _pagos = new ent.PagosE();
            return PartialView("Crear", _pagos);
        }
        [HttpPost]
        public ActionResult Crear(ent.PagosE pagos)
        {
            new dom.PagosD().CrearPago(pagos);
            return RedirectToAction("Index");
        }
        //Controlador para EDITAR los pagos

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _pagos = new dom.PagosD().PagosPorID(id);
            return PartialView("Editar", _pagos);
        }
        [HttpPost]
        public ActionResult Editar(ent.PagosE pagoEditado)
        {
            new dom.PagosD().ModificarPago(pagoEditado);
            return RedirectToAction("Index");
        }
    }
}