using GameSpot.Models;
using GameSpot.Models.Request;
using GameSpot.Models.Response;

namespace GameSpot.BL.Interfaces
{
    public interface IGameSpotStoreService
    {
        void AddGameWithPublisher(AddGameWithPublisherRequest request);

        GetGamesPublishedByResponse GetGamesPublishedBy(GetGamesPublishedByRequest request);
    }
}
