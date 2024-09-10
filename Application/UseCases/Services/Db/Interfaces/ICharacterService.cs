using Application.Models;

namespace Application.UseCases.Services.Db.Interfaces;

public interface ICharacterService : IService<CharacterModel>
{
    Task<IList<CharacterModel>> GetAllTheDeadAsync();
}