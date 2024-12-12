using System;

namespace InteractiveStoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to the Interactive Story Game!");
            Console.WriteLine("You are a brave adventurer seeking fortune and glory.");
            Console.ResetColor();

            // Initialize game variables
            string playerName = GetPlayerName();
            int playerHealth = 100;
            int playerGold = 0;
            bool hasSword = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You find yourself in a dense forest, {playerName}.");
            Console.WriteLine("A path leads north, and a cave entrance is to the east.");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What do you do? (N)orth, (E)ast, or (R)est: ");
                string action = Console.ReadLine().ToUpper();
                Console.ResetColor();

                switch (action)
                {
                    case "N":
                        // Go north
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You head north on the path.");
                        Console.WriteLine("After a while, you come across a clearing with a chest in the center.");

                        if (TryOpenChest())
                        {
                            playerGold += 50;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You found 50 gold pieces!");
                        }
                        else
                        {
                            playerHealth -= 20;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You triggered a trap! You lost 20 health.");
                        }
                        Console.ResetColor();
                        break;

                    case "E":
                        // Go east
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You enter the cave.");
                        Console.WriteLine("It's dark, but you hear the sound of dripping water and faint rustling.");

                        if (TryFindSword())
                        {
                            hasSword = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("You found a sword!");
                        }
                        else
                        {
                            playerHealth -= 10;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You slipped and fell. You lost 10 health.");
                        }
                        Console.ResetColor();
                        break;

                    case "R":
                        // Rest
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You take a short rest.");
                        playerHealth += 10;
                        Console.WriteLine("You regained 10 health.");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Invalid action. Please try again.");
                        Console.ResetColor();
                        continue;
                }

                // Display player stats
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Health: {playerHealth}, Gold: {playerGold}, Sword: {hasSword}");
                Console.ResetColor();

                // Check game over conditions
                if (playerHealth <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You died! Game over.");
                    Console.ResetColor();
                    return;
                }

                // Check win conditions
                if (playerGold >= 100 && hasSword)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations! You won the game!");
                    Console.ResetColor();
                    return;
                }
            }
        }

        static string GetPlayerName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.ResetColor();
            return name;
        }

        static bool TryOpenChest()
        {
            Random random = new Random();
            return random.NextDouble() < 0.5;
        }

        static bool TryFindSword()
        {
            Random random = new Random();
            return random.NextDouble() < 0.7;
        }
    }
}
