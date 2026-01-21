using Microsoft.AspNetCore.Mvc;

namespace DotNetApi.Controllers;

[ApiController]
[Route("hello")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Hello()
    {
        return Ok(new { message = "Hello, (test111111) world!" });
    }
}
