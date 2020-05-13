using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Entidades
{
   public  class CategoriasE
    {
        [Display(Name = "ID Categoria")]
        public int id_categoria { get; set; }
        public String nombre { get; set; }
    }
}
