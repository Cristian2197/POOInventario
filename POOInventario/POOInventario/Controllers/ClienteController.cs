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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var _cliente = new dom.ClienteD().ClienteList();
            return View(_cliente);
        }

        //Controlador para CREAR Cliente
        [HttpGet]
        public ActionResult Crear()
        {
            var _cliente = new ent.ClienteE();
            return PartialView("Crear", _cliente);
        }
        [HttpPost]
        public ActionResult Crear(ent.ClienteE cliente)
        {
            new dom.ClienteD().CrearCliente(cliente);
            return RedirectToAction("Index");
        }
        //Controlador para EDITAR las cliente

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _cliente = new dom.ClienteD().ClientesPorID(id);
            return PartialView("Editar", _cliente);
        }
        [HttpPost]
        public ActionResult Editar(ent.ClienteE clienteEditado)
        {
            new dom.ClienteD().ModificarCliente(clienteEditado);
            return RedirectToAction("Index");
        }
    }
}