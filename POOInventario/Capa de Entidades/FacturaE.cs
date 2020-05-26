using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class FacturaE
    {
        [Display(Name = "ID de Factura")]
        public int id_factura { get; set; }
        [Display(Name = "ID de Cliente")]
        public string id_cli { get; set; }
        public virtual ClienteE Cliente { get; set; }
        [Display(Name = "Número de cotización")]
        public string num_cotizacion { get; set; }
        [Display(Name = "Fecha de venta")]
        public int fecha_venta { get; set; }
        [Display(Name = "Tipo")]
        public string tipo { get; set; }
        [Display(Name = "Credito")]
        public string credito { get; set; }
        [Display(Name = "ID del Proveedor")]
        public string id_proveedor { get; set; }
        public virtual ProveedorE Proveedor { get; set; }
    }
}
