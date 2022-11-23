

using FluentValidation;

namespace Application.DTOs.Validations
{
    public class PessoaDtoValidator : AbstractValidator<PessoaDto>
    {
        public PessoaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado!");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Telefone deve ser informado!");
        }
    }
}
