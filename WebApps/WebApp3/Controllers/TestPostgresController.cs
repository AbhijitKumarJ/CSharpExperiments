using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp3.Data;
using WebApp3.Models;

namespace WebApp3.Controllers;

[ApiController]
[Route("api/TestPostgres")]
public class TestPostgresController : ControllerBase
{
    private readonly ILogger<TestPostgresController> _logger;
    private readonly DvdRentalContext _db;

    public TestPostgresController(ILogger<TestPostgresController> logger, DvdRentalContext db)
    {
        _logger = logger;
        _db = db;
    }

    // GET: api/TestPostgres/GetCustomers
    [HttpGet("GetCustomers")]
    public async Task<IActionResult> GetCustomers([FromQuery]int limit,CancellationToken cancellationToken)
    {
        var list = await _db.Customers
            .AsNoTracking()
            .OrderByDescending(c => c.CustomerId)
            .Take(limit)
            .ToListAsync(cancellationToken);
        return Ok(list);
    }

    // GET: api/TestPostgres/GetCustomer/5
    [HttpGet("GetCustomer/{id:int}")]
    public async Task<IActionResult> GetCustomer(int id, CancellationToken cancellationToken)
    {
        var customer = await _db.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.CustomerId == id, cancellationToken);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    // POST: api/TestPostgres/CreateCustomer
    [HttpPost("CreateCustomer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto dto, CancellationToken cancellationToken)
    {
        if (dto == null) return BadRequest();

        var entity = new Customer
        {
            StoreId = dto.StoreId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            AddressId = dto.AddressId,
            ActiveBool = dto.ActiveBool,
            Active = dto.Active,
            CreateDate = dto.CreateDate ?? DateTime.UtcNow,
            LastUpdate = dto.LastUpdate
        };

        _db.Customers.Add(entity);
        await _db.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetCustomer), new { id = entity.CustomerId }, entity);
    }

    // POST: api/TestPostgres/UpdateCustomer/5
    [HttpPost("UpdateCustomer/{id:int}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto dto, CancellationToken cancellationToken)
    {
        var existing = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id, cancellationToken);
        if (existing == null) return NotFound();

        existing.StoreId = dto.StoreId;
        existing.FirstName = dto.FirstName;
        existing.LastName = dto.LastName;
        existing.Email = dto.Email;
        existing.AddressId = dto.AddressId;
        existing.ActiveBool = dto.ActiveBool;
        existing.Active = dto.Active;
        existing.LastUpdate = dto.LastUpdate ?? DateTime.UtcNow;

        await _db.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    // GET: api/TestPostgres/DeleteCustomer/5
    [HttpGet("DeleteCustomer/{id:int}")]
    public async Task<IActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
    {
        var existing = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id, cancellationToken);
        if (existing == null) return NotFound();

        _db.Customers.Remove(existing);
        await _db.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    public record CustomerDto
    (
        short StoreId,
        string FirstName,
        string LastName,
        string? Email,
        short AddressId,
        bool ActiveBool,
        int? Active,
        DateTime? CreateDate,
        DateTime? LastUpdate
    );

}
