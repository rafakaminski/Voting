namespace Voting.Domain.ValueObjects
{
    public class Vote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }
        public DateTime VoteDate { get; set; } = DateTime.UtcNow;
        public User User { get; set; } = null!;
        public Option Option { get; set; } = null!;
    }
}