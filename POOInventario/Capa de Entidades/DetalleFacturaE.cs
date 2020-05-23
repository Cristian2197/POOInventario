using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class DetalleFacturaE
    {
        public int id_detalle_venta { get; set; }
        public int id_factura { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public double precio_uni { get; set; }
        public double total { get; set; }
        public int id_pago { get; set; }
        public virtual FacturaE Factura { get; set; }
        public virtual ProductoE Producto { get; set; }
    }
}
