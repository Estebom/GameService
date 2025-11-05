using GameService.Data.Models;

namespace GameService.Data.Repositories
{
    public interface IGameRepository
    {
        Task Add(GameDTO gameDTO);
        Task<bool> Update(Guid id, GameDTO gameDTO);
        Task<List<Game>> Get();
        Task<Game> Get(Guid id);
        Task<bool> Delete(Guid id);
    }
}
