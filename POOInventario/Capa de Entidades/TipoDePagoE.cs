using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class TipoDePagoE
    {
        [Display(Name = "ID de Tipo de Pago")]
        public int id_tipo_pago { get; set; }
        [Display(Name = "Nombre")]
        public String nombre { get; set; }
        [Display(Name = "Interes")]
        public String interes { get; set; }
    }
}
