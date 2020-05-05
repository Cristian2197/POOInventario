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
        }
    }
}
