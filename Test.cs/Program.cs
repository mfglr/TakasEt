using FluentValidation;


var customer = new Customer();
var customerValidator = new CustomerValidator();



var validationResult = await customerValidator.ValidateAsync(customer);

var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage);

foreach (var error in errorMessages)
    Console.WriteLine(error);


class Customer
{
	public string Name { get; set; }
}

class CustomerValidator : AbstractValidator<Customer> {

    public CustomerValidator()
    {
		RuleFor(customer => customer.Name).NotEmpty().WithMessage("{PropertyName} is required!");
    }
}