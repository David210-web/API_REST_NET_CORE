using API_REST.DTOs;
using FluentValidation;

namespace API_REST.Services
{
    public class PrestamoDTOValidator : AbstractValidator<PrestamoCreateDTO>
    {
        public PrestamoDTOValidator()
        {
            RuleFor(x => x.UsuarioId).NotEmpty().WithMessage("El id del usuario es obligatorio");
            RuleFor(x => x.LibroId).NotEmpty().WithMessage("El id del libro es obligatorio");
            RuleFor(x => x.FechaPrestamo)
                .Must(date => date != default(DateOnly)).WithMessage("La fecha de publicación es obligatoria.");
            RuleFor(x => x.FechaDevolucion);
              
            RuleFor(x => x.Estado).NotEmpty().WithMessage("El estado es obligatorio");

        }
    }

}
