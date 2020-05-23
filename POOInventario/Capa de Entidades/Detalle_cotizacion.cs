using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class Detalle_cotizacion
    {
        public int id_detalle_cotizacion { get; set; }
        public int num_cotizacion { get; set; }
        public int id_producto { get; set; }
        public int id_cli { get; set; }
        public int cantidad { get; set; }
        public double precio_uni { get; set; }
        public double total { get; set; }
    }
}
