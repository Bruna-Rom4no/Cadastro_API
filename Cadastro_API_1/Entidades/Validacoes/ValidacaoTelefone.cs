using FluentValidation;

namespace Cadastro_API_1.Entidades.Validacoes
{
    public class ValidacaoTelefone : AbstractValidator<Telefone>
    {
        public ValidacaoTelefone()
        {
            RuleFor(y => y.Numero)
                .NotEmpty().NotNull().WithMessage("O campo deve ser preenchido.");
        }
    }
}
