using System.Collections.Generic;
using System.IO;

namespace VotingSystemApp
{
    public class VoterRepository
    {
        private readonly string filePath = "voters.txt";

        public List<Voter> LoadVoters()
        {
            var list = new List<Voter>();
            if (!File.Exists(filePath)) return list;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && bool.TryParse(parts[2], out bool voted))
                {
                    list.Add(new Voter(parts[0], parts[1], voted));
                }
            }
            return list;
        }

        public void SaveVoters(List<Voter> list)
        {
            var lines = new List<string>();
            foreach (var v in list)
            {
                lines.Add($"{v.VoterId},{v.Name},{v.HasVoted}");
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
