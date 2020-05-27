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
    public class CotizacionController : Controller
    {
        public List<SelectListItem> tipos()
        {
            var tipos = new dom.TipoDePagoD().TDPList();
            List<SelectListItem> tiposD = new List<SelectListItem>();
            tiposD.Add(new SelectListItem { Value = "0", Text = "--Seleccione tipo de pago--" });
            foreach (var item in tipos)
            {
                tiposD.Add(new SelectListItem { Value = item.id_tipo_pago.ToString(), Text = item.nombre });
            }
            return tiposD;
        }

        public void BajarStock(int cantidad, int idProd)
        {
            var producto = new dom.ProductoD().ProductosPorID(idProd);
            var detalleI = new dom.Detalle_InventaroD().BuscarUnDetalleInventario(x => x.id_producto == producto.id_producto);
            if (detalleI.cantidad != 0)
            {
                detalleI.cantidad = detalleI.cantidad - cantidad;
                detalleI.saldo_dinero = detalleI.saldo_dinero - (float)producto.precio_venta * cantidad;
                new dom.Detalle_InventaroD().ModificarDetalleInventario(detalleI);
            }
            else
            {
                producto.can_existente = producto.can_existente - cantidad;
                new dom.ProductoD().ModificarProducto(producto);
            }

        }

        public void BajarStockDetalle(int idCotizacion) 
        {
            var detalle = new dom.Detalle_cotizacionD().BuscarDetalle(x => x.num_cotizacion == idCotizacion);
            foreach (var item in detalle)
            {
                BajarStock(item.cantidad, item.id_producto);
            }
        }
        // GET: Cotizacion
        public ActionResult Index(int? id)
        {
            int idCli = 3;
            var _cotizaciones = new dom.CotizacionD().CotizacionList();
            ViewBag.cliente = idCli;
            return View(_cotizaciones);
        }
        [HttpGet]
        public ActionResult Eliminar(int? id)
        {
            var roles = new dom.CotizacionD().CotizacionPorID((int)id);
            return PartialView(roles);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            var Cargo = new dom.CotizacionD().CotizacionPorID(id);
            new dom.CotizacionD().EliminarCotizacion(Cargo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ComprarProducto(int id)
        {
            var cotizacion = new dom.CotizacionD().CotizacionPorID(id);
            var clientes = new dom.ClienteD().ClientesPorID(cotizacion.id_cli);
            var facturas = new ent.FacturaE();
            var detalle = new dom.Detalle_cotizacionD().BuscarDetalle(x => x.num_cotizacion == cotizacion.num_cotizacion);
            facturas.id_cli = (int)Session["id_cli"];
            facturas.num_cotizacion = id;
            facturas.fecha_venta = DateTime.Now;
            List<SelectListItem> meses = new List<SelectListItem>();
            meses.Add(new SelectListItem { Value = "0", Text = "Comprar al contado" });
            meses.Add(new SelectListItem { Value = "6", Text = "6 meses" });
            meses.Add(new SelectListItem { Value = "12", Text = "12 meses" });
            ViewBag.Cliente = clientes; 
            ViewBag.MEses = meses;
            ViewBag.Tipos = tipos();
            ViewBag.cotizacion = cotizacion;
            ViewBag.detale = detalle;
            ViewBag.Productos = new dom.ProductoD().ProductosList();
            return PartialView(facturas);
        }


        public ActionResult ComprarProducto(ent.FacturaE factura, int cliente, int meses)
        {
            var clienteE = new dom.ClienteD().ClientesPorID(cliente);
            var cotizacion = new dom.CotizacionD().CotizacionPorID(factura.num_cotizacion);
           
            if (clienteE.ID_clasi == 1)
            {
                factura.total = cotizacion.total;
                factura.fecha_venta = DateTime.Now;
                factura.id_cli = cliente;
                new dom.FacturasD().FacturaCrear(factura);
                BajarStockDetalle(cotizacion.num_cotizacion);
                return RedirectToAction("IndexCliente", "Productos");

            }
            else if (clienteE.ID_clasi == 2)
            {
                if (meses == 0)
                {
                    factura.total = cotizacion.total;
                    factura.fecha_venta = DateTime.Now;
                    factura.id_cli = cliente;
                    new dom.FacturasD().FacturaCrear(factura);
                    BajarStockDetalle(cotizacion.num_cotizacion);
                    return RedirectToAction("IndexCliente", "Productos");
                }
                else if (meses == 6)
                {
                    double intereses = cotizacion.total * 0.1;
                    double TotalInteresesProducto = intereses + cotizacion.total;
                    double totalTOTAL = TotalInteresesProducto / 6;
                    factura.total = cotizacion.total;
                    factura.fecha_venta = DateTime.Now;
                    factura.id_cli = cliente;
                    new dom.FacturasD().FacturaCrear(factura);
                    BajarStockDetalle(cotizacion.num_cotizacion);
                    var uFactura = new dom.FacturasD().FacturasList().Last();
                    var pago = new ent.PagosE()
                    {
                        id_factura = uFactura.id_factura,
                        couta = 6,
                        monto = totalTOTAL,
                        fecha_pago = DateTime.Now,
                        activo = false

                    };
                    new dom.PagosD().CrearPago(pago);
                    var pago2 = new ent.PagosE()
                    {
                        id_factura = uFactura.id_factura,
                        couta = 6 - 1,
                        monto = totalTOTAL,
                        fecha_pago = DateTime.Now.AddMonths(1),
                        activo = true

                    };
                    new dom.PagosD().CrearPago(pago2);
                    return RedirectToAction("Index", "Pagos");
                }
                else if (meses == 12)
                {
                    double intereses = cotizacion.total * 0.1;
                    double TotalInteresesProducto = intereses + cotizacion.total;
                    double totalTOTAL = TotalInteresesProducto / 12;
                    factura.total = cotizacion.total;
                    factura.fecha_venta = DateTime.Now;
                    factura.id_cli = cliente;
                    new dom.FacturasD().FacturaCrear(factura);
                    BajarStockDetalle(cotizacion.num_cotizacion);
                    var uFactura = new dom.FacturasD().FacturasList();
                    var pago = new ent.PagosE()
                    {
                        id_factura = uFactura.Last().id_factura,
                        couta = 6,
                        monto = totalTOTAL,
                        fecha_pago = DateTime.Now,
                        activo = false

                    };
                    new dom.PagosD().CrearPago(pago);
                    var pago2 = new ent.PagosE()
                    {
                        id_factura = uFactura.Last().id_factura,
                        couta = 6 - 1,
                        monto = totalTOTAL,
                        fecha_pago = DateTime.Now.AddMonths(1),
                        activo = true

                    };
                    new dom.PagosD().CrearPago(pago2);
                    return RedirectToAction("IndexCliente", "Pagos");
                }

            }
            else if (clienteE.ID_clasi == 3)
            {
                if (meses == 0)
                {
                    factura.total = cotizacion.total;
                    factura.fecha_venta = DateTime.Now;
                    factura.id_cli = cliente;
                    new dom.FacturasD().FacturaCrear(factura);
                    BajarStockDetalle(cotizacion.num_cotizacion);
                    return RedirectToAction("IndexCliente", "Productos");
                }
                else if (meses == 6)
                {
                    double intereses = cotizacion.total * 0.05;
                    double TotalInteresesProducto = intereses + cotizacion.total;
                    double totalTOTAL = TotalInteresesProducto / 6;
                    factura.total = cotizacion.total;
                    factura.fecha_venta = DateTime.Now;
                    factura.id_cli = cliente;
                    new dom.FacturasD().FacturaCrear(factura);
                    BajarStockDetalle(cotizacion.num_cotizacion);
                    var uFactura = new dom.FacturasD().FacturasList();
                    var pago = new ent.PagosE()
                    {
                        id_factura = uFactura.Last().id_factura,
                        couta = 6,
                        monto = totalTOTAL,
                        fecha_pago = DateTime.Now,
                        activo = false

                    };
                    new dom.PagosD().CrearPago(pago);
                    var pago2 = new ent.PagosE()
                    {
                        id_factura = uFactura.Last().id_factura,
                        couta = 6 - 1,
                        monto = totalTOTAL,
                        fecha_pago = DateTime.Now.AddMonths(1),
                        activo = true

                    };
                    new dom.PagosD().CrearPago(pago2);
                    return RedirectToAction("Index", "Pagos");
                }
                else if (meses == 12)
                {
                    double intereses = cotizacion.total * 0.05;
                    double TotalInteresesProducto = intereses + cotizacion.total;
                    double totalTOTAL = TotalInteresesProducto / 12;
                    factura.total = cotizacion.total;
                    factura.fecha_venta = DateTime.Now;
                    factura.id_cli = cliente;
                    new dom.FacturasD().FacturaCrear(factura);
                    BajarStockDetalle(cotizacion.num_cotizacion);
                    var uFactura = new dom.FacturasD().FacturasList();
                    var pago = new ent.PagosE()
                    {
                        id_factura = uFactura.Last().id_factura,
                        couta = 6,
                        monto = totalTOTAL,
                        fecha_pago = DateTime.Now,
                        activo = false

                    };
                    new dom.PagosD().CrearPago(pago);
                    var pago2 = new ent.PagosE()
                    {
                        id_factura = uFactura.Last().id_factura,
                        couta = 6 -1 ,
                        monto = totalTOTAL,
                        fecha_pago = DateTime.Now.AddMonths(1),
                        activo = true

                    };
                    new dom.PagosD().CrearPago(pago2);
                    return RedirectToAction("Index", "Pagos");
                }
                

            }
            return RedirectToAction("IndexCliente", "Productos");
        }

    }
}