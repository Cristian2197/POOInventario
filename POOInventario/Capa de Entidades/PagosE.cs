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
        public int id_factura { get; set; }
        public virtual FacturaE Factura { get; set; }
        [Display(Name = "Monto")]
        public double monto { get; set; }
        [Display(Name = "Cuota")]
        public int couta { get; set; }
        [Display(Name = "Fecha de pago")]
        public DateTime fecha_pago { get; set; }
        [Display(Name = "Activo")]
        public bool activo { get; set; }
    }
}
