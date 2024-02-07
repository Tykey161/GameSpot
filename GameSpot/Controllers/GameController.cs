using Microsoft.AspNetCore.Mvc;
using GameSpot.BL.Interfaces;
using GameSpot.Models;

namespace GameSpot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
        }

        [HttpGet]
        public IEnumerable<Game> GetAllGames()
        {
            return _gameService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGame(int id)
        {
            var game = _gameService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            return game;
        }

        [HttpPost]
        public IActionResult AddGame(Game game)
        {
            if (game == null)
            {
                return BadRequest();
            }

            _gameService.Add(game);

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            try
            {
                _gameService.Update(game);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = _gameService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            _gameService.Delete(id);

            return NoContent();
        }
    }
}
