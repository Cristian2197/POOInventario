using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class ProductoE
    {
        public int id_producto { get; set; }
        public int id_proveedor { get; set; }
        public string nombre { get; set; }
        public double precio_compra { get; set; }
        public double precio_venta { get; set; }
        public int can_existente { get; set; }
        public int num_lote { get; set; }
        public int id_categoria { get; set; }
    }
}
