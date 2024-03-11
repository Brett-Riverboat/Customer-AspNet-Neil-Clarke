namespace CustomerMVC.Model.Validation
{
    using CustomerMVC.Model;
    using FluentValidation;

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(customer => customer.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address.");
            RuleFor(customer => customer.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(customer => customer.DateOfBirth).NotEmpty().WithMessage("Date of birth is required.").Must(BeAValidDateOfBirth).WithMessage("Invalid date of birth.");
        }

        private bool BeAValidDateOfBirth(DateTime dateOfBirth)
        {
            // Ensure the date of birth is not in the future
            return dateOfBirth <= DateTime.Today;
        }
    }

}