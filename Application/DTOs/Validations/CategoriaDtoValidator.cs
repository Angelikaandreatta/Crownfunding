using FluentValidation;

namespace Application.DTOs.Validations
{
    public class CategoriaDtoValidator : AbstractValidator<CategoriaDto>
    {
        public CategoriaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado.");
        }
    }
}
