
using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .NotNull().WithMessage("Description cannot be empty")
                .MaximumLength(255).WithMessage("Description cannot have more than 255 characters");

            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Title cannot be empty")
                .NotNull().WithMessage("Title cannot be empty")
                .MaximumLength(63).WithMessage("Title cannot be longer than 63 characters");

            RuleFor(t => t.TotalCost)
                .GreaterThan(0)
                .WithMessage("Please enter a value greater than 0 for the total cost");
        }
    }
}
