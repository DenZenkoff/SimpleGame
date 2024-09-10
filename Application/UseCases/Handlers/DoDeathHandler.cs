using Application.Enums;
using Application.Models;

namespace Application.UseCases.Handlers;

public static class DoDeathHandler
{
    public static CharacterModel Do(CharacterModel characterModel)
    {
        return DoDeath(characterModel);
    }

    private static CharacterModel DoDeath(CharacterModel characterModel)
    {
        characterModel.Race = Race.Undead;
        characterModel.IsAlive = false;

        characterModel.Level = 0;
        characterModel.CurrentExp = 0;
        characterModel.LevelExp = 0;

        characterModel.Stats = new StatsModel { CharacterId = characterModel.Id };

        return characterModel;
    }
}