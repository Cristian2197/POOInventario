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
    
    public partial class Detalle_Factura
    {
        public int id_detalle_venta { get; set; }
        public Nullable<int> id_factura { get; set; }
        public Nullable<int> id_producto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> precio_uni { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<int> id_tipo_pago { get; set; }
    
        public virtual Facturas Facturas { get; set; }
    }
}
