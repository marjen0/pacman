using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacmansController : ControllerBase
    {
        private readonly PacmanContext _pacmanContext;

        public PacmansController(PacmanContext context)
        {
            _pacmanContext = context;
        }
        // GET: api/pacmans>
        [HttpGet]
        public ActionResult<IEnumerable<Pacman>> Get()
        {
            List<Pacman> Pacmans = _pacmanContext.Pacmans.ToList();
            if (Pacmans == null || Pacmans.Count == 0)
            {
                return NotFound();
            }
            return Ok(Pacmans);
        }

        // GET api/pacmans>/5
        [HttpGet("{id}")]
        public ActionResult<Pacman> Get(string id)
        {
            Pacman p = _pacmanContext.Pacmans.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(p);
            }

        }

        // POST api/pacmans>
        [HttpPost]
        public ActionResult Post([FromBody] Pacman p)
        {
            _pacmanContext.Pacmans.Add(p);
            return Ok();
        }

        // PUT api/pacmans>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/pacmans>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
