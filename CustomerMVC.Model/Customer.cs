namespace CustomerMVC.Model
{
    public enum AccountStatus
    {
        None,
        Active,
        Suspended
    }

    public class Customer : ModelBase
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        public override string ToString()
        {
            return $"CustomerID: {Id}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {PhoneNumber}, DOB: {DateOfBirth.ToShortDateString()}";
        }

    }
}
