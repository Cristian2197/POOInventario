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


        }
    }
}
