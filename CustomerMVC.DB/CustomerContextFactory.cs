using Microsoft.EntityFrameworkCore;

namespace CustomerMVC.DB
{
    public class CustomerContextFactory
    {
        public CustomerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
            
            return new CustomerContext(optionsBuilder.Options);
        }
    }
}
