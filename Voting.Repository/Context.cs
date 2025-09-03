using Microsoft.EntityFrameworkCore;
using Voting.Domain.ValueObjects;

namespace Voting.Repository
{
    public class VotingContext : DbContext
    {

        public VotingContext(DbContextOptions<VotingContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Votinge> Votings { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vote>()
                .HasIndex(v => new { v.UserId, v.OptionId })
                .IsUnique();
        }
    }
}
