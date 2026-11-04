using System;

namespace VotingSystemApp
{
    public class VoteRecord
    {
        public string VoterId { get; set; }
        public int CandidateId { get; set; }
        public DateTime VoteDate { get; set; }

        public VoteRecord(string voterId, int candidateId)
        {
            VoterId = voterId;
            CandidateId = candidateId;
            VoteDate = DateTime.Now;
        }
    }
}