using Microsoft.EntityFrameworkCore;
using Voting.Domain.ValueObjects;

namespace Voting.Repository.Repository
{
    public class VotesRepository
    {
        private readonly VotingContext _context;

        public VotesRepository(VotingContext context) 
        {
            _context = context;
        }
        public async Task<Vote> CreateAsync(Vote vote)
        {
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return vote;
        }

        public async Task<Votinge> GetByIdAsync(int id)
        {
            return await _context.Votings
                .Include(v => v.Options)
                .ThenInclude(o => o.Votes)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
