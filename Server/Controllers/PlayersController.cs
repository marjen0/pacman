using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PacmanContext _pacmanContext;

        public PlayersController(PacmanContext context)
        {
            _pacmanContext = context;
        }
        // GET: api/players
        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            List<Player> players = _pacmanContext.Players.ToList();
            if (players == null || players.Count == 0)
            {
                return NotFound();
            }
            return Ok(players);
        }

        // GET api/players/5
        [HttpGet("{id}")]
        public ActionResult<Player> Get(string id)
        {
            Player p = _pacmanContext.Players.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(p);
            }

        }

        // POST api/players>
        [HttpPost]
        public ActionResult Post([FromBody] Player p)
        {
            _pacmanContext.Players.Add(p);
            return Ok();
        }

        // PUT api/players>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/players>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
