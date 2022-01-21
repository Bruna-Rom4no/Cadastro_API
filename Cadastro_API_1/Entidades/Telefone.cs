using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro_API_1.Entidades.Validacoes;

namespace Cadastro_API_1.Entidades
{
    public class Telefone : Base
    {
        public string Numero { get; private set; }

        public bool Ativo { get; private set; }
        public long UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        protected Telefone() { }

        public Telefone(string numero)
        {
            Numero = numero;
            Ativo = true;
        }

        public void MudarNumero(string numero)
        {
            Numero = numero;
        }

        public void  MudarAtivo(bool ativo)
        {
            Ativo = ativo;
        }

        public override bool Validar()
        {
            var validacao2 = new ValidacaoTelefone();
            var validacao_2 = validacao2.Validate(this);

            if (!validacao_2.IsValid)
            {
                foreach (var erro in validacao_2.Errors)
                {
                    _erros.Add(erro.ErrorMessage);
                    throw new Exception("Alguns campos estão inválidos" + _erros[0]);
                }
                return true;
            }
            return false;
        }
    }
}
