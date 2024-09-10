using Application.UseCases.Services.Game;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly DoActionService _doActionService;

    public GameController(DoActionService doActionService)
    {
        _doActionService = doActionService ?? throw new ArgumentNullException(nameof(doActionService));
    }
    
    [HttpPost("DoAction")]
    public async Task<IActionResult> DoAction([FromQuery] int characterId, [FromQuery] int actionId)
    {
        var doAction = await _doActionService.DoAction(characterId, actionId);   
        return Ok(doAction);
    }
}