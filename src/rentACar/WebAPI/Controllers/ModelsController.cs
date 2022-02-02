using Application.Features.Models.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateModelCommand createBrandCommand)
    {
        var result = await Mediator.Send(createBrandCommand);
        return Created("", result);
    }
}