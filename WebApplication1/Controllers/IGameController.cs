using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public interface IGameController
    {
        public IActionResult GetAll();
        public IActionResult GetById(int Id);
        public IActionResult Create([FromBody] Game game);
        public IActionResult Update(int Id, [FromBody] Game updatedGame);
        public IActionResult Delete(int Id);
    }
}
