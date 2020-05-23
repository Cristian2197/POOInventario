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
        public List<ent.ProductoE> productosDisponibles()
        {
            List<ent.ProductoE> productoss = new List<ent.ProductoE>();
            var productos = new dom.ProductoD().ProductosList();
            foreach (var item in productos)
            {
                if (item.can_existente > 0)
                {
                   
                    productoss.Add(item);
                }

            }
            return productoss;
        }
        // GET: Productos
        public ActionResult Index()
        {
            var _productos = new dom.ProductoD().ProductosList();
            return View(_productos);
        }
        [HttpGet]
        public ActionResult CompraProducto()
        {
            ViewBag.Productos = productosDisponibles();
            return View(productosDisponibles());
        }

        [HttpGet]
        public ActionResult Comprar()
        {
            var _clientes = new ent.ClienteE();
            return PartialView(_clientes);
        }
        [HttpGet]
        public ActionResult Cotizaciones()
        {
            string tarjeta = Session["sesionCli"].ToString();
            var _cliente = new dom.ClienteD().BuscarUnCliente(x => x.numero_tarjeta == tarjeta);
            var _coti = new dom.CotizacionD().CotizacionList();
            ViewBag.Cliente = _cliente;
            return View(_coti);
        }
        [HttpGet]
        public ActionResult CompraCliente()
        {
            string tarjeta = Session["sesionCli"].ToString();
            var _cliente = new dom.ClienteD().BuscarUnCliente(x=> x.numero_tarjeta== tarjeta);
            ent.FacturaE _facturas = new ent.FacturaE();
            if (_cliente.ID_clasi== 1)
            {
                _facturas.credito = false;

            }
            else
            {
                _facturas.credito = true;
            }
            return null;
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

        public List<ent.Detalle_cotizacion> DetallexCot(ent.CotizacionE cotizacion) 
        {
            List<ent.Detalle_cotizacion> detalleN = new List<ent.Detalle_cotizacion>();
            var detalle = new dom.Detalle_cotizacionD().DetalleList();
            foreach (var item in detalle)
            {
                if (cotizacion.num_cotizacion == item.num_cotizacion)
                {
                    detalleN.Add(item);
                }
            }
            return detalleN;
        }
        public ActionResult IndexCliente()
        {
            
            string tarjeta = Session["numero_tarjeta"].ToString();
            var cliente = new dom.ClienteD().BuscarUnCliente(x => x.numero_tarjeta == tarjeta);
            var cotizacion = new ent.CotizacionE();
            if (new dom.CotizacionD().BuscarCotizacion(x => x.id_cli == cliente.id_cli).ToList().Count() != 0)
            {
                cotizacion = new dom.CotizacionD().BuscarCotizacion(x => x.id_cli == cliente.id_cli).ToList().Last();
            }
            var producto = new dom.ProductoD().BuscarProducto(x => x.can_existente > 0);
            ViewBag.Carrito = DetallexCot(cotizacion);
            ViewBag.Productos = producto;
            ViewBag.cotizacion = cotizacion.num_cotizacion;
            return View(producto);
        }
        public ActionResult Detalle(int id)
        {
            var _cliente = new dom.ProductoD().ProductosPorID(id);
            return PartialView("Detalle", _cliente);
        }

        public bool ValidarCotiFactu(int ideCli)
        {
            var factura = new dom.FacturasD().BuscarFactura(x => x.id_cli == ideCli);
            bool esta = false;
            if (new dom.CotizacionD().BuscarCotizacion(x => x.id_cli == ideCli).Count() == 0)
            {
                esta = false;
            }
            else
            {
                var cotizacion = new dom.CotizacionD().BuscarCotizacion(x => x.id_cli == ideCli).Last();
                foreach (var item in factura)
                {
                    if (item.num_cotizacion == cotizacion.num_cotizacion)
                    {
                        esta = true;
                        break;
                    }
                    else
                    {
                        esta = false;
                        break;
                    }
                }
            }
            return esta;

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

        [HttpPost]
        public ActionResult Comprar(int id, int cantidad)
        {
            string tarjeta = Session["numero_tarjeta"].ToString();
            var cliente = new dom.ClienteD().BuscarUnCliente(x => x.numero_tarjeta == tarjeta);
            var producto = new dom.ProductoD().ProductosPorID(id);
            bool vali = ValidarCotiFactu(cliente.id_cli);
            if (vali == false)
            {
                var cotizacion = new ent.CotizacionE()
                {
                    id_cli = cliente.id_cli,
                    fecha_cotizacion = DateTime.Now
                };
                new dom.CotizacionD().CrearCotizacion(cotizacion);
                int idCot = new dom.CotizacionD().BuscarCotizacion(x => x.id_cli == cliente.id_cli).Last().num_cotizacion;
                var detalleCo = new ent.Detalle_cotizacion()
                {
                    id_cli = cliente.id_cli,
                    id_producto = producto.id_producto,
                    cantidad = cantidad,
                    precio_uni = producto.precio_venta,
                    total = producto.precio_venta * cantidad,
                    num_cotizacion = idCot
                };
                BajarStock(cantidad, producto.id_producto);
                new dom.Detalle_cotizacionD().CrearDetalle(detalleCo);
                return RedirectToAction("IndexCliente");
            }
            else
            {
                int idCot = new dom.CotizacionD().BuscarCotizacion(x => x.id_cli == cliente.id_cli).Last().num_cotizacion;
                var detalleCo = new ent.Detalle_cotizacion()
                {
                    id_cli = cliente.id_cli,
                    id_producto = producto.id_producto,
                    cantidad = cantidad,
                    precio_uni = producto.precio_venta,
                    total = producto.precio_venta * cantidad,
                    num_cotizacion = idCot
                };
                BajarStock(cantidad, producto.id_producto);
                new dom.Detalle_cotizacionD().CrearDetalle(detalleCo);
                return RedirectToAction("IndexCliente");
            }
            
        }
    }
}