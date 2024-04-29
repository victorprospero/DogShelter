using FluentValidation;

namespace DogShelter.API.V1.Models.Validators
{
    public class DogApiValidator : AbstractValidator<DogApiModel>
    {
        public DogApiValidator() 
        {
            RuleFor(dog => dog.Name).NotEmpty().NotNull();
            RuleFor(dog => dog.BreedName).NotEmpty().NotNull();
        }
    }
}
