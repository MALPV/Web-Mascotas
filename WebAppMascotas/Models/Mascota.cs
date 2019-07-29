using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMascotas.Models
{
    public class Mascota
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(1, 100000, ErrorMessage = "Debe ser mayor a 0.")]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "¡Error! Longitud entre 1 y 50 caracteres.", MinimumLength = 1)]
        public string nomMascota { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "¡Error! Longitud entre 1 y 50 caracteres.", MinimumLength = 1)]
        public string raza { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(1, 30, ErrorMessage = "¡Error! La edad debe ser entre 1 a 30 años.")]
        public int edad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(1, 2, ErrorMessage = "¡Error! Recordar que para Macho es 1 y Hembra es 2.")]
        public int sexo { get; set; }
    }
}