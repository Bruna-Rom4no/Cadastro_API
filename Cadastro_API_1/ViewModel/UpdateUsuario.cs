using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financeiro.ViewModel
{
    public class UpdateUsuario
    {
        [Required(ErrorMessage = "O campo não pode ficar vazio.")]
        [MaxLength(250, ErrorMessage = "O campo deve ter no mínimo 250 caracteres.")]
        [MinLength(3, ErrorMessage = "O campo deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar vazio.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar vazio.")]
        public DateTime DataNascimento { get; set; }
    }
}
