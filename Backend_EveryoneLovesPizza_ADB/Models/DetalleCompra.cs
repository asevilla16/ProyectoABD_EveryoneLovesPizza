using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class DetalleCompra
    {
        public int Id { get; set; }
        public int IdordenCompra { get; set; }
        public int Idinsumos { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string UnidadMedida { get; set; }
        public int CantidadFacturada { get; set; }
        public string AutorizadaPor { get; set; }

        public virtual Insumos IdinsumosNavigation { get; set; }
        public virtual OrdenCompra IdordenCompraNavigation { get; set; }
    }
}
