using API_REST.Models;
using FluentValidation;

namespace API_REST.Services
{
    public class LibroValidator:AbstractValidator<Libro>
    {
        public LibroValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.");
            RuleFor(x => x.AutorId)
                .NotEmpty().WithMessage("El autor es obligatorio.");
            RuleFor(x => x.CategoriaId)
                .NotEmpty().WithMessage("La categoría es obligatoria.");
            RuleFor(x => x.Sinopsis)
                .NotEmpty().WithMessage("La sinopsis es obligatoria.");
            RuleFor(x => x.FechaPublicacion)
                .Must(date => date != default(DateOnly)).WithMessage("La fecha de publicación es obligatoria.");
           


        }
    }
}
