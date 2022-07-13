using Microsoft.AspNetCore.Mvc;

namespace proyecto.api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> logger;
    private readonly UserCredentialsService userCredentials;

    public UserController(ILogger<UserController> logger, UserCredentialsService userCredentials)
    {
        this.logger = logger;
        this.userCredentials = userCredentials;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> CreateAsync([FromBody] UserCredentials credentials)
    {
        try
        {
            await userCredentials.CreateAsync(credentials);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut("credentials/{id}")]
    public async Task<IActionResult> UpdateAsync([FromQuery] string id, [FromBody] UserCredentials credentials)
    {
        try
        {
            await userCredentials.UpdateAsync(id, credentials);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("credentials/{id}")]
    public async Task<IActionResult> RemoveAsync([FromQuery] string id)
    {
        try
        {
            await userCredentials.RemoveAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet("credentials")]
    public async Task<ActionResult<IEnumerable<UserCredentials>>> GetAsync()
    {
        try
        {
            var records = await userCredentials.GetAsync();
            return Ok(records);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet("credentials/{id}")]
    public async Task<ActionResult<IEnumerable<UserCredentials>>> GetAsync([FromQuery] string id)
    {
        try
        {
            var records = await userCredentials.GetAsync(id);
            return Ok(records);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}
