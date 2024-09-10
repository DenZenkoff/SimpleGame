using Application.Dtos;
using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Models;
using Application.UseCases.Services.Db.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    private readonly IMapper _mapper;

    public CharacterController(ICharacterService characterService, IMapper mapper)
    {
        _characterService = characterService ?? throw new ArgumentNullException(nameof(characterService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> AddAsync([FromBody] CharacterCreateRequestDto request)
    {
        var model = _mapper.Map<CharacterModel>(request);
        var isCreated = await _characterService.AddAsync(model);
        return isCreated ? Ok("Record was added") : BadRequest("Oh no, something bad happened");
    }
    
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAsync([FromBody] CharacterUpdateRequestDto request)
    {
        var model = _mapper.Map<CharacterModel>(request);
        var isUpdated = await _characterService.UpdateAsync(model);
        return isUpdated ? Ok("Record was updated successfully") : BadRequest("Oh no, something bad happened");
    }
    
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        var isDeleted = await _characterService.DeleteAsync(id);
        return isDeleted ? Ok("Record was removed successfully") : BadRequest("Oh no, something bad happened");
    }
    
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
    {
        var character = await _characterService.GetByIdAsync(id);
        return Ok(_mapper.Map<GetCharacterResponseDto>(character));
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetCharactersAsync()
    {
        var characters = await _characterService.GetAllAsync();
        return Ok(_mapper.Map<IList<GetCharacterResponseDto>>(characters));
    }
    
    [HttpGet("GetAllTheDead")]
    public async Task<IActionResult> GetDeadCharactersAsync()
    {
        var characters = await _characterService.GetAllTheDeadAsync();
        return Ok(_mapper.Map<IList<GetCharacterResponseDto>>(characters));
    }
}