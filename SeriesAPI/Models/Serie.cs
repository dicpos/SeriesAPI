using System;
using System.ComponentModel.DataAnnotations;

namespace SeriesAPI.Models
{
    public class Serie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo de duração é obrigatório")]
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 600.")]
        public int Temporada { get; set; }
        [Required(ErrorMessage = "O campo de temporada é obrigatório")]
        public int Episodio { get; set; }
        [Required(ErrorMessage = "O campo de episodio é obrigatório")]
        public string Genero { get; set; }
    }
}
