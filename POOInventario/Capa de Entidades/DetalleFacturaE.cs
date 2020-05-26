using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class DetalleFacturaE
    {
        public int id_factura { get; set; }
        public int id_cli { get; set; }
        public int id_producto { get; set; }
        public int num_cotizacion { get; set; }
        public DateTime fecha_venta { get; set; }
        public string tipo { get; set; }
        public bool credito { get; set; }
        public int id_proveedor { get; set; }
    }
}
