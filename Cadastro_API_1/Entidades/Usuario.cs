using Cadastro_API_1.Entidades.Validacoes;
using Cadastro_API_1.GerenCore.Exceçoes;
using System.Collections.Generic;

namespace Cadastro_API_1.Entidades
{
    public class Usuario : Base
    {
        public string Nome { get; private set; }

        public string CPF { get; private set; }

        public bool Ativo { get; private set; }
        public virtual ICollection<Telefone> Telefones { get; set; }

        protected Usuario() { }

        public void MudarNome(string nome)
        {
            Nome = nome;
        }

        public void MudarCpf(string cpf)
        {
            CPF = cpf;
        }

        public void MudarAtivo(bool ativo)
        {
            Ativo = ativo;
        }

        public Usuario(string nome, string Cpf)
        {
            Nome = nome;
            CPF = Cpf;
            Ativo = true;
            _erros = new List<string>();

            Validar();
        }

        public override bool Validar()
        {
            var validacao = new ValidacaoUsuario();
            var validacao_1 = validacao.Validate(this);

            if (!validacao_1.IsValid)
            {
                foreach (var erro in validacao_1.Errors)
                {
                    _erros.Add(erro.ErrorMessage);
                    throw new ExcecaoDominio("Alguns campos estão inválidos", _erros);
                }
                return true;
            }
            return false;
        }
    }
}
