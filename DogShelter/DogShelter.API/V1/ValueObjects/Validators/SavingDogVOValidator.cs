using DogShelter.API.V1.Models;
using FluentValidation;

namespace DogShelter.API.V1.ValueObjects.Validators
{
    public class SavingDogVOValidator : AbstractValidator<SavingDogVO>
    {
        public SavingDogVOValidator()
        {
            RuleFor(dog => dog.DogName).NotEmpty().NotNull();
            RuleFor(dog => dog.BreedName).NotEmpty().NotNull();
        }
    }
}
