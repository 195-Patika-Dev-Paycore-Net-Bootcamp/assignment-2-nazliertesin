using FluentValidation;
using StaffApi.Model;

namespace StaffApi.Validation
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(x => x.Name)
            .MinimumLength(20).WithMessage("Name must be greater than 20 characters.")
            .MaximumLength(120).WithMessage("Name must be less than 120 characters.");

            RuleFor(x => x.Lastname)
            .MinimumLength(20).WithMessage("Lastname must be greater than 20 characters.")
            .MaximumLength(120).WithMessage("Lastname must be less than 120 characters.");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Email Address not valid"); ;

            RuleFor(x => x.DateOfBirth).InclusiveBetween(new DateTime(1945, 11, 11), new DateTime(2002, 10, 10)).WithMessage("DateOfBirth not valid");

            RuleFor(x => x.Salary)
            .LessThan(9000).WithMessage("Salary must be less than 9000 tl.")
            .GreaterThan(2000).WithMessage("Salary must be greate than 2000 tl.");


            RuleFor(p => p.PhoneNumber)
           .NotEmpty()
          .NotNull().WithMessage("Phone Number is required.")
          .Length(10).WithMessage("PhoneNumber must be 10 characters.Please write your phone number without leading zero.");

            //.Matches(new Regex(@"^((?:[0-9]\-?){6,14}[0-9])|((?:[0-9]\x20?){6,14}[0-9])$")).WithMessage("PhoneNumber not valid");

        }
    }
}
