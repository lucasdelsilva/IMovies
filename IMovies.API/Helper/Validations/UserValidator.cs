using FluentValidation;
using IMovies.API.DTOs.User;

namespace IMovies.API.Helper.Validations
{
    public class UserValidator : AbstractValidator<RegisterUserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Sobrenome é obrigatório.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Usuário de acesso é obrigatório.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email é obrigatório.");
            RuleFor(x => x.Birthday).Must(VrBirth).WithMessage("Data de nascimento não atende a condição definida.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Senha é obrigatório.");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("A confirmação de senha não confere.");
        }

        private bool VrBirth(DateTime dt)
        {
            bool vr = false;

            if (dt.Year >= 1900 && dt.Year <= DateTime.UtcNow.Year)
                vr = true;
            else
                vr = false;

            return vr;
        }
    }
}
