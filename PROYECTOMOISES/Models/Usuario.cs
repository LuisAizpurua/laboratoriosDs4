using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PROYECTOMOISES.Models
{



        public class Usuario
        {
            [Required(ErrorMessage = "El nombre es obligatorio.")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "El apellido es obligatorio.")]
            [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
            public string Apellido { get; set; }

            [Required(ErrorMessage = "El correo es obligatorio.")]
            [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
            public string Correo { get; set; }

            [Required(ErrorMessage = "La contraseña es obligatoria.")]
            [StringLength(255, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 255 caracteres.")]
            public string Contrasena { get; set; }
        }
    


}