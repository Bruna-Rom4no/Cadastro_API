namespace Cadastro_API_1.GerenServicos.DTO
{
    public class TelefoneDTO
    {
        public string Numero { get; private set; }
        public long UsuarioId { get; set; }
        public TelefoneDTO()
        {

        }

        public TelefoneDTO(string numero, long usuarioId)
        {
            Numero = numero;
            UsuarioId = usuarioId;
        }
    }
}
