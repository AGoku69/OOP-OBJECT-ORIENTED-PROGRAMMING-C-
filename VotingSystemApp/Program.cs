using System;

namespace VotingSystemApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Services
            var candidateService = new CandidateService();
            var voterService = new VoterService();
            var votingService = new VotingService();

            // Initialize UIs
            var candidateUI = new CandidateUI(candidateService);
            var voterUI = new VoterUI(voterService);
            var votingUI = new VotingUI(votingService, voterService, candidateService);
            var adminUI = new AdminUI(candidateUI, voterUI);

            bool running = true;
            while (running)
            {
                Console.Clear();
                PrintHeader("ELECTRONIC VOTING SYSTEM");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. Voter Portal (Register & Vote)");
                Console.WriteLine("3. Search Candidate");
                Console.WriteLine("4. Exit Program");
                Console.ResetColor();

                Console.Write("\nChoose an option (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        adminUI.AdminLogin();
                        break;
                    case "2":
                        VoterPortalMenu(voterUI, votingUI, candidateUI);
                        break;
                    case "3":
                        candidateUI.SearchCandidateMenu();
                        break;
                    case "4":
                        running = false;
                        PrintSuccess("Exiting program. Goodbye!");
                        Pause();
                        break;
                    default:
                        PrintError("Invalid choice! Enter 1-4.");
                        Pause();
                        break;
                }
            }
        }

        static void VoterPortalMenu(VoterUI voterUI, VotingUI votingUI, CandidateUI candidateUI)
        {
            bool voterRunning = true;
            while (voterRunning)
            {
                Console.Clear();
                PrintHeader("VOTER PORTAL");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Register as Voter");
                Console.WriteLine("2. Cast Your Vote");
                Console.WriteLine("3. View Candidates List");
                Console.WriteLine("4. Back to Main Menu");
                Console.ResetColor();

                Console.Write("\nChoose option (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        voterUI.RegisterVoterMenu();
                        break;
                    case "2":
                        votingUI.CastVoteMenu();
                        break;
                    case "3":
                        candidateUI.ShowCandidatesMenu();
                        break;
                    case "4":
                        voterRunning = false;
                        PrintSuccess("Returning to Main Menu...");
                        Pause();
                        break;
                    default:
                        PrintError("Invalid option. Enter 1-4.");
                        Pause();
                        break;
                }
            }
        }

        static void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("========================================");
            Console.WriteLine($"        {title}         ");
            Console.WriteLine("========================================");
            Console.ResetColor();
        }

        static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
