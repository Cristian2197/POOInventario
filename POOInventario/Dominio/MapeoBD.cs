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

        }
    }
}
