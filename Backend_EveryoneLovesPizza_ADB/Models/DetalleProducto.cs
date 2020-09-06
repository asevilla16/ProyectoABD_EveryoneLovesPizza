using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class DetalleProducto
    {
        public int Id { get; set; }
        public int Idproducto { get; set; }
        public string UnidadMedidaInsumos { get; set; }
        public int Idinsumo { get; set; }
        public int CantidadInsumo { get; set; }

        public virtual Insumos IdinsumoNavigation { get; set; }
        public virtual Producto IdproductoNavigation { get; set; }
    }
}
