using FluentValidation;
using IMovies.API.DTOs;

namespace IMovies.API.Helper.Validations
{
    public class AuthenticationValidator : AbstractValidator<AuthenticationDto>
    {
        public AuthenticationValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Usuário de acesso é obrigatório.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Senha é obrigatório.");
        }
    }
}