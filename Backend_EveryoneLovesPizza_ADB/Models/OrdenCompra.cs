using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class OrdenCompra
    {
        public OrdenCompra()
        {
            DetalleCompra = new HashSet<DetalleCompra>();
        }

        public int Id { get; set; }
        public int Idproveedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime Fechaingreso { get; set; }

        public virtual Proveedor IdproveedorNavigation { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
    }
}
