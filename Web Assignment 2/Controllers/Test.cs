using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PaintballPlayersController : ControllerBase
{
    private readonly List<Player> _players;

    public PaintballPlayersController()
    {
        // Initialize the list of players with some dummy data
        _players = new List<Player>
        {
            new Player { Id = 1, Name = "Alice", Age = 25, Gender = "Female", SkillLevel = "Intermediate" },
            new Player { Id = 2, Name = "Bob", Age = 30, Gender = "Male", SkillLevel = "Expert" },
            new Player { Id = 3, Name = "Charlie", Age = 20, Gender = "Male", SkillLevel = "Beginner" }
        };
    }

    // GET: api/PaintballPlayers
    [HttpGet]
    public IEnumerable<Player> Get()
    {
        return _players;
    }

    // GET: api/PaintballPlayers/5
    [HttpGet("{id}", Name = "Get")]
    public ActionResult<Player> Get(int id)
    {
        var player = _players.FirstOrDefault(p => p.Id == id);
        if (player == null)
        {
            return NotFound();
        }
        return player;
    }

    // POST: api/PaintballPlayers
    [HttpPost]
    public void Post([FromBody] Player player)
    {
        _players.Add(player);
    }

    // PUT: api/PaintballPlayers/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Player player)
    {
        var existingPlayer = _players.FirstOrDefault(p => p.Id == id);
        if (existingPlayer == null)
        {
            return NotFound();
        }
        existingPlayer.Name = player.Name;
        existingPlayer.Age = player.Age;
        existingPlayer.Gender = player.Gender;
        existingPlayer.SkillLevel = player.SkillLevel;
        return NoContent();
    }

    // DELETE: api/PaintballPlayers/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var player = _players.FirstOrDefault(p => p.Id == id);
        if (player == null)
        {
            return NotFound();
        }
        _players.Remove(player);
        return NoContent();
    }
}
