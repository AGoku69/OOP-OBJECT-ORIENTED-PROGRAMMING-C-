using System;
using System.Collections.Generic;
using System.IO;

namespace VotingSystemApp
{
    public class VotingRepository
    {
        private readonly string filePath = "votes.txt";

        public List<VoteRecord> LoadVotes()
        {
            var list = new List<VoteRecord>();
            if (!File.Exists(filePath)) return list;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && int.TryParse(parts[1], out int candidateId) && DateTime.TryParse(parts[2], out DateTime date))
                {
                    var record = new VoteRecord(parts[0], candidateId) { VoteDate = date };
                    list.Add(record);
                }
            }
            return list;
        }

        public void SaveVotes(List<VoteRecord> list)
        {
            var lines = new List<string>();
            foreach (var v in list)
            {
                lines.Add($"{v.VoterId},{v.CandidateId},{v.VoteDate}");
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
