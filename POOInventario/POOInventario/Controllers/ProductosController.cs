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
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            var _productos = new dom.ProductoD().ProductosList();
           
            return View(_productos);
            
        }
        [HttpGet]
        public ActionResult CompraProducto(ent.DetalleFacturaE detalle)
        {
            if (detalle.credito == true)
            {
                ViewBag.Credito = "Aplica";
            }
            else
            {
                ViewBag.Credito = "No Aplica";
            }
           
            return View(detalle);
        }
      
       [HttpPost]
       public ActionResult CompraProducto(ent.DetalleFacturaE detalle, string num_tarjeta)
        {
            int idProd = (int)TempData["IDProducto"];
            
            return null;
        }

        [HttpGet]
        public ActionResult ComprobarCredito(int idproducto)
        {
            TempData["Idprod"] = idproducto;
            var cliente = new ent.ClienteE();
            return PartialView(cliente);
        }
        [HttpPost]
        public ActionResult ComporbarCredito(string numTarjeta)
        {
            var cliente = new dom.ClienteD().BuscarUnCliente(x => x.numero_tarjeta == numTarjeta);
            var detalle = new ent.DetalleFacturaE();
            if (cliente.ID_clasi == 1)
            {
                detalle.credito = false;
            }
            else if (cliente.ID_clasi == 2)
            {
                detalle.credito = true;
            }
            else if (cliente.ID_clasi == 3)
            {
                detalle.credito = true;
            }
            detalle.id_producto = (int)TempData["Idprod"];
            return RedirectToAction("CompraProducto" , detalle);
        }
        //Controlador para CREAR cargos
        [HttpGet]
        public ActionResult Crear()
        {
            var _producto = new ent.ProductoE();
            return PartialView("Crear", _producto);
        }
        [HttpPost]
        public ActionResult Crear(ent.ProductoE _producto)
        {
            new dom.ProductoD().CrearProducto(_producto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _producto = new dom.ProductoD().ProductosPorID(id);
            return PartialView("Editar", _producto);
        }
        [HttpPost]
        public ActionResult Editar(ent.ProductoE ProductoEditado)
        {
            new dom.ProductoD().ModificarProducto(ProductoEditado);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Eliminar(int? id)
        {
            var Producto = new dom.ProductoD().ProductosPorID((int)id);
            return PartialView(Producto);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            var Producto = new dom.ProductoD().ProductosPorID(id);
            new dom.ProductoD().EliminarProducto(Producto);
            return RedirectToAction("Index");
        }
    }
}