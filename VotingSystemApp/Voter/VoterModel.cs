namespace VotingSystemApp
{
    public class Voter
    {
        public string VoterId { get; set; }
        public string Name { get; set; }
        public bool HasVoted { get; set; }

        public Voter(string voterId, string name, bool hasVoted = false)
        {
            VoterId = voterId;
            Name = name;
            HasVoted = hasVoted;
        }
    }
}