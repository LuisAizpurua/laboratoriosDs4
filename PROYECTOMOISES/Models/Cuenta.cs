using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROYECTOMOISES.Models
{
    public class Cuenta
    {
        public int IdCuenta { get; set; }
        public int IdUsuario { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Monto { get; set; }
    }
}