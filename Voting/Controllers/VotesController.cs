using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Voting.Domain.ValueObjects;
using Voting.Repository;

namespace Voting.Controllers
{
    public class VotesController : ControllerBase
    {
        private readonly VotingContext _context;

        public VotesController(VotingContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vote vote)
        {
            // Verifica se usuário já votou nessa Option
            bool alreadyVoted = await _context.Votes
                .AnyAsync(v => v.UserId == vote.UserId && v.OptionId == vote.OptionId);

            if (alreadyVoted)
                return BadRequest("Usuário já votou nessa opção.");

            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVotesById), new { id = vote.Id }, vote);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVotesById(int id)
        {
            var vote = await _context.Votes
                .Include(v => v.User)
                .Include(v => v.Option)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (vote == null) return NotFound();
            return Ok(vote);
        }
    }
}
