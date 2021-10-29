using FluentValidation;
using ProyectoMigracion.Core.DTOs;

namespace ProyectoMigracion.Core.Validators
{
    public class SolicitudValidator : AbstractValidator<SolicitudDTO>
    {
        public SolicitudValidator()
        {
            RuleFor(x => x.NombreEstado).NotNull().NotEmpty();
            RuleFor(x => x.PersonaId).NotNull().NotEmpty();
        }
    }
}
