using GameService.Data.Models;
using GameService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGame() 
        {
            List<Game> games = await gameRepository.Get();

            if (games.Count == 0) 
            {
                return NotFound("No games available");
            }
            return Ok(games);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetGame(Guid id) 
        {
            Game game = await gameRepository.Get(id);

            if (game is default(Game)) 
            {
                return NotFound("No game found");
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(GameDTO gameDTO) 
        {
            await gameRepository.Add(gameDTO);
            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateGame(Guid id, GameDTO gameDTO) 
        {
            bool success = await gameRepository.Update(id, gameDTO);

            if (success) 
            {
                return Ok();
            }

            return NotFound("There is no game with the ID you provided.");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteGame(Guid id) 
        {
            bool success = await gameRepository.Delete(id);

            if (success) 
            {
                return Ok("Game deleted.");
            }

            return NotFound("Game not found.");
        }
    }
}
