namespace Voting.Service.Services
using Voting.Domain.ValueObjects;
{
 
    public class VotingService : IVotingService
    {
        private readonly IVotingRepository _votingRepository;
        public VotingService(IVotingRepository votingRepository)
        {
            _votingRepository = votingRepository;
        }
        public async Task<Votinge> CreateAsync(Votinge voting)
        {
            return await _votingRepository.AddAsync(voting);
        }
        public async Task<Votinge> GetByIdAsync(int id)
        {
            return await _votingRepository.GetByIdAsync(id);
        }
    }
}
