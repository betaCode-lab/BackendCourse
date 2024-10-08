using Backend.DTOs.BeerDTOs;
using FluentValidation;

namespace Backend.Validators.Beers
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe contener de 2 a 20 caracteres");
            RuleFor(x => x.BrandID).GreaterThan(0).WithMessage("La marca es obligatoria");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage("El {PropertyName} es debe ser mayor a cero");
        }
    }
}
