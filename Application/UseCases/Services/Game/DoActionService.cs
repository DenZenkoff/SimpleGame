using Application.Enums;
using Application.Models;
using Application.UseCases.Handlers;
using Application.UseCases.Services.Db.Interfaces;
using static System.String;

namespace Application.UseCases.Services.Game;

public class DoActionService
{
    private readonly IActionService _actionService;
    private readonly ICharacterService _characterService;

    public DoActionService(ICharacterService characterService, IActionService actionService)
    {
        _characterService = characterService ?? throw new ArgumentNullException(nameof(characterService));
        _actionService = actionService ?? throw new ArgumentNullException(nameof(actionService));
    }

    public async Task<string> DoAction(int characterId, int actionId)
    {
        var characterModel = await GetCharacter(characterId);
        var actionModel = await GetAction(actionId);
        
        var casino = new Random();
        var expectedDamage = (ushort)casino.Next(actionModel.MinDamage, actionModel.MaxDamage);
        var expectedEnergyCost = (ushort)casino.Next(actionModel.MinEnergyCost, actionModel.MaxEnergyCost);
        var expectedExp = casino.Next(actionModel.MinExp, actionModel.MaxExp);
        var actionType = actionModel.Type;

        var healthState = DoHealthHandler.Do(characterModel, expectedDamage, actionType);
        if (healthState.Item1 == DoActionState.Failed)
        {
            DoDeathHandler.Do(characterModel);
            await _characterService.UpdateAsync(characterModel);
            
            return healthState.Item2;
        }
        
        var energyState = DoEnergyHandler.Do(characterModel, expectedEnergyCost, actionType);
        if (energyState.Item1 == DoActionState.Failed)
        {
            DoDeathHandler.Do(characterModel);
            await _characterService.UpdateAsync(characterModel);
            
            return energyState.Item2;
        }
        
        var expState = DoExpHandler.Do(characterModel, expectedExp);

        if (healthState.Item1 is DoActionState.Success 
            && energyState.Item1 is DoActionState.Success
            && expState.Item1 is DoActionState.Success)
        {
            await _characterService.UpdateAsync(characterModel);

            return "Completed";
        }
        
        return Empty;
    }

    private async Task<CharacterModel> GetCharacter(int id)
    {
        var characterModel = await _characterService.GetByIdAsync(id);
        if (!characterModel.IsAlive)
            throw new InvalidDataException("[DoActionService]: Character is dead");

        return characterModel;
    }

    private async Task<ActionModel> GetAction(int id)
    {
        var actionModel = await _actionService.GetByIdAsync(id);
        if (actionModel == null)
            throw new InvalidDataException("[DoActionService]: Invalid [ActionId]");
        
        return actionModel;
    }
}