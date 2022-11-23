using FluentValidation;

namespace Application.DTOs.Validations
{
    public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email deve ser informado.");

            RuleFor(x => x.Telefone)
               .NotEmpty()
               .NotNull()
               .WithMessage("Telefone deve ser informado.");
        }
    }
}
