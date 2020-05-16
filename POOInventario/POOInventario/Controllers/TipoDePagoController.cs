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
    public class TipoDePagoController : Controller
    {
        // GET: TipoDePago
        public ActionResult Index()
        {
            var _tdp = new dom.TipoDePagoD().TDPList();
            return View(_tdp);
        }
        //Controlador para CREAR tipo de pagos
        [HttpGet]
        public ActionResult Crear()
        {
            var _tdp = new ent.TipoDePagoE();
            return PartialView("Crear", _tdp);
        }
        [HttpPost]
        public ActionResult Crear(ent.TipoDePagoE tdp)
        {
            new dom.TipoDePagoD().CrearTDP(tdp);
            return RedirectToAction("Index");
        }
        //Controlador para EDITAR los tipos de pago

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _tdp = new dom.TipoDePagoD().TDPPorID(id);
            return PartialView("Editar", _tdp);
        }
        [HttpPost]
        public ActionResult Editar(ent.TipoDePagoE tdpEditado)
        {
            new dom.TipoDePagoD().ModificarTDP(tdpEditado);
            return RedirectToAction("Index");
        }
    }
}