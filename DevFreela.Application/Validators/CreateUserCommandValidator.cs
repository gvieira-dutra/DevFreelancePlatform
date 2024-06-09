using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Password must contain at least 6 characters, 1 number, 1 lower case letter, 1 upper case letter and 1 special character.");

            RuleFor(p => p.BirthDate)
                .Must(ValidBday)
                .WithMessage("You must be at least 18 years old to have an account");

            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("Please enter you full name")
                .NotNull().WithMessage("Please enter you full name");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=].*$)");

            return regex.IsMatch(password);
        }

        public bool ValidBday(DateTime bday)
        {
            return bday < DateTime.Now.AddYears(-18);
        }

    }
}
