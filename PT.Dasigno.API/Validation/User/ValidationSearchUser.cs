using FluentValidation;
using PT.Dasigno.DTO.Users;

namespace PT.Dasigno.API.Validation.User
{
    public class ValidationSearchUser : AbstractValidator<SearchUserRequest>
    {
        public ValidationSearchUser()
        {
            RuleFor(x => x.PageNumber)
                .NotEmpty().WithMessage("PageNumber is required")
                .GreaterThan(0).WithMessage("PageNumber must be greater than 0");

            RuleFor(x => x.PageSize)
                .NotEmpty().WithMessage("PageSize is required")
                .GreaterThan(0).WithMessage("PageSize must be greater than 0");
        }
    }
}
