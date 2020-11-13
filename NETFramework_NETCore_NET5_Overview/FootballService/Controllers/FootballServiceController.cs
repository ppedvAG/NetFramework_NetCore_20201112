using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballService.Data;
using FootballService.Models;

namespace FootballService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballServiceController : ControllerBase
    {
        private readonly FootballClubDBContext _context;

        public FootballServiceController(FootballClubDBContext context)
        {
            _context = context;
        }

        // GET: api/FootballService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FootballClub>>> GetFootballClubs()
        {
            return await _context.FootballClubs.ToListAsync();
        }

        // GET: api/FootballService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FootballClub>> GetFootballClub(int id)
        {
            var footballClub = await _context.FootballClubs.FindAsync(id);

            if (footballClub == null)
            {
                return NotFound();
            }

            return footballClub;
        }

        // PUT: api/FootballService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")] //Update eines Datensatzes
        public async Task<IActionResult> PutFootballClub(int id, FootballClub footballClub)
        {
            if (id != footballClub.Id)
            {
                return BadRequest();
            }

            _context.Entry(footballClub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootballClubExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FootballService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost] //Insert
        public async Task<ActionResult<FootballClub>> PostFootballClub(FootballClub footballClub)
        {
            _context.FootballClubs.Add(footballClub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFootballClub", new { id = footballClub.Id }, footballClub);
        }

        // DELETE: api/FootballService/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootballClub(int id)
        {
            var footballClub = await _context.FootballClubs.FindAsync(id);
            if (footballClub == null)
            {
                return NotFound();
            }

            _context.FootballClubs.Remove(footballClub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FootballClubExists(int id)
        {
            return _context.FootballClubs.Any(e => e.Id == id);
        }
    }
}
