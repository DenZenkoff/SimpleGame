using Application.Enums;
using Application.Models;
using static System.String;

namespace Application.UseCases.Handlers;

public static class DoEnergyHandler
{
    public static Tuple<DoActionState, string> Do(CharacterModel characterModel, ushort energyAmount, ActionType actionType)
    {
        return actionType is ActionType.SmallRest or ActionType.BigRest
            ? DoRest(characterModel, energyAmount)
            : DoActivity(characterModel, energyAmount);
    }

    private static Tuple<DoActionState, string> DoRest(CharacterModel characterModel, ushort recharged)
    {
        var currentEnergy = characterModel.Stats.CurrentEnergy;
        var maxEnergy = characterModel.Stats.MaxEnergy;
        var energyAfterRest = currentEnergy + recharged;
        var isOverRested = energyAfterRest > maxEnergy;

        characterModel.Stats.CurrentEnergy = isOverRested ? maxEnergy : (ushort)energyAfterRest;
        
        return Tuple.Create(DoActionState.Success, Empty);
    }
    
    private static Tuple<DoActionState, string> DoActivity(CharacterModel characterModel, ushort depleted)
    {
        var currentEnergy = characterModel.Stats.CurrentEnergy;
        var energyAfterActivity = currentEnergy - depleted;
        var isOverworked = energyAfterActivity < 0;

        if (isOverworked)
        {
            characterModel.IsAlive = false;
            characterModel.Stats.CurrentEnergy = 0;
            
            const string message = "Character overworked and died. Check stamina next time.";
            return Tuple.Create(DoActionState.Failed, message);
        }

        characterModel.Stats.CurrentEnergy = (ushort)energyAfterActivity;
        
        return Tuple.Create(DoActionState.Success, Empty);
    }
}