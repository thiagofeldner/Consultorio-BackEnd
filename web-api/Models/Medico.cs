using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CRM é obrigatório.", AllowEmptyStrings = true)]
        [StringLength(9, MinimumLength = 3, ErrorMessage = "CRM deve ter no mínimo 9 caracteres.")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve conter apenas letras.")]
        [RegularExpression("^[A-Za-zà-ú ]+$", ErrorMessage = "Nome deve conter apenas letras.")]
        public string Nome { get; set; }

        //public List<string> Especialidades { get; set; }

        public Medico()
        {
            this.CRM = string.Empty;
            this.Nome = "";
            //this.Especialidades = new List<string>();
        }
    }
}