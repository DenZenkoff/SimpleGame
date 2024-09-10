using Application.Models;
using Application.UseCases.CQRS.Commands.Character.CreateCharacter;
using Application.UseCases.CQRS.Commands.Character.DeleteCharacter;
using Application.UseCases.CQRS.Commands.Character.UpdateCharacter;
using Application.UseCases.CQRS.Queries.Character.GetCharacterById;
using Application.UseCases.CQRS.Queries.Character.GetCharacters;
using Application.UseCases.CQRS.Queries.Character.GetDeadCharacters;
using Application.UseCases.Services.Db.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Services.Db;

public class CharacterService : ICharacterService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CharacterService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<bool> AddAsync(CharacterModel characterDto)
    {
        var command = _mapper.Map<CreateCharacterCommand>(characterDto);
        var createdId = await _mediator.Send(command);
        return createdId;
    }
    
    public async Task<bool> UpdateAsync(CharacterModel characterDto)
    {
        var command = _mapper.Map<UpdateCharacterCommand>(characterDto);
        var isUpdated = await _mediator.Send(command);
        return isUpdated;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var isDeleted = await _mediator.Send(new DeleteCharacterCommand { Id = id });
        return isDeleted;
    }
    
    public async Task<CharacterModel> GetByIdAsync(int id)
    {
        var result = await _mediator.Send(new GetCharacterByIdQuery { Id = id });
        return _mapper.Map<CharacterModel>(result);
    }
    
    public async Task<IList<CharacterModel>> GetAllAsync()
    {
        var result = await _mediator.Send(new GetCharactersQuery());
        return _mapper.Map<IList<CharacterModel>>(result.ToList());
    }

    public async Task<IList<CharacterModel>> GetAllTheDeadAsync()
    {
        var result = await _mediator.Send(new GetDeadCharactersQuery());
        return _mapper.Map<IList<CharacterModel>>(result.ToList());
    }
}