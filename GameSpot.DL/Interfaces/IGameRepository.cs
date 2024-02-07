using GameSpot.Models;

namespace GameSpot.DL.Interfaces
{
    public interface IGameRepository
    {
        Game GetById(int id);
        IEnumerable<Game> GetAll();
        void Add(Game game);
        void Update(Game game);
        void Delete(int id);
    }
}
