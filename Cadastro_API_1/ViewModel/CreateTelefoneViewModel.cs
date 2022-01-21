using System.ComponentModel.DataAnnotations;

namespace Cadastro_API_1.ViewModel
{
    public class CreateTelefoneViewModel
    {
        [Required(ErrorMessage = "O campo deve ser preenchido.")]
        public string Numero { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Insira um identificador de usuário valido!")]
        [Required(ErrorMessage = "O campo deve ser preenchido")]
        public long UsuarioId { get; set; }

    }
}
