using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class OrdenVenta
    {
        public OrdenVenta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }
        public int Idcliente { get; set; }
        public decimal Total { get; set; }
        public int Idencargado { get; set; }
        public string EstadoOrden { get; set; }
        public DateTime? FechaOrden { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Empleado IdencargadoNavigation { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
