using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
                
        [Required(ErrorMessage = "Nome é obrigatório.", AllowEmptyStrings = true)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve conter de 3 a 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Senha deve conter de 5 a 20 caracteres.")]
        public string Senha { get; set; }
    }
}