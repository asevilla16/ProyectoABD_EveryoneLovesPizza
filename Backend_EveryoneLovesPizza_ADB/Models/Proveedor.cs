using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            OrdenCompra = new HashSet<OrdenCompra>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<OrdenCompra> OrdenCompra { get; set; }
    }
}
