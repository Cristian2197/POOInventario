//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capa_Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detalle_inventario
    {
        public int id_detalle_inventario { get; set; }
        public Nullable<int> id_inventario { get; set; }
        public Nullable<int> id_producto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> precio { get; set; }
        public Nullable<int> saldo_unidades { get; set; }
        public Nullable<decimal> saldo_dinero { get; set; }
    
        public virtual Inventario Inventario { get; set; }
    }
}