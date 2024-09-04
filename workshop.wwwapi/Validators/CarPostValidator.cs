using FluentValidation;
using workshop.wwwapi.Models;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Validators
{
    public class CarPostValidator : AbstractValidator<CarPostModel>
    {
        public CarPostValidator()
        {
            RuleFor(c => c.Make).MaximumLength(255).Must(c => c.Length>=1).WithMessage("lengh must be 1!").NotEmpty(); 
            RuleFor(c => c.Model).MaximumLength(255).NotEmpty();
        }
    }
}
