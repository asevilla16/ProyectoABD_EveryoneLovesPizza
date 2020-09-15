using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class Insumos
    {
        public Insumos()
        {
            DetalleCompra = new HashSet<DetalleCompra>();
            DetalleProducto = new HashSet<DetalleProducto>();
            DetalleVenta = new HashSet<DetalleVenta>();
            Inventario = new HashSet<Inventario>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Idcategoria { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedidaVenta { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime Fechacaducidad { get; set; }
        public string UnidadMedidaAlmacenamiento { get; set; }

        public virtual Categoria IdcategoriaNavigation { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
        public virtual ICollection<DetalleProducto> DetalleProducto { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
