using Microsoft.EntityFrameworkCore;
using CustomerMVC.Model;

namespace CustomerMVC.DB
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO
            //optionsBuilder.UseSqlServer("Server=localhost;Database=MyDatabase;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelBase>().HasKey(e => e.Id);
        }


    }
}
