﻿using System;
using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Medicamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de Fabricação é obrigatória.")]
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataVencimento { get; set; }
    }
}