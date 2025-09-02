﻿namespace Voting.Domain.ValueObjects
{
    public class Votinge
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime InitialDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public ICollection<Option> Options { get; set; } = new List<Option>();
    }
}
