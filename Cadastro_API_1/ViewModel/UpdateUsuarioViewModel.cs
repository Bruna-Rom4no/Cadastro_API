using System.ComponentModel.DataAnnotations;

namespace Cadastro_API_1.ViewModel
{
    public class UpdateUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo deve ser preenchido.")]
        [MaxLength(80, ErrorMessage = "O campo deve ter no máximo 80 caracteres.")]
        [MinLength(3, ErrorMessage = "O campo deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo deve ser preenchido.")]
        public string CPF { get; set; }
    }
}
