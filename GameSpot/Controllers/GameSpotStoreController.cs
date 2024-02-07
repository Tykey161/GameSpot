using Microsoft.AspNetCore.Mvc;
using GameSpot.BL.Interfaces;
using GameSpot.Models.Request;

namespace GameSpot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameSpotStoreController : ControllerBase
    {
        private readonly IGameSpotStoreService _gameSpotStoreService;

        public GameSpotStoreController(IGameSpotStoreService gameSpotStoreService)
        {
            _gameSpotStoreService = gameSpotStoreService ?? throw new ArgumentNullException(nameof(gameSpotStoreService));
        }

        [HttpPost("AddGameWithPublisher")]
        public IActionResult AddGameWithPublisher(AddGameWithPublisherRequest request)
        {
            try
            {
                _gameSpotStoreService.AddGameWithPublisher(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding game with publisher: {ex.Message}");
            }
        }

        [HttpPost("GetGamesPublishedBy")]
        public IActionResult GetGamesPublishedBy(GetGamesPublishedByRequest request)
        {
            try
            {
                var response = _gameSpotStoreService.GetGamesPublishedBy(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving games published by a specific publisher: {ex.Message}");
            }
        }
    }
}
