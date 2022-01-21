using FluentValidation;

namespace Cadastro_API_1.Entidades.Validacoes
{
    public class ValidacaoUsuario : AbstractValidator<Usuario>
    {
        public ValidacaoUsuario()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo deve ser preenchido.")
                .Length(3, 80).WithMessage("O campo deve ter no mínimo 3 caracteres, e no máximo 80 caracteres.");

            RuleFor(x => x.CPF)
                .NotEmpty().NotNull().WithMessage("O campo deve ser preenchido.");
        }
    }
}
