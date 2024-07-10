using API_REST.DTOs;
using FluentValidation;


namespace API_REST.Services
{
    public class LibroDTOValidator : AbstractValidator<LibroCreateDTO>
    {
        public LibroDTOValidator() {

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
            RuleFor(x => x.Disponible)
                .NotNull().WithMessage("La disponibilidad es obligatoria.");
        }
    }
}
