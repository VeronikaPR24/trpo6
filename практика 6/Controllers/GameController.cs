using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using практика_6.Models;

namespace практика_6.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly WebApiDatabaseContext _context;

        public GameController(WebApiDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Game>> GetAllGame()
        {
            return await _context.Games.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame([FromRoute] int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound("Игра не найдена");
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AllUpdateGame([FromRoute] int id, [FromBody] Game game)
        {
            if (id != game.Id)
            {
                return BadRequest("Не изменен");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Games.Any(e => e.Id == id))
                {
                    return NotFound("Игра не найдена");
                }
            }
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateGame([FromRoute] int id, [FromBody] Game gameUpdates)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound("Игра не найдена");
            }

            if (gameUpdates.Title != null) 
                game.Title = gameUpdates.Title;
            if (gameUpdates.Genre != null) 
                game.Genre = gameUpdates.Genre;
            if (gameUpdates.Price != 0) 
                game.Price = gameUpdates.Price;
            if (gameUpdates.AgeRating != 0) 
                game.AgeRating = gameUpdates.AgeRating;
            if (gameUpdates.IsAvailable) 
                game.IsAvailable = gameUpdates.IsAvailable;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame([FromRoute] int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound("Игра не найдена");
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }   
    }
}
