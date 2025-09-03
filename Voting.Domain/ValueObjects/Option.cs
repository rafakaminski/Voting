namespace Voting.Domain.ValueObjects
{
    public class Option
    {
        public int Id { get; set; }
        public string Texto { get; set; } = null!;
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}