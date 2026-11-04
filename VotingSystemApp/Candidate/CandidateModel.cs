namespace VotingSystemApp
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public int VoteCount { get; set; }

        public Candidate(int id, string name, string party, int voteCount = 0)
        {
            Id = id;
            Name = name;
            Party = party;
            VoteCount = voteCount;
        }
    }
}
