using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class FacturaF
    {
        [Display(Name = "ID de Factura")]
        public int id_factura { get; set; }
        [Display(Name = "ID de Cliente")]
        public String id_cli { get; set; }
        public virtual ClienteE Cliente { get; set; }
        [Display(Name = "Número de cotización")]
        public String num_cotizacion { get; set; }
        [Display(Name = "Fecha de venta")]
        public int fecha_venta { get; set; }
        [Display(Name = "Tipo")]
        public int tipo { get; set; }
        [Display(Name = "Credito")]
        public String credito { get; set; }
        [Display(Name = "ID del Proveedor")]
        public String id_proveedor { get; set; }
        public virtual ProveedorE Proveedor { get; set; }
    }
}
