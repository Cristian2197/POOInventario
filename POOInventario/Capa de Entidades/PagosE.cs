using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class PagosE
    {
        [Display(Name = "ID de Pago")]
        public int id_pago { get; set; }
        [Display(Name = "ID de Factura")]
        public String id_factura { get; set; }
        public virtual FacturaF Factura { get; set; }
        [Display(Name = "Monto")]
        public String monto { get; set; }
        [Display(Name = "Cuota")]
        public int couta { get; set; }
        [Display(Name = "Fecha de pago")]
        public int fecha_pago { get; set; }
        [Display(Name = "Activo")]
        public String activo { get; set; }
    }
}
