using FluentValidation;
using PT.Dasigno.DTO.Users;

namespace PT.Dasigno.API.Validation.User
{
    public class ValidationCreateUser : AbstractValidator<CreateUserRequest>
    {
        public ValidationCreateUser()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required")
                .ChildRules(x => x.RuleFor(y => y.Length).LessThanOrEqualTo(50).WithMessage("FirstName must be less than or equal to 50 characters"));

            RuleFor(x => x.MiddleName)
                .ChildRules(x => x.RuleFor(y => y.Length).LessThanOrEqualTo(50).WithMessage("MiddleName must be less than or equal to 50 characters"));

            RuleFor(x => x.FirstLastName)
                .NotEmpty().WithMessage("FirstLastName is required")
                .ChildRules(x => x.RuleFor(y => y.Length).LessThanOrEqualTo(50).WithMessage("FirstLastName must be less than or equal to 50 characters"));

            RuleFor(x => x.SecondLastName)
                .ChildRules(x => x.RuleFor(y => y.Length).LessThanOrEqualTo(50).WithMessage("SecondLastName must be less than or equal to 50 characters")); 

            RuleFor(x => x.Birthdate)
                .NotEmpty().WithMessage("Birthdate is required")
                .LessThan(DateTime.Now).WithMessage("Birthdate must be less than current date")
                .Must(x => x != DateTime.MinValue).WithMessage("Birthdate is not valid");

            RuleFor(x => x.Salary)
                .NotEmpty().WithMessage("Salary is required")
                .GreaterThan(0).WithMessage("Salary must be greater than 0");
        }
    }
}
