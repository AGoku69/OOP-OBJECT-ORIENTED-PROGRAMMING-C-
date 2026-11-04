using System;

namespace VotingSystemApp
{
    public class CandidateUI
    {
        private readonly CandidateService _candidateService;

        public CandidateUI(CandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        public void AddCandidateMenu()
        {
            Console.Clear();
            PrintSubHeader("Add New Candidate");
            Console.Write("Enter Candidate Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Political Party: ");
            string party = Console.ReadLine();

            _candidateService.AddCandidate(name, party);
            PrintSuccess("Candidate added successfully!");
            Pause();
        }

        public void ShowCandidatesMenu()
        {
            Console.Clear();
            PrintSubHeader("All Available Candidates");
            var list = _candidateService.GetAllCandidates();

            if (list.Count == 0)
            {
                Console.WriteLine("No candidates found.");
                Pause();
                return;
            }

            foreach (var c in list)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"ID: {c.Id,-3} | Name: {c.Name,-15} | Party: {c.Party,-12} | Votes: {c.VoteCount}");
                Console.ResetColor();
            }
            Pause();
        }

        public void SearchCandidateMenu()
        {
            Console.Clear();
            PrintSubHeader("Search Candidates");
            Console.Write("Enter keyword (Name or Party): ");
            string keyword = Console.ReadLine();

            var results = _candidateService.SearchCandidates(keyword);

            if (results.Count == 0)
            {
                PrintError($"No candidates found matching '{keyword}'.");
            }
            else
            {
                PrintSuccess($"Found {results.Count} result(s):");
                foreach (var c in results)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"ID: {c.Id,-3} | Name: {c.Name,-15} | Party: {c.Party,-12} | Votes: {c.VoteCount}");
                    Console.ResetColor();
                }
            }
            Pause();
        }

        private void PrintSubHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n--- {title} ---");
            Console.ResetColor();
        }

        private void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
