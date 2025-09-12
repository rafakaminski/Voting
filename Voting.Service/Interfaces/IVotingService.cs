namespace Voting.Service.Interfaces
using Voting.Domain.ValueObjects;
{
    public interface IVotingService
{
        Task<Votinge> GetByIdAsync(int id);
        Task<Votinge> CreateAsync(Votinge voting);
    }
}
