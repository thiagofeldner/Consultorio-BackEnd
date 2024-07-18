using System;
using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Paciente
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        public DateTime? DataNascimento {  get; set; }
    }
}