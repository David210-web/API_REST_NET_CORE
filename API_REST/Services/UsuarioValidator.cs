using API_REST.Models;
using FluentValidation;

namespace API_REST.Services
{
    public class UsuarioValidator: AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nombre).Length(3,20).NotEmpty().WithMessage("Completa todos los campos (este campos debe tener de 3 a 20 caracteres)");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Completa todos los campos (ingresa un correo valido)");
            RuleFor(x => x.Contrasena).MinimumLength(6).NotEmpty().WithMessage("Completa todos los campos (la contraseña debe tener minimo 6 caractere)");
            RuleFor(x => x.Rol).NotEmpty().WithMessage("Completa todos los campos ");

        }
    }
}
