using System.ComponentModel.DataAnnotations;

namespace APIRest.Model.Dto
{
    public class PeliculaModificacionDto
    {
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Director { get; set; }

        [MaxLength(100)]
        public string Sinopsis { get; set; }

        public DateTime FechaEstreno { get; set; }
    }
}
