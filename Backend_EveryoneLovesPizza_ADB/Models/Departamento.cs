using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Funciones = new HashSet<Funciones>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Funciones> Funciones { get; set; }
    }
}
