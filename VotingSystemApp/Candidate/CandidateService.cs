using System;
using System.Collections.Generic;

namespace VotingSystemApp
{
    public class CandidateService
    {
        private readonly CandidateRepository _repo;
        private List<Candidate> _candidates;

        public CandidateService()
        {
            _repo = new CandidateRepository();
            _candidates = _repo.LoadCandidates();
        }

        public void AddCandidate(string name, string party)
        {
            int newId = _candidates.Count > 0 ? _candidates[_candidates.Count - 1].Id + 1 : 1;
            _candidates.Add(new Candidate(newId, name, party));
            _repo.SaveCandidates(_candidates);
        }

        public List<Candidate> GetAllCandidates() => _candidates;

        // **SEARCH FEATURE**
        public List<Candidate> SearchCandidates(string keyword)
        {
            return _candidates.FindAll(c =>
                c.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Party.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public Candidate GetCandidateById(int id)
        {
            return _candidates.Find(c => c.Id == id);
        }

        public void IncrementVote(int candidateId)
        {
            var candidate = GetCandidateById(candidateId);
            if (candidate != null)
            {
                candidate.VoteCount++;
                _repo.SaveCandidates(_candidates);
            }
        }
    }
}
