using System;
using System.Collections.Generic;

namespace VotingSystemApp
{
    public class VoterService
    {
        private readonly VoterRepository _repo;
        private List<Voter> _voters;

        public VoterService()
        {
            _repo = new VoterRepository();
            _voters = _repo.LoadVoters();
        }

        public Voter GetVoter(string voterId)
        {
            return _voters.Find(v => v.VoterId.Equals(voterId, StringComparison.OrdinalIgnoreCase));
        }

        public bool RegisterVoter(string voterId, string name)
        {
            if (GetVoter(voterId) != null) return false;

            _voters.Add(new Voter(voterId, name, false));
            _repo.SaveVoters(_voters);
            return true;
        }

        public void MarkVoterAsVoted(string voterId)
        {
            var voter = GetVoter(voterId);
            if (voter != null)
            {
                voter.HasVoted = true;
                _repo.SaveVoters(_voters);
            }
        }

        public List<Voter> GetAllVoters() => _voters;
    }
}
