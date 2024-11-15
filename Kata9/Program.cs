using System.Runtime.CompilerServices;

namespace Kata9;

class Program
{
    static void Main(string[] args)
    {
        Player player = new();
        var enemy = new Enemy();
        NPC npc = new();
        var merchant = new Merchant();

        // Init game
        
        player.Name = "You";
        enemy.Type = "Dragon";
        enemy.Name = $"the {enemy.Type}";
        npc.Name = "John Doe";
        merchant.Name = "Jane Smith";
        
        merchant.Inventory.Add("Apple");
        npc.Dialogue = $"{merchant.Name} is to greedy...";
        
        // Run Game
        npc.Speak();
        merchant.Trade();
        player.Attack(enemy);
    }
}

// Define four classes: Player, Enemy, NPC, and Merchant.

class Player 
{
    /*
     Properties: Name (string), Health (int), and Level (int).
     Method: Attack that takes an enemy name and deals damage. */
    
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }

    public void Attack(Enemy enemy)
    {
        Console.WriteLine($"{Name} attack {enemy.Name}");
        enemy.TakeDamage(16);
    }
}



class NPC
{
    /*
     * Properties: Name (string) and Dialogue (string).
       Method: Speak that prints the dialogue.
     */
    virtual public string Name { get; set; }
    public string Dialogue { get; set; }

    public void Speak()
    {
        Console.WriteLine($"{Name} sais \"{Dialogue}\"");
    }
}

class Merchant : NPC
{
    /*
     * Properties: Name (string) and Inventory (list of items).
       Method: Trade that displays available items in inventory.
     */
    public List<string> Inventory { get; set; } = new List<string>();

    public void Trade()
    {
        Console.WriteLine($"Availible items at {Name}:s shop: ");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"* {item}");
        }
    }
}

class Enemy : NPC
{
    /*
     * Properties: Type (string), Health (int), and Damage (int).
     * Method: TakeDamage that reduces health and displays the remaining health.
     */
    
    
    public string Type { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public override string Name
    {
        get => base.Name;
        set => base.Name = value.ToLower();
    }
    public void TakeDamage(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} is killed!");
        }
        else
        {
            Health -= damage;
            Console.WriteLine($"{Name} has {Health} health.");
        }

    }
}