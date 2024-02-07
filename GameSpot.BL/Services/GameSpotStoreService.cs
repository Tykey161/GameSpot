using GameSpot.BL.Interfaces;
using GameSpot.Models.Request;
using GameSpot.Models.Response;

namespace GameSpot.BL.Services
{
    public class GameSpotStoreService : IGameSpotStoreService
    {
        private readonly IGameService _gameService;

        private readonly IPublisherService _publisherService;

        public GameSpotStoreService(IGameService gameService, IPublisherService publisherService)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
            _publisherService = publisherService ?? throw new ArgumentNullException(nameof(publisherService));
        }

        public void AddGameWithPublisher(AddGameWithPublisherRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Game == null)
                throw new ArgumentNullException(nameof(request.Game));

            if (request.Publisher == null)
                throw new ArgumentNullException(nameof(request.Publisher));

            _publisherService.Add(request.Publisher);

            request.Game.PublisherId = request.Publisher.Id;

            _gameService.Add(request.Game);
        }

        public GetGamesPublishedByResponse GetGamesPublishedBy(GetGamesPublishedByRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrEmpty(request.PublisherName))
                throw new ArgumentNullException(nameof(request.PublisherName));

            var publisher = _publisherService.GetAll().FirstOrDefault(p => p.Name == request.PublisherName);
            if (publisher == null)
                throw new ArgumentException("Publisher not found", nameof(request.PublisherName));

            var games = _gameService.GetAll().Where(g => g.PublisherId == publisher.Id).ToList();

            return new GetGamesPublishedByResponse { Games = games };
        }
    }
}
