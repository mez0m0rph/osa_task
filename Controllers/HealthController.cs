using DotNetApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApi.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    private readonly AppDbContext _db;

    public HealthController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Health()
    {
        try
        {
            _db.Database.CanConnect();
            return Ok(new { status = "ok" });
        }
        catch
        {
            return StatusCode(500, new { status = "db_error" });
        }
    }
}
