using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Voting.Domain.ValueObjects;
using Voting.Repository;

namespace Voting.Controllers
{
    public class VotingController : ControllerBase
    {
        private readonly VotingContext _context;

        public VotingController(VotingContext context)
        {
            _context = context;
        }

        [HttpPost("voting")]
        public async Task<IActionResult> Create(Votinge voting)
        {
            _context.Votings.Add(voting);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = voting.Id }, voting);
        }

        [HttpGet("voting/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var voting = await _context.Votings
                .Include(v => v.Options)
                .ThenInclude(o => o.Votes)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (voting == null) return NotFound();
            return Ok(voting);
        }
    }
}
