using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace LayeredWebApp.API.Controllers;

[ApiController]
[Route("api/TestPostgres")]
public class TestPostgresController : ControllerBase
{
    private readonly ILogger<TestPostgresController> _logger;
    //private readonly DvdRentalContext _db;

    public TestPostgresController(ILogger<TestPostgresController> logger)//, DvdRentalContext db)
    {
        _logger = logger;
    }

    // GET: api/TestPostgres/GetCustomers
    [HttpGet("GetCustomers")]
    public async Task<IActionResult> GetCustomers([FromQuery]int limit,CancellationToken cancellationToken)
    {
        return Ok(new JObject { ["Message"] = $"Retrieved {limit} customers." });
    }

    // GET: api/TestPostgres/GetCustomer/5
    [HttpGet("GetCustomer/{id:int}")]
    public async Task<IActionResult> GetCustomer(int id, CancellationToken cancellationToken)
    {
        return Ok(new JObject { ["Message"] = $"Retrieved customer with ID {id}." });
    }

    // POST: api/TestPostgres/CreateCustomer
    [HttpPost("CreateCustomer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerEntity entity, CancellationToken cancellationToken)
    {
        if (entity == null) return BadRequest();

        

        return CreatedAtAction(nameof(GetCustomer), new { id = 1 }, entity);
    }

    // POST: api/TestPostgres/UpdateCustomer/5
    [HttpPost("UpdateCustomer")]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerEntity entity, CancellationToken cancellationToken)
    {
        return Ok(new JObject { ["Message"] = $"Updated customer with ID {entity.CustomerId}." });
    }

    // GET: api/TestPostgres/DeleteCustomer/5
    [HttpGet("DeleteCustomer/{id:int}")]
    public async Task<IActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
    {
        return Ok(new JObject { ["Message"] = $"Deleted customer with ID {id}." });
    }
}
