using GameSpot.BL.Interfaces;
using GameSpot.DL.Interfaces;
using GameSpot.Models;

namespace GameSpot.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public void Add(Game game)
        {
            if (game == null)
            { 
                throw new ArgumentNullException(nameof(game)); 
            }

            _gameRepository.Add(game);
        }

        public void Delete(int id)
        {
            _gameRepository.Delete(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _gameRepository.GetAll();
        }

        public Game GetById(int id)
        {
            return _gameRepository.GetById(id);
        }

        public void Update(Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game));

            _gameRepository.Update(game);
        }
    }
}
