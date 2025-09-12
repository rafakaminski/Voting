namespace Voting.Repository.Interfaces
{
    public interface IVotingRepository
    {
        Task<Domain.ValueObjects.Votinge> GetByIdAsync(int id);
        Task<Domain.ValueObjects.Votinge> CreateAsync(Domain.ValueObjects.Votinge voting);
    }
}
