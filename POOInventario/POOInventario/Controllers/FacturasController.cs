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
    public class FacturasController : Controller
    {
        public List<SelectListItem> ProductosAll(List<ent.ProductoE> Lista)
        {
            List<SelectListItem> Productos = new List<SelectListItem>();
            foreach (var item in Lista)
            {
                Productos.Add(new SelectListItem { Text = item.nombre + " " + item.precio_venta.ToString(), Value = item.id_producto.ToString() });
            }
            return Productos;
        }
        public List<SelectListItem> TipoPagoAll(List<ent.TipoDePagoE> Lista)
        {
            List<SelectListItem> Productos = new List<SelectListItem>();
            foreach (var item in Lista)
            {
                Productos.Add(new SelectListItem { Text = item.nombre, Value = item.id_tipo_pago.ToString() });
            }
            return Productos;
        }
        // GET: Facturas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FinCompra(ent.FacturaE factura)
        {
            var productos = new dom.ProductoD().ProductosList().ToList();
            var tipoPago = new dom.TipoDePagoD().TDPList().ToList();
            new dom.FacturasD().FacturaCrear(factura);
            var facturaNue = new dom.FacturasD().BuscarFactura(x => x.id_cli == factura.id_cli).ToList().Last();
            facturaNue.Detalle = new dom.DetalleFacturaD().BuscarFactura(x => x.id_factura == facturaNue.id_factura).ToList();
            TempData["CLIENTE"] = factura.id_cli;
            var detalle = new ent.DetalleFacturaE();
            ViewBag.ProductosDrop = ProductosAll(productos);
            ViewBag.TipoPago = TipoPagoAll(tipoPago);
            return View(detalle);
        }
        [HttpPost]
        public ActionResult FinCompra(ent.DetalleFacturaE detalle)
        {
            int idCLiente = (int)TempData["CLIENTE"];
            var facturaNue = new dom.FacturasD().BuscarFactura(x => x.id_cli == idCLiente).ToList().Last();
            detalle.total = detalle.total * detalle.cantidad;
            detalle.id_factura = facturaNue.id_factura;
            new dom.DetalleFacturaD().CrearDetalleFactura(detalle);
            return RedirectToAction("FinCompra", facturaNue);
        }
    }
}