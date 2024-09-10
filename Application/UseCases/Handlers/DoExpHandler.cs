using Application.Enums;
using Application.Models;
using static System.String;

namespace Application.UseCases.Handlers;

public static class DoExpHandler 
{
    public static Tuple<DoActionState, string> Do(CharacterModel characterModel, int expAmount)
    {
        return DoExp(characterModel, expAmount);
    }

    private static Tuple<DoActionState, string> DoExp(CharacterModel characterModel, int exp)
    {
        var currentExp = characterModel.CurrentExp;
        var levelExp = characterModel.LevelExp;
        var expAfterAction = currentExp + exp;
        var isLevelUp = expAfterAction >= levelExp;

        if (isLevelUp)
        {
            var residualExp = expAfterAction == levelExp ? 0 : expAfterAction - levelExp;
            LevelUp(characterModel, residualExp);
            
            return Tuple.Create(DoActionState.Success, Empty);
        }

        characterModel.CurrentExp = expAfterAction;
        
        return Tuple.Create(DoActionState.Success, Empty);
    }

    private static CharacterModel LevelUp(CharacterModel characterModel, int residualExp)
    {
        var cLevel = ++characterModel.Level;
        var cClass = characterModel.Class;
        var baseHp = cClass switch
        {
            Class.Warrior => 15,
            Class.Rogue => 10,
            _ => 5
        };
        
        characterModel.Level = cLevel;
        characterModel.LevelExp = cLevel * 10;
        characterModel.CurrentExp = residualExp;
        characterModel.Stats.MaxHp = (ushort)(cLevel + baseHp);;
        characterModel.Stats.CurrentHp = characterModel.Stats.MaxHp;
        characterModel.Stats.CurrentEnergy = characterModel.Stats.MaxEnergy;

        characterModel.Stats.Strength++;
        characterModel.Stats.Speed++;
        characterModel.Stats.Intelligence++;
        
        return characterModel;
    }
}