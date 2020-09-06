using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class Funciones
    {
        public Funciones()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Iddepartamento { get; set; }

        public virtual Departamento IddepartamentoNavigation { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
