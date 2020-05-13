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
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            var _categoria = new dom.CategoriasD().CategoriaList();
            return View(_categoria);
        }
        //Controlador para CREAR Categorias
        [HttpGet]
        public ActionResult Crear()
        {
            var _categorias = new ent.CategoriasE();
            return PartialView("Crear", _categorias);
        }
        [HttpPost]
        public ActionResult Crear(ent.CategoriasE categorias)
        {
            new dom.CategoriasD().CrearCategoria(categorias);
            return RedirectToAction("Index");
        }
        //Controlador para EDITAR las categorias

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _categorias = new dom.CategoriasD().CategoriaPorID(id);
            return PartialView("Editar", _categorias);
        }
        [HttpPost]
        public ActionResult Editar(ent.CategoriasE categoriaEditado)
        {
            new dom.CategoriasD().ModificarCategoria(categoriaEditado);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Eliminar(int? id)
        {
            var categorias = new dom.CategoriasD().CategoriaPorID((int)id);
            return PartialView(categorias);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            var Categoria = new dom.CategoriasD().CategoriaPorID(id);
            new dom.CategoriasD().EliminarCategoria(Categoria);
            return RedirectToAction("Index");
        }
    }
}