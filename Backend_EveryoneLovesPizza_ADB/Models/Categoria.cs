using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Insumos = new HashSet<Insumos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Insumos> Insumos { get; set; }
    }
}
