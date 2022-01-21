namespace Cadastro_API_1.GerenServicos.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public UsuarioDTO()
        {

        }

        public UsuarioDTO(string nome, string cpf, string numero)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
