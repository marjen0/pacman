using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PacmanContext _context;
        public int Qty { get; set; } = 0;

        public PlayerController(PacmanContext context)
        {
            _context = context;

            if (_context.Players.Count() == 0)
            {
                // Create a new Player if collection is empty,
                // which means you can't delete all Players.
                for (int i = 0; i < 0; i++)
                {
                    Qty++;
                    Player p = new Player { Name = "Player-" + Qty, Lives=3,Score=0,xCoordinate=0,yCoordinate=0 };
                    _context.Players.Add(p);
                }

                _context.SaveChanges();
            }
        }
        // GET api/player
        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetAll()
        {
            return Ok(_context.Players.ToList());
        }

        // GET api/player/5
        [HttpGet("{id}", Name = "GetPlayer")]
        public async Task<ActionResult<Player>> GetById(int id)
        {
            Player p = await _context.Players.FindAsync(id);
            if (p == null)
            {
                return NotFound(new{ message = "player not found"});
            }
            return Ok(p);
        }

        // POST api/player
        [HttpPost]
        //public string Create(Player player)
        public async Task<ActionResult<Player>> Create([FromBody] Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetPlayer", new { id = player.ID }, player);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Player>> Update(int id, [FromBody] Player player)
        {
            var dbPlayer = _context.Players.Find(id);
            if (dbPlayer == null)
            {
                return NotFound(new { message = "player not found"});
            }

            dbPlayer.Name = player.Name;
            dbPlayer.Score = player.Score;
            dbPlayer.xCoordinate = player.xCoordinate;
            dbPlayer.yCoordinate = player.yCoordinate;
            dbPlayer.Lives = player.Lives;
           
            _context.Players.Update(dbPlayer);
            await _context.SaveChangesAsync();

            return Ok(dbPlayer);
        }

        [HttpPatch]
        public IActionResult PartialUpdate([FromBody] Coordinates request)
        {
            var player = _context.Players.Find(request.PlayerID);
            if (player == null)
            {
                return NotFound();
            }
            else
            {
                player.xCoordinate = request.xCoordinate;
                player.yCoordinate = request.yCoordinate;

                _context.Players.Update(player);
                _context.SaveChanges();
            }
            return Ok(player);
        }

        // DELETE api/player/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var player = _context.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
