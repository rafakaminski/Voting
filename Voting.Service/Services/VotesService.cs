using Microsoft.EntityFrameworkCore;
using Voting.Domain.ValueObjects;
using Voting.Repository;
using Voting.Repository.Repository;

namespace Voting.Service.Services
{
    public class VotesService
    {
        private readonly VotesRepository _votesRepository;
        public VotesService(VotesRepository votesRepository)
        {
            _votesRepository = votesRepository;
        }

        public async Task<Vote> CreateAsync(Vote vote)
        {
            return await _votesRepository.CreateAsync(vote);
        }
        public async Task<Vote> GetByIdAsync(int id)
        {
            return await _votesRepository.GetByIdAsync(id);
        }
    }
}