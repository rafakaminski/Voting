namespace Voting.Domain.ValueObjects
{
    public class Option
    {
        public int Id { get; set; }
        public int VoteId { get; set; }
        public string Texto { get; set; } = null!;
        public Vote Vote { get; set; } = null!;
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}