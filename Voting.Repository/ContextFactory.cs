
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Voting.Repository
{
    public class ContextFactory : IDesignTimeDbContextFactory<VotingContext>
    {
        public VotingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VotingContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=votingdb;Username=postgres;Password=senhasecreta");

            return new VotingContext(optionsBuilder.Options);
        }
    }
}
