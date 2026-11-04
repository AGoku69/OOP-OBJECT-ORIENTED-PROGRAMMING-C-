using GameProject.Models;
using GameProject.Services;
using System;
using System.Collections.Generic;

namespace GameProject.UI
{
    // The UI displays information and collects input.
    public class GameUI
    {
        private readonly GameService _service;
        public GameUI(GameService service) { _service = service; }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                ShowTitle();
                Console.WriteLine("1. Start game");
                Console.WriteLine("2. View scores");
                Console.WriteLine("3. How to play");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                if (choice == "1") PlayGame();
                else if (choice == "2") ShowScores();
                else if (choice == "3") ShowInstructions();
                else if (choice == "4") running = false;
                else { Console.WriteLine("Invalid option. Press Enter."); Console.ReadLine(); }
            }
        }

        private void PlayGame()
        {
            Console.Clear();
            Console.Write("Player name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) name = "Player";

            Player player = _service.CreatePlayer(name);
            List<Monster> monsters = _service.CreateMonsters();

            foreach (Monster monster in monsters)
            {
                Console.WriteLine("\nA " + monster.Name + " appears!");
                RunBattle(player, monster);
                if (!player.IsAlive()) break;
                _service.GiveMonsterReward(player, monster);
                Console.WriteLine(monster.Name + " defeated! Score: " + player.Score);
            }

            bool won = player.IsAlive();
            if (won)
            {
                int bonus = _service.CalculateVictoryBonus(player);
                player.AddScore(bonus);
                Console.WriteLine("\nYou defeated every monster! Bonus: " + bonus);
            }
            else Console.WriteLine("\nYou were defeated.");

            _service.SaveResult(player, won);
            Console.WriteLine("Final score: " + player.Score);
            Pause();
        }

        private void RunBattle(Player player, Monster monster)
        {
            while (player.IsAlive() && monster.IsAlive())
            {
                ShowBattleStatus(player, monster);
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use healing potion");
                Console.Write("Action: ");
                string action = Console.ReadLine();

                if (action == "1")
                    Console.WriteLine("You dealt " + _service.PlayerAttack(player, monster) + " damage.");
                else if (action == "2")
                    Console.WriteLine(player.UseHealingPotion() ? "Health restored." : "No potions left.");
                else
                    Console.WriteLine("Invalid action. You lose this turn.");

                if (monster.IsAlive())
                    Console.WriteLine(monster.Name + " dealt " + _service.MonsterAttack(monster, player) + " damage.");
            }
        }

        private void ShowBattleStatus(Player player, Monster monster)
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine(player.Name + " HP: " + player.Health + " | Potions: " + player.HealingPotions);
            Console.WriteLine(monster.Name + " HP: " + monster.Health);
            Console.WriteLine("-----------------------------");
        }

        private void ShowScores()
        {
            Console.Clear();
            Console.WriteLine("=== SAVED SCORES ===");
            // GetTopScores is an advanced student exercise in the service layer.
            List<GameResult> scores = _service.GetTopScores(5);
            if (scores.Count == 0) Console.WriteLine("No saved games yet.");
            foreach (GameResult score in scores)
                Console.WriteLine(score.PlayerName + " - " + score.Score + " - " + score.Result);
            Pause();
        }

        private void ShowTitle()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("     MONSTER BATTLE ARENA");
            Console.WriteLine("=============================");
        }

        private void ShowInstructions()
        {
            // STUDENT TODO (UI task): explain attack, healing, winning, losing,
            // and scoring here. Clear the screen first and call Pause() last.
            bool running = true;
            while (running)
            {
                Console.Clear();
                ShowTitle();
                Console.WriteLine(" When you start the game you can choose a name for your player and then give the player a name\n then the mosters will appear on your screen and the game play will begin\n and of you want more info Select an option from below");
                Console.WriteLine("1. instructions for Attacks");
                Console.WriteLine("2. instructions for Healing");
                Console.WriteLine("3. instructions for winning");
                Console.WriteLine("4. instructions for losing");
                Console.WriteLine("5. instructions for scoring");
                Console.WriteLine("6. Exist");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();
                if (choice == "1") AttackINFO();
                else if (choice == "2") HealingINFO();
                else if (choice == "3") WinningINFO();
                else if (choice == "4") LosingINFO();
                else if (choice == "5") ScoringINFO();
                else if (choice == "6") running = false;
                else
                {
                    Console.WriteLine("\nInstructions have not been completed yet.");
                    Pause();
                }
            }
        }
        private void AttackINFO()
        {
            Console.Clear();
            Console.WriteLine("HOW THE ATTACKING WORKS");
            Console.WriteLine("The default value for attack is set for both player and momster\n when the player uses the attack option the attack is calculated\n and a random plus or minus in the attack value\n and then stored to the take damage\n and then it is deducted from the monsters health ");
            pause();
        }
        private void HealingINFO()
        {
            Console.Clear();
            Console.WriteLine("HOW THE HEALING WORKS");
            Console.WriteLine("The healing is set at a defalut value too\n as when the user uses the healing option \n it sees if the user has a potio or not first\n and if he does it adds or heals the players health restoring it");
            pause();
        }
        private void WinningINFO()
        {
            Console.Clear();
            Console.WriteLine("HOW THE WINNING WORKS");
            Console.WriteLine("The program checks after very attack used \n that is where a player still alive or death it checks the players health and also monsters too\n if players is not alive then the mosters win\n and on winning each time against a moster the player gets a bonus in its remaining potions");
            pause();
        }
        private void LosingINFO()
        {
            Console.Clear();
            Console.WriteLine("HOW THE LOSING WORKS");
            Console.WriteLine("The losing works jsut like winning but opposite\n when your player health gets below zero \n so you lose and the monsters win");
            pause();
        }
        private void ScoringINFO()
        {
            Console.Clear();
            Console.WriteLine("HOW THE SCORNING WORKS");
            Console.WriteLine("The scoring works simply \n when the moster dies it has a value assigned to it \n the score value on defeating he monster is added to the players score");
            pause();
        }

        private void Pause()
        {
            Console.Clear();
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
        private void pause()
        {
            Console.WriteLine("\nPress Enter to return to the INFO menu.");
            Console.ReadLine();
        }
    }
}
