using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class Inventario
    {
        public int Id { get; set; }
        public int Idinsumos { get; set; }
        public int Cantidad { get; set; }

        public virtual Insumos IdinsumosNavigation { get; set; }
    }
}
