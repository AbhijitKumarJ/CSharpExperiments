using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp2.Data;
using WebApp2.Models;

namespace WebApp2.Controllers;

[ApiController]
[Route("api/testsqlite")]
public class TestSqliteController : ControllerBase
{
	private readonly AppDbContext _db;

	public TestSqliteController(AppDbContext db)
	{
		_db = db;
	}

    [Route("GetTodoItems")]
	[HttpGet]
	public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll()
	{
		var items = await _db.TodoItems.AsNoTracking().ToListAsync();
		return Ok(items);
	}

    [Route("GetTodoItem/{id:int}")]
	[HttpGet()]
	public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
	{
		var item = await _db.TodoItems.FindAsync(id);
		if (item == null) return NotFound();
		return Ok(item);
	}

    [Route("CreateTodoItem")]
	[HttpPost]
	public async Task<ActionResult<TodoItem>> Create(TodoItem input)
	{
		_db.TodoItems.Add(input);
		await _db.SaveChangesAsync();
		return CreatedAtAction(nameof(GetTodoItem), new { id = input.Id }, input);
	}

    [Route("UpdateTodoItem/{id:int}")]
	[HttpPost()]
	public async Task<IActionResult> Update(int id, TodoItem input)
	{
		if (id != input.Id) return BadRequest();
		var exists = await _db.TodoItems.AnyAsync(t => t.Id == id);
		if (!exists) return NotFound();
		_db.Entry(input).State = EntityState.Modified;
		await _db.SaveChangesAsync();
		//return NoContent();
        return Ok(input);
	}

    [Route("DeleteTodoItem/{id:int}")]
	[HttpGet()]
	public async Task<IActionResult> Delete(int id)
	{
		var item = await _db.TodoItems.FindAsync(id);
		if (item == null) return NotFound();
		_db.TodoItems.Remove(item);
		await _db.SaveChangesAsync();
		//return NoContent();
        return Ok(item);
	}
}
