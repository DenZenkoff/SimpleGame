using Application.Enums;
using Application.Models;
using static System.String;

namespace Application.UseCases.Handlers;

public static class DoHealthHandler
{
    public static Tuple<DoActionState, string> Do(CharacterModel characterModel, ushort healthAmount, ActionType actionType)
    {
        return actionType is ActionType.SmallRest or ActionType.BigRest
            ? DoHeal(characterModel, healthAmount)
            : DoDamage(characterModel, healthAmount);
    }
    
    private static Tuple<DoActionState, string> DoHeal(CharacterModel characterModel, ushort heal)
    {
        var currentHp = characterModel.Stats.CurrentHp;
        var maxHp = characterModel.Stats.MaxHp;
        var hpAfterHeal = currentHp + heal;
        var isOverHealed = hpAfterHeal > maxHp;

        characterModel.Stats.CurrentHp = isOverHealed ? maxHp : (ushort)hpAfterHeal;
        
        return Tuple.Create(DoActionState.Success, Empty);
    }

    private static Tuple<DoActionState, string> DoDamage(CharacterModel characterModel, ushort damage)
    {
        var currentHp = characterModel.Stats.CurrentHp;
        var hpAfterDamage = currentHp - damage;
        var isAlive = hpAfterDamage > 0;

        if (!isAlive)
        {
            characterModel.IsAlive = false;
            characterModel.Stats.CurrentHp = 0;

            const string message = "Character died from wounds. Check health next time.";
            return Tuple.Create(DoActionState.Failed, message);
        }
        
        characterModel.Stats.CurrentHp = (ushort)hpAfterDamage;
        
        return Tuple.Create(DoActionState.Success, Empty);
    }
}