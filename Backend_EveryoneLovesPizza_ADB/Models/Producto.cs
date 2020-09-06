using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleProducto = new HashSet<DetalleProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<DetalleProducto> DetalleProducto { get; set; }
    }
}
