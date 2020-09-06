using System;
using System.Collections.Generic;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public partial class TransaccionesEntidad
    {
        public int Id { get; set; }
        public string TipoTransaccion { get; set; }
        public string EntidadAfectada { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaTransaccion { get; set; }
    }
}
