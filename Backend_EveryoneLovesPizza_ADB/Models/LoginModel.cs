using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_EveryoneLovesPizza_ADB.Models
{
    public class LoginModel
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public Empleado? Empleado { get; set; }
        public string? Token { get; set; }

    }
}
