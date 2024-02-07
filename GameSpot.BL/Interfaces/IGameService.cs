using GameSpot.Models;

namespace GameSpot.BL.Interfaces
{
    public interface IGameService
    {
        Game GetById(int id);
        IEnumerable<Game> GetAll();
        void Add(Game game);
        void Update(Game game);
        void Delete(int id);
    }
}
