using FluentValidation;

namespace Application.DTOs.Validations
{
    public class ProjetoDtoValidator : AbstractValidator<ProjetoDto>
    {
        public ProjetoDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição deve ser informada.");

            RuleFor(x => x.Links)
               .NotEmpty()
               .NotNull()
               .WithMessage("Links deve ser informado.");

            RuleFor(x => x.Meta)
               .NotEmpty()
               .NotNull()
               .WithMessage("Meta financeira deve ser informada.");

            RuleFor(x => x.Categoria)
                .NotEmpty()
                .NotNull()
                .WithMessage("Categoria deve ser informada.");
        }
    }
}
