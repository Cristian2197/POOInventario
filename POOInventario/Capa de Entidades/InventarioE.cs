using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class InventarioE
    {
        public int id_inventario { get; set; }
        public int id_producto { get; set; }
        public string fecha_inventario { get; set; }
        public string tipo_movimiento { get; set; }
        
    }
}
