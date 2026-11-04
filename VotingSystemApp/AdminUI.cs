using System;

namespace VotingSystemApp
{
    public class AdminUI
    {
        private const string AdminPassword = "admin123";
        private readonly CandidateUI _candidateUI;
        private readonly VoterUI _voterUI;

        public AdminUI(CandidateUI candidateUI, VoterUI voterUI)
        {
            _candidateUI = candidateUI;
            _voterUI = voterUI;
        }

        public void AdminLogin()
        {
            Console.Clear();
            PrintHeader("ADMIN AUTHENTICATION");

            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

            if (password == AdminPassword)
            {
                PrintSuccess("\nAccess Granted! Welcome, Admin.");
                Pause();
                OpenAdminMenu();
            }
            else
            {
                PrintError("\nIncorrect password! Access denied.");
                Pause();
            }
        }

        private void OpenAdminMenu()
        {
            bool adminRunning = true;
            while (adminRunning)
            {
                Console.Clear();
                PrintHeader("ADMIN PORTAL");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Add New Candidate");
                Console.WriteLine("2. View All Candidates & Results");
                Console.WriteLine("3. View All Registered Voters");
                Console.WriteLine("4. Logout / Back to Main Menu");
                Console.ResetColor();

                Console.Write("\nChoose option (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _candidateUI.AddCandidateMenu();
                        break;
                    case "2":
                        _candidateUI.ShowCandidatesMenu();
                        break;
                    case "3":
                        _voterUI.ShowVotersMenu();
                        break;
                    case "4":
                        adminRunning = false;
                        PrintSuccess("Logging out...");
                        Pause();
                        break;
                    default:
                        PrintError("Invalid option. Enter 1-4.");
                        Pause();
                        break;
                }
            }
        }

        private void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("========================================");
            Console.WriteLine($"        {title}         ");
            Console.WriteLine("========================================");
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