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

        player.Name = "You";
        enemy.Name = "the";
        npc.Name = "John Doe";
        merchant.Name = "Jane Smith";
        
        merchant.Inventory.Add("Apple");
        npc.Dialogue = $"{npc.Name}: \"The merchant {merchant.Name} is to greedy!\"";
        

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
        Console.WriteLine($"{Name} attacks {enemy}");
        enemy.TakeDamage(16);
    }
}



class NPC
{
    /*
     * Properties: Name (string) and Dialogue (string).
       Method: Speak that prints the dialogue.
     */
    public string Name { get; set; }
    public string Dialogue { get; set; }

    public void Speak()
    {
        Console.WriteLine(Dialogue);
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
        Console.WriteLine("Availible items of the merchant: ");
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

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"The {Type} has {Health} health.");
    }
}