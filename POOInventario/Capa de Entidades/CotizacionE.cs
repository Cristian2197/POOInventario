using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
    public class CotizacionE
    {
        public int num_cotizacion { get; set; }
        public Nullable <int> id_emp { get; set; }
        public int id_cli { get; set; }
        public DateTime fecha_cotizacion { get; set; }
        public float total { get; set; }

    }
}
