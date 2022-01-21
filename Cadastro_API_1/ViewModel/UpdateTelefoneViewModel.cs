using System.ComponentModel.DataAnnotations;

namespace Cadastro_API_1.ViewModel
{
    public class UpdateTelefoneViewModel
    {
        [Required(ErrorMessage = "O campo deve ser preenchido.")]
        [MaxLength(11, ErrorMessage = "O campo deve ter no máximo 80 caracteres.")]
        public string Numero { get; set; }
    }
}
