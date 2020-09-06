using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            OrdenVenta = new HashSet<OrdenVenta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public int Idfuncion { get; set; }
        public string Telefono { get; set; }
        public string Status { get; set; }
        public bool IsSuperAdmin { get; set; }

        public virtual Funciones IdfuncionNavigation { get; set; }
        public virtual ICollection<OrdenVenta> OrdenVenta { get; set; }
    }
}
