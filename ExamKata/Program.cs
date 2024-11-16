using System.Collections.Generic;
using Kata10;

namespace ExamKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
        // Interfaces and classes (Player, Enemy, NPC, Merchant) go here (as previously defined).

        class Game
        {
            private Player player;
            private List<object> encounters;
            private Random random;

            public Game()
            {
                encounters = new List<object>();
                random = new Random();
            }

            public void Start()
            {
                SetupGame();
                RunGameLoop();
            }

            private void SetupGame()
            {
                Console.WriteLine("Enter your player's name:");
                string name = Console.ReadLine();
                player = new Player
                {
                    Name = name,
                    Health = 100,
                    Level = 1,
                    Experience = 0
                };

                Console.WriteLine($"Welcome, {player.Name}! Your journey begins.");

                for (int i = 0; i < 10; i++)
                {
                    int encounterType = random.Next(3);
                    switch (encounterType)
                    {
                        case 0:
                            encounters.Add(new Enemy { Type = "Goblin", Health = 50, Damage = 10 });
                            break;
                        case 1:
                            encounters.Add(new NPC { Dialogue = "Hello, traveler! Stay safe out there." });
                            break;
                        case 2:
                            encounters.Add(new Merchant
                            {
                                Name = "Wandering Trader",
                                Inventory = new List<string> { "Potion", "Sword", "Shield" }
                            });
                            break;
                    }
                }
            }

            private void RunGameLoop()
            {
                foreach (var encounter in encounters)
                {
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("Game Over! You have perished.");
                        return;
                    }

                    Console.WriteLine("\nYou encounter something...");
                    if (encounter is Enemy enemy)
                    {
                        HandleCombat(enemy);
                    }
                    else if (encounter is NPC npc)
                    {
                        HandleNPCInteraction(npc);
                    }
                    else if (encounter is Merchant merchant)
                    {
                        HandleMerchantInteraction(merchant);
                    }
                }

                Console.WriteLine("Congratulations! You survived all encounters.");
            }

            private void HandleCombat(Enemy enemy)
            {
                Console.WriteLine($"An enemy appears! It's a {enemy.Type}.");
                while (enemy.Health > 0 && player.Health > 0)
                {
                    Console.WriteLine("Choose an action: 1. Attack  2. Run");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        player.Attack();
                        enemy.TakeDamage(20);
                        if (enemy.Health > 0)
                        {
                            enemy.Attack();
                            player.TakeDamage(enemy.Damage);
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("You run away from the battle.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                }

                if (player.Health <= 0)
                {
                    Console.WriteLine("You were defeated in combat!");
                }
                else
                {
                    Console.WriteLine("You defeated the enemy!");
                    player.GainExperience(50);
                }
            }

            private void HandleNPCInteraction(NPC npc)
            {
                Console.WriteLine("You meet a friendly NPC.");
                npc.Speak();
            }

            private void HandleMerchantInteraction(Merchant merchant)
            {
                Console.WriteLine("You encounter a merchant.");
                merchant.Speak();
                merchant.BrowseItems();

                Console.WriteLine("Would you like to buy something? (yes/no)");
                string choice = Console.ReadLine().ToLower();
                if (choice == "yes")
                {
                    Console.WriteLine("Enter the name of the item you want to buy:");
                    string item = Console.ReadLine();
                    merchant.Trade(item);
                }
                else
                {
                    Console.WriteLine("You decide not to buy anything.");
                }
            }
        }
    }
}