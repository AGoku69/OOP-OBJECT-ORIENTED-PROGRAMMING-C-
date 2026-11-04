using System;

namespace VotingSystemApp
{
    public class VoterUI
    {
        private readonly VoterService _voterService;

        public VoterUI(VoterService voterService)
        {
            _voterService = voterService;
        }

        public void RegisterVoterMenu()
        {
            Console.Clear();
            PrintSubHeader("Voter Registration");
            Console.Write("Enter Voter ID / CNIC: ");
            string id = Console.ReadLine();

            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();

            bool success = _voterService.RegisterVoter(id, name);
            if (success)
            {
                PrintSuccess("Voter registered successfully!");
            }
            else
            {
                PrintError("Error: Voter ID already exists.");
            }
            Pause();
        }

        public void ShowVotersMenu()
        {
            Console.Clear();
            PrintSubHeader("Registered Voters");
            var voters = _voterService.GetAllVoters();

            if (voters.Count == 0)
            {
                Console.WriteLine("No registered voters found.");
                Pause();
                return;
            }

            foreach (var v in voters)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"ID: {v.VoterId,-12} | Name: {v.Name,-15} | Voted: {v.HasVoted}");
                Console.ResetColor();
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
