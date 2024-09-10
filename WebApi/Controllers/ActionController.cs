using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Models;
using Application.UseCases.Services.Db.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ActionController : ControllerBase
{
    private readonly IActionService _actionService;
    private readonly IMapper _mapper;

    public ActionController(IActionService actionService, IMapper mapper)
    {
        _actionService = actionService?? throw new ArgumentNullException(nameof(actionService));
        _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] ActionCreateRequestDto request)
    {
        var model = _mapper.Map<ActionModel>(request);
        var isCreated = await _actionService.AddAsync(model);
        return isCreated ? Ok("Record was added successfully") : BadRequest("Oh no, something bad happened");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] ActionUpdateRequestDto request)
    {
        var model = _mapper.Map<ActionModel>(request);
        var isUpdated = await _actionService.UpdateAsync(model);
        return isUpdated ? Ok("Record was updated successfully") : BadRequest("Oh no, something bad happened");
    }
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        var isDeleted = await _actionService.DeleteAsync(id);
        return isDeleted ? Ok("Record was removed successfully") : BadRequest("Oh no, something bad happened");
    }
    
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
    {
        var action = await _actionService.GetByIdAsync(id);
        return Ok(_mapper.Map<GetActionResponseDto>(action));
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var actions = await _actionService.GetAllAsync();
        return Ok(_mapper.Map<IList<GetActionResponseDto>>(actions));
    }
}