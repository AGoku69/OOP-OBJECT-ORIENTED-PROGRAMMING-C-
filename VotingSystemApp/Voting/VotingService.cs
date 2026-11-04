using System.Collections.Generic;

namespace VotingSystemApp
{
    public class VotingService
    {
        private readonly VotingRepository _repo;
        private List<VoteRecord> _votes;

        public VotingService()
        {
            _repo = new VotingRepository();
            _votes = _repo.LoadVotes();
        }

        public void RecordVote(string voterId, int candidateId)
        {
            _votes.Add(new VoteRecord(voterId, candidateId));
            _repo.SaveVotes(_votes);
        }

        public List<VoteRecord> GetAllVotes() => _votes;
    }
}