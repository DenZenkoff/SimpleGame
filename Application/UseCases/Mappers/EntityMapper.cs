using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Models;
using Application.UseCases.CQRS.Commands.Action.CreateAction;
using Application.UseCases.CQRS.Commands.Action.UpdateAction;
using Application.UseCases.CQRS.Commands.Character.CreateCharacter;
using Application.UseCases.CQRS.Commands.Character.UpdateCharacter;
using AutoMapper;
using Domain.Entities;

namespace Application.UseCases.Mappers;

public class EntityMapper : Profile
{
    // Request -> Model -> Command -> Entity -> Model -> Response
    public EntityMapper()
    {
        #region Action
        
        // Request -> Model
        CreateMap<ActionCreateRequestDto, ActionModel>();
        CreateMap<ActionUpdateRequestDto, ActionModel>();
        
        // Model -> Command
        CreateMap<ActionModel, CreateActionCommand>();
        CreateMap<ActionModel, UpdateActionCommand>();
        
        // Command -> Entity
        CreateMap<CreateActionCommand, ActionEntity>();
        CreateMap<UpdateActionCommand, ActionEntity>();
        
        // Entity -> Model
        CreateMap<ActionEntity, ActionModel>();
        
        // Model -> Response
        CreateMap<ActionModel, GetActionResponseDto>();
        
        #endregion Action

        #region Character

        // Request -> Model
        CreateMap<CharacterCreateRequestDto, CharacterModel>();
        CreateMap<CharacterUpdateRequestDto, CharacterModel>();
        
        // Model -> Command
        CreateMap<CharacterModel, CreateCharacterCommand>();
        CreateMap<CharacterModel, UpdateCharacterCommand>();
        
        // Command -> Entity
        CreateMap<CreateCharacterCommand, CharacterEntity>();
        CreateMap<UpdateCharacterCommand, CharacterEntity>();
        
        // Entity -> Model
        CreateMap<CharacterEntity, CharacterModel>();
        
        // Model -> Response
        CreateMap<CharacterModel, GetCharacterResponseDto>();

        #endregion Character

        #region Stats

        // Request -> Model
        CreateMap<StatsUpdateRequestDto, StatsModel>();
        
        // Model -> Command
        CreateMap<StatsModel, UpdateStatsCommand>();
        
        // Command -> Entity
        CreateMap<UpdateStatsCommand, StatsEntity>();

        // Entity -> Model
        CreateMap<StatsEntity, StatsModel>();
        
        // Model -> Response
        CreateMap<StatsModel, GetStatsResponseDto>();

        #endregion Stats
    }
}