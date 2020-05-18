using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class ProveedorE
    {
        [Display(Name = "ID del Proveedor")]
        public int id_proveedor { get; set; }
        [Display(Name = "Nombre")]
        public String nombre_proveedor { get; set; }
        [Display(Name = "Telefono")]
        public String telefono { get; set; }
        [Display(Name = "Dirección")]
        public int direccion { get; set; }
    }
}
