using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class ClienteE
    {
        [Display(Name = "ID del Cliente")]
        public int id_cli { get; set; }
        [Display(Name = "Nombre")]
        public String nombre { get; set; }
        [Display(Name = "Apellido")]
        public String apellido { get; set; }
        [Display(Name = "Clasificacion")]
        public int ID_clasi { get; set; }
        public string numero_tarjeta { get; set; }
        public string MensajeError { get; set; }
        public virtual ClasificacionE Clasificacion { get; set; }
    }
}
