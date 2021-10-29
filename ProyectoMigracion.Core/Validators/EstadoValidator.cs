using FluentValidation;
using ProyectoMigracion.Core.DTOs;

namespace ProyectoMigracion.Core.Validators
{
    public class EstadoValidator : AbstractValidator<EstadoDTO>
    {
        public EstadoValidator()
        {
            RuleFor(x => x.NombreEstado).NotEmpty().NotNull();
        }
    }
}
