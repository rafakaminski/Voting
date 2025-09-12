using Microsoft.EntityFrameworkCore;
using Voting.Domain.ValueObjects;
using Voting.Repository.Interfaces;

namespace Voting.Repository.Repository
{
    public class VotingRepository : IVotingRepository
    {
        private readonly VotingContext _context;

        public VotingRepository(VotingContext _context) 
        {
            _context = _context;
        }

        public async Task<Votinge> GetByIdAsync(int id)
        {
            return await _context.Votings
                .Include(v => v.Options)
                .ThenInclude(o => o.Votes)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Votinge> CreateAsync(Votinge voting)
        {
            _context.Votings.Add(voting);
            await _context.SaveChangesAsync();
            return voting;
        }
    }
}
