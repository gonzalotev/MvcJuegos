using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCJuegos.Models
{
    public class Juegos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El videoJuego debe tener un Nombre")]
        [StringLength(50, ErrorMessage = "El Nombre tiene un maximo de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(50, ErrorMessage = "La descripcion tiene un maximo de 50 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El enlace es obligatoria")]
        public string Enlace { get; set; }

        [Required(ErrorMessage = "La consola es obligatoria")]
        public string Consola { get; set; }

        public string Genero { get; set; }

        public string Imagen { get; set; }
    }
}
