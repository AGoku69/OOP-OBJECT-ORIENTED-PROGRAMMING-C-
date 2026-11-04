using System.Collections.Generic;
using System.IO;

namespace VotingSystemApp
{
    public class CandidateRepository
    {
        private readonly string filePath = "candidates.txt";

        public List<Candidate> LoadCandidates()
        {
            var list = new List<Candidate>();
            if (!File.Exists(filePath)) return list;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 4 && int.TryParse(parts[0], out int id) && int.TryParse(parts[3], out int votes))
                {
                    list.Add(new Candidate(id, parts[1], parts[2], votes));
                }
            }
            return list;
        }

        public void SaveCandidates(List<Candidate> list)
        {
            var lines = new List<string>();
            foreach (var c in list)
            {
                lines.Add($"{c.Id},{c.Name},{c.Party},{c.VoteCount}");
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}