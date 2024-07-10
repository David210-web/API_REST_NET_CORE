using API_REST.Models;
using FluentValidation;

namespace API_REST.Services
{
    public class PrestamosValidator : AbstractValidator<Prestamo>
    {
        public PrestamosValidator() {
            RuleFor(x => x.UsuarioId).NotNull().NotEmpty().WithMessage("Ingrese el campo del id de usuario");
            RuleFor(x => x.LibroId).NotNull().NotEmpty().WithMessage("Ingrese el campo del id de libro");
            RuleFor(x => x.FechaPrestamo)
                .Must(date => date != default(DateOnly)).WithMessage("La fecha de prestamo es obligatoria.");
            RuleFor(x => x.FechaDevolucion)
                .Must(date => date != default(DateOnly)).WithMessage("La fecha de devolucion es obligatoria.");
            RuleFor(x => x.Estado).NotNull().NotEmpty().WithMessage("El estado es obligatorio");
        }
    }
}
