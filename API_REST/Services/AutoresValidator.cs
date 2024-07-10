using API_REST.Models;
using FluentValidation;

namespace API_REST.Services
{
    public class AutoresValidator : AbstractValidator<Autore>
    {
        public AutoresValidator()
        {
            RuleFor(x => x.Nombre).NotNull().WithMessage("Digite todos los campos");
            RuleFor(x => x.Biografia).NotNull().WithMessage("Digite todos los campos");
        }
    }
}
