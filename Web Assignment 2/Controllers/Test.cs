using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PaintballProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PaintballDbContext _dbContext;

        public PlayersController(PaintballDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/players
        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            var players = _dbContext.Players.ToList();

            return Ok(players);
        }

        // GET api/players/5
        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            var player = _dbContext.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        public PaintballDbContext Get_dbContext()
        {
            return _dbContext;
        }

        // POST api/players
        [HttpPost]
        public ActionResult<Player> Post([FromBody] Player player, PaintballDbContext _dbContext)
        {
            object value = _dbContext.Players.Add(player);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = player.Id }, player);
        }

        // PUT api/players/5
        [HttpPut("{id}")]
        public ActionResult<Player> Put(int id, [FromBody] Player player)
        {
            var existingPlayer = _dbContext.Players.FirstOrDefault(p => p.Id == id);

            if (existingPlayer == null)
            {
                return NotFound();
            }

            existingPlayer.Name = player.Name;
            existingPlayer.Age = player.Age;

            _dbContext.SaveChanges();

            return Ok(existingPlayer);
        }

        // DELETE api/players/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var playerToRemove = _dbContext.Players.FirstOrDefault(p => p.Id == id);

            if (playerToRemove == null)
            {
                return NotFound();
            }

            _dbContext.Players.Remove(playerToRemove);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
