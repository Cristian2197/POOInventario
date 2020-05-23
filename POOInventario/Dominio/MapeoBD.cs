using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using bd = Capa_Datos;
using ent = Capa_de_Entidades;
namespace Dominio
{
   public class MapeoBD : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "MapeoBD";
            }
        }
        public MapeoBD()
        {
            //Entidades de la base de datos hasta entidades xd
            CreateMap<bd.Empleados, ent.EmpleadosE>();
            //Entidades BD
            CreateMap<ent.EmpleadosE, bd.Empleados>();
            //Entidades Rol BD
            CreateMap<bd.Rol,ent.RolE >();
            //BD to ent
            CreateMap<ent.RolE, bd.Rol>();
            //Entidades de inventario
            CreateMap<bd.Inventario, ent.InventarioE>();
            //Bd to ent
            CreateMap<ent.InventarioE, bd.Inventario>();
            //Entidades de detalle inventario
            CreateMap<bd.Detalle_inventario, ent.Detalle_InventarioE>();
            //Bd to ent
            CreateMap<ent.Detalle_InventarioE, bd.Detalle_inventario>();


            //Entidades de la base de datos hasta entidades para clasificación
            CreateMap<bd.Clasificacion, ent.ClasificacionE>();
            //Entidades BD clasificación
            CreateMap<ent.ClasificacionE, bd.Clasificacion>();

            //Entidades de la base de datos hasta entidades para cliente
            CreateMap<bd.Cliente, ent.ClienteE>();
            //Entidades BD cliente
            CreateMap<ent.ClienteE, bd.Cliente>();

            //Entidades de la base de datos hasta entidades para categorias
            CreateMap<bd.categorias, ent.CategoriasE>();
            //Entidades BD categorias
            CreateMap<ent.CategoriasE, bd.categorias>();

            //Entidades de la base de datos hasta entidades para Cargos
            CreateMap<bd.Cargos, ent.CargosE>();
            //Entidades BD cargos
            CreateMap<ent.CargosE, bd.Cargos>();

            //Entidades de la base de datos hasta entidades para Productos
            CreateMap<bd.Producto, ent.ProductoE>();
            //Entidades BD Productos
            CreateMap<ent.ProductoE, bd.Producto>();

            //Entidades de la base de datos hasta entidades para Pagos
            CreateMap<bd.Pagos, ent.PagosE>();
            //Entidades BD Productos
            CreateMap<ent.PagosE, bd.Pagos>();

            //Entidades de la base de datos hasta entidades para Tipo de pagos
            CreateMap<bd.Tipo_pago, ent.TipoDePagoE>();
            //Entidades BD Productos
            CreateMap<ent.TipoDePagoE, bd.Tipo_pago>();

            //Entidades de la base de datos hasta entidades para Proveedores
            CreateMap<bd.proveedor, ent.ProveedorE>();
            //Entidades BD Productos
            CreateMap<ent.ProveedorE, bd.proveedor>();
            CreateMap<bd.Detalle_cotizacion, ent.Detalle_cotizacion>();
            
            CreateMap<ent.Detalle_cotizacion, bd.Detalle_cotizacion>();
            CreateMap<bd.Cotizacion, ent.CotizacionE>();

            CreateMap<ent.CotizacionE, bd.Cotizacion>();
        }
    }
}
