using DevFreela.Application.Commands.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(c => c.Content)
                .NotNull().WithMessage("Comment cannot be empty")
                .NotEmpty().WithMessage("Comment cannot be empty")
                .MaximumLength(255).WithMessage("The maximum number of characters for a comment is 255 characters.");

            RuleFor(i => i.IdProject)
                .NotNull().WithMessage("Project Id cannot be empty")
                .NotEmpty().WithMessage("Project Id cannot be empty");

            RuleFor(i => i.IdUser)
                .NotNull().WithMessage("User Id cannot be empty")
                .NotEmpty().WithMessage("User Id cannot be empty");
        }
    }
}
