using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Capa_de_Entidades
{
   public  class EmpleadosE
    {
        [Display(Name ="ID del Empleado")]
        public int ID_emp { get; set; }
        [Display(Name = "Nombre")]
        public string nombre_emp { get; set; }
        [Display(Name = "Apellido")]
        public string apellido_emp { get; set; }
        [Display(Name = "Dirección")]
        public string direccion_emp { get; set; }
        [Display(Name = "Telefono")]
        public string telefono_emp { get; set; }
        [Display(Name = "Correo")]
        public string correo_emp { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public string nacimiento_emp { get; set; }
        public int id_cargo { get; set; }
        public int id_rol { get; set; }
        public virtual RolE ROLES { get; set; }
        public virtual CargosE CARGO { get; set; }

    }



}
