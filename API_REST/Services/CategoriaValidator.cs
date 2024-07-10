using API_REST.Models;
using FluentValidation;

namespace API_REST.Services
{
    public class CategoriaValidator:AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(x => x.Nombre).MinimumLength(2).NotEmpty().WithMessage("Complete todos los campos correctamente (debe tener un minimo de 5 caracteres)");
            RuleFor(x => x.Descripcion).MinimumLength(5).NotEmpty().WithMessage("Complete todos los campos correctamente (debe tener un minimo de 5 caracteres)");
        }
    }
}
