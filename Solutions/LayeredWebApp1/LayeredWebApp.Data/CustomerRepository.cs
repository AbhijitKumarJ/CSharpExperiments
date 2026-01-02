namespace LayeredWebApp.Data;

public interface ICustomerRepository
{
    // Define methods for customer data access
    public object GetCustomerById(int id);
}

public class CustomerRepository : ICustomerRepository
{
    public CustomerRepository()
    {
        // Constructor implementation (if needed)
    }

    public object GetCustomerById(int id)
    {
        // Implementation for retrieving a customer by ID from the database
        return new { CustomerId = id, FirstName = "John", LastName = "Doe" };
    }
}