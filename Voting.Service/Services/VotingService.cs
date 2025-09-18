using Voting.Domain.ValueObjects;
using Voting.Repository.Interfaces;
using Voting.Service.Interfaces;

namespace Voting.Service.Services
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
            return await _votingRepository.CreateAsync(voting);
        }
        public async Task<Votinge> GetByIdAsync(int id)
        {
            return await _votingRepository.GetByIdAsync(id);
        }
    }
}
