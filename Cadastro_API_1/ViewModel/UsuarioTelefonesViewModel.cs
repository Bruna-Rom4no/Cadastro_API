using System.Collections.Generic;

namespace Cadastro.API.ViewModel
{
    public class UsuarioTelefonesViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<TelefonesViewModel> Telefones { get; set; }
    }

    public class TelefonesViewModel
    {
        public TelefonesViewModel(long id, string numero)
        {
            Id = id;
            Numero = numero;
        }

        public long Id { get; set; }
        public string Numero { get; set; }
    }
}
