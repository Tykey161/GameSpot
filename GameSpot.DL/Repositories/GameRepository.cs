using GameSpot.DL.Interfaces;
using GameSpot.DL.MemoryDb;
using GameSpot.Models;

namespace GameSpot.DL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly List<Game> _games;

        public GameRepository()
        {
            _games = InMemoryDb.GameData;
        }

        public void Add(Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game));

            _games.Add(game);
        }

        public void Delete(int id)
        {
            var gameToRemove = _games.FirstOrDefault(g => g.Id == id);
            if (gameToRemove != null)
                _games.Remove(gameToRemove);
        }

        public IEnumerable<Game> GetAll()
        {
            return _games.ToList();
        }

        public Game GetById(int id)
        {
            return _games.FirstOrDefault(g => g.Id == id);
        }

        public void Update(Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game));

            var existingGame = _games.FirstOrDefault(g => g.Id == game.Id);
            if (existingGame != null)
            {
                existingGame.Title = game.Title;
                existingGame.Genre = game.Genre;
                existingGame.Description = game.Description;
                existingGame.Price = game.Price;
                existingGame.PublisherId = game.PublisherId;
                existingGame.Publisher = game.Publisher;
            }
        }
    }
}
