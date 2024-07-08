using FluentValidation;
using IMovies.API.DTOs.Movie;

namespace IMovies.API.Helper.Validations
{
    public class MovieValidator : AbstractValidator<CreateOrUpdateMovieDto>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Titulo é obrigatório.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Descrição é obrigatório.");
            RuleFor(x => x.Duration).Must(vrDuration).WithMessage("Duração minima deve ser maior que 30 minutos e duração maxima até 240.");
            RuleFor(x => x.Gender).Must(vrGender).WithMessage("Gênero é obrigatório.");
            RuleFor(x => x.Year).Must(VrDate).WithMessage("Ano lançamento não atende a condição definida.");
        }

        private bool vrGender(List<string> list)
        {
            bool vr = false;
            if (list.Count > 0)
                vr = true;

            return vr;
        }

        private bool vrDuration(int arg)
        {
            bool vr = false;
            if (arg > 30 && arg <= 240)
                vr = true;

            return vr;
        }

        private bool VrDate(int ano)
        {
            bool vr = false;

            if (ano >= 1900 && ano <= DateTime.UtcNow.Year)
                vr = true;
            else
                vr = false;

            return vr;
        }
    }
}