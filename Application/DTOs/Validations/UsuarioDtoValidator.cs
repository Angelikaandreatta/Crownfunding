using FluentValidation;

namespace Application.DTOs.Validations
{
    public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email deve ser informado.");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .NotNull()
                .WithMessage("Senha deve ser informada.");
        }
    }
}
