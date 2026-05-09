using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        private static readonly string[] listGameNames = new[]
        {
            "Valorant", "GTA V", "The Witcher 3"
        };

        private static readonly string[] listGameDev = new[]
        {
            "Riot Games", "Rockstar Games", "CD Project Red"
        };

        private static readonly int[] listGameTahun = new[]
        {
            2020, 2013, 2015
        };

        private static readonly string[] listGameGenre = new[]
        {
            "FPS", "Open World", "RPG"
        };

        private static readonly double[] listGameRating = new[]
        {
            8.5, 9.5, 9.7
        };

        private static readonly List<List<string>> listGamePlatform = new List<List<string>>
        {
            new List<string> { "PC" },
            new List<string> { "PC", "PS5", "PS4", "XBOX" },
            new List<string> { "PC", "PS5", "PS4", "XBOX" }
        };

        private static List<List<string>> listGameMode = new List<List<string>>
        {
            new List<string> { "Multiplayer" },
            new List<string> { "Multiplayer", "Singleplayer" },
            new List<string> { "Multiplayer", "Singleplayer" }
        };

        private static readonly List<bool> IsOnline = new List<bool>{true, true, false};

        private static readonly int[] listGameHarga = new[]
        {
            0, 300000, 250000
        };

        private static readonly List<Game> listGames = new()
        {
            new Game(0, listGameNames[0], listGameDev[0], listGameTahun[0],  listGameGenre[0], listGameRating[0], listGamePlatform[0], listGameMode[0], IsOnline[0], listGameHarga[0]),
            new Game(1, listGameNames[1], listGameDev[1], listGameTahun[1],  listGameGenre[1], listGameRating[1], listGamePlatform[1], listGameMode[1], IsOnline[1], listGameHarga[1]),
            new Game(2, listGameNames[2], listGameDev[2], listGameTahun[2],  listGameGenre[2], listGameRating[2], listGamePlatform[2], listGameMode[2], IsOnline[2], listGameHarga[2])
        };

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listGames);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var film = listGames.FirstOrDefault(x => x.id == id);
            return film is null ? NotFound() : Ok(film);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Game game)
        {
            game.id = listGames.Count + 1;
            listGames.Add(game);
            return CreatedAtAction(nameof(GetById), new { id = game.id }, game);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Game updatedGame)
        {
            var game = listGames.FirstOrDefault(x => x.id == id);
            if (game is null)
            {
                return NotFound();
            }
            
            game.Rating = updatedGame.Rating;
            game.Harga = updatedGame.Harga;
            game.Platform = updatedGame.Platform;

            return Ok(game);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = listGames.FirstOrDefault(x => x.id == id);
            if (game is null)
            {
                return NotFound();
            }

            listGames.Remove(game);
            return NoContent();
        }
    }
}
