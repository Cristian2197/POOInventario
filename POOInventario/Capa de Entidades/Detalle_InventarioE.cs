using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class Detalle_InventarioE
    {
        public int id_detalle_inventario { get; set; }
        public int id_invetario { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }
        public int saldo_unidades { get; set; }
        public float saldo_dinero { get; set; }
    }
}
