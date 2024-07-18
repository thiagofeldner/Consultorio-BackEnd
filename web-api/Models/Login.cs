using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [StringLength(50, ErrorMessage = "Digite no máximo 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [StringLength(20, ErrorMessage = "Digite entre 5 e 20 caracteres no máximo.")]
        public string Senha { get; set; }
    }
}