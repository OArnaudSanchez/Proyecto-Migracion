using FluentValidation;
using ProyectoMigracion.Core.DTOs;

namespace ProyectoMigracion.Core.Validators
{
    public class PersonaValidator : AbstractValidator<PersonaDTO>
    {
        public PersonaValidator()
        {
            RuleFor(x => x.Nombre).NotNull().NotEmpty();
            RuleFor(x => x.Apellido).NotNull().NotEmpty();
            RuleFor(x => x.FechaNacimiento).NotNull().NotEmpty();
            RuleFor(x => x.Pasaporte).NotNull().NotEmpty();
            RuleFor(x => x.Direccion).NotNull().NotEmpty();
            RuleFor(x => x.Sexo).NotNull().NotEmpty();
            RuleFor(x => x.ImagenArchivo).NotNull().NotEmpty();
        }
    }
}
