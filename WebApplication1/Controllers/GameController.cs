using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace WebApplication1.Controllers
{
	
	/// <summary>
	/// Controller to manage game data
	/// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        /// <summary>
        /// Read-only, pre-populated list of sample Game instances used for in-memory data.
        /// </summary>
        /// <remarks>Initialized at type construction with three Game objects. The field is readonly (the
        /// reference cannot be reassigned) but the List's contents can be modified. Intended for private, in-memory use
        /// only.</remarks>
        private static readonly List<Game> _listGames = new()
        {
            new Game
            {
                Id = 1,
                Nama = "Valorant",
                Developer = "Riot Games",
                TahunRilis = 2020,
                Genre = "FPS",
                Rating = 8.5,
                Platform = new List<string> { "PC" },
                Mode = new List<string>  { "Multiplayer" },
                IsOnline = true,
                Harga = 0
            },
            new Game
            {
                Id = 2,
                Nama = "GTA V",
                Developer = "Rockstar Games",
                TahunRilis = 2013,
                Genre = "Open World",
                Rating = 9.5,
                Platform =new List<string>  { "PC", "PS4", "PS5", "Xbox"},
                Mode = new List<string> {"Singleplayer", "Multiplayer"},
                IsOnline = true,
                Harga = 300000
            },
            new Game
            {
                Id = 3,
                Nama = "The Witcher 3",
                Developer = "CD Projekt Red",
                TahunRilis = 2015,
                Genre = "RPG",
                Rating = 9.7,
                Platform = new List<string>  { "PC", "PS4", "PS5", "Xbox", "Switch"},
                Mode = new List<string>  {"Singleplayer"},
                IsOnline = false,
                Harga = 250000
            }
        };

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Retrieves all games.
        /// </summary>
        /// <returns> list of all games. </returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_listGames);
        }

        /// <summary>
        /// Retrieves a film by its ID.
        /// </summary>
        /// <param name="Id">The ID of the game to retrieve.</param>
        /// <returns>The matching game, or 404 if not found</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var foundFilm = _listGames.FirstOrDefault(x => x.Id == Id);
            return foundFilm is null ? NotFound() : Ok(foundFilm);
        }

        /// <summary>
        /// Creates a new game
        /// </summary>
        /// <param name="game">the game data to create</param>
        /// <returns>the created game with its new Id</returns>
        [HttpPost]
        public IActionResult Create([FromBody] Game game)
        {
            game.Id = _listGames.Count + 1;
            _listGames.Add(game);
            return CreatedAtAction(nameof(GetById), new { Id = game.Id }, game);
        }

        /// <summary>
        /// update existing game by Id.
        /// </summary>
        /// <param name="Id">the Id of the game to update</param>
        /// <param name="updatedGame">the updated game data</param>
        /// <returns>The updating game, or 404 if not found</returns>
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody] Game updatedGame)
        {
            var existingGame = _listGames.FirstOrDefault(x => x.Id == Id);
            if (existingGame is null)
            {
                return NotFound();
            }

            existingGame.Rating = updatedGame.Rating;
            existingGame.Harga = updatedGame.Harga;
            existingGame.Platform = updatedGame.Platform;

            return Ok(existingGame);
        }

        /// <summary>
        /// Deletes a game by its ID.
        /// </summary>
        /// <param name="Id">The ID of the game to delete.</param>
        /// <returns>204 no content, or 404 if not found</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var gameToDelete = _listGames.FirstOrDefault(x => x.Id == Id);
            if (gameToDelete is null)
            {
                return NotFound();
            }

            _listGames.Remove(gameToDelete);
            return NoContent();
        }
    }
}
