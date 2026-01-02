using LayeredWebApp.Data.DBModel;

namespace LayeredWebApp.Data;

public interface ICustomerRepository
{
    // Define methods for customer data access
    public object GetCustomerById(int id);
}

public class CustomerRepository : ICustomerRepository
{
    private readonly DvdRentalContext _context;

    public CustomerRepository(DvdRentalContext context)
    {
        _context = context;
    }

    public object GetCustomerById(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        // Implementation for retrieving a customer by ID from the database
        //return new { CustomerId = id, FirstName = "John", LastName = "Doe" };

        return customer??new object();
    }
}