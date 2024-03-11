using CustomerMVC.DB;
using CustomerMVC.DB.Repositories;
using CustomerMVC.Model;
using CustomerMVC.Model.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components;

namespace CustomerMVC.Controllers
{
    public class CustomerController : ComponentBase
    {
        internal List<Customer> Customers { get; set; } = new List<Customer>();
        internal string Message { get; set; } = "";
        protected IGenericRepository<Customer> Repository { get; set; } = new GenericRepository<Customer>(new CustomerContext(new Microsoft.EntityFrameworkCore.DbContextOptions<CustomerContext>()));
        private CustomerValidator CustomerValidator = new CustomerValidator();
        private readonly ILogger<CustomerController> Logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            Logger = logger;
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadCustomers();
        }

        internal async Task LoadCustomers()
        {
            Customers = (await Repository.GetAllAsync()).ToList();
        }

        internal async Task AddCustomer(Customer customer)
        {
            var result = CustomerValidator.Validate(customer);
            if (!result.IsValid)
            {
                GetValidationMessage(result);
                return;
            }
            await Repository.AddAsync(customer);
            await LoadCustomers();
            Message = "Customer added successfully.";
        }

        internal async Task UpdateCustomer(Customer customer)
        {
            var result = CustomerValidator.Validate(customer);
            if (!result.IsValid)
            {
                GetValidationMessage(result);
                return;
            }
            await Repository.UpdateAsync(customer);
            await LoadCustomers();
            Message = "Customer updated successfully.";
        }

        internal async Task DeleteCustomer(Customer customer)
        {
            var result = CustomerValidator.Validate(customer);
            if (!result.IsValid)
            {
                GetValidationMessage(result);
                return;
            }
            await Repository.DeleteAsync(customer);
            await LoadCustomers();
            Message = "Customer deleted successfully.";
        }

        private void GetValidationMessage(ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                Message += ($"Property: {error.PropertyName}, Error: {error.ErrorMessage}");
            }
        }

    }
}

