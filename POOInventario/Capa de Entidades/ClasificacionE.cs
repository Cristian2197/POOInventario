using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class ClasificacionE
    {
        [Display(Name = "ID del Clasificacion")]
        public int id_clasi { get; set; }
        public String nombre { get; set; }
    }
}