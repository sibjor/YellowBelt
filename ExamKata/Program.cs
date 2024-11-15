using System;
using System.Collections.Generic;

namespace ExamKata;

class Program
{
    static void Main(string[] args)
    {
        Player player = new("You", 100, 20);
        Enemy enemy = new("Dragon", 100, 15);
        NPC npc = new("John Doe");
        Merchant merchant = new("Jane Smith");

        // Game Setup
        merchant.Inventory.Add("Apple");
        npc.Dialogue = $"{merchant.Name} is too greedy...";

        // Game Execution
        npc.Speak();
        merchant.Trade();
        player.Attack(enemy);
    }
}

interface IIsCharacter
{
    string Name { get; set; }
    string Type { get; set; }
}

interface ICanSpeak : IIsCharacter
{
    string Dialogue { get; set; }
    void Speak() => Console.WriteLine($"{Name} says: \"{Dialogue}\"");
}

interface ICanFight : IIsCharacter
{
    int Health { get; set; }
    int Damage { get; set; }
    void TakeDamage(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine($"The {Type} {Name} is killed!");
        }
        else
        {
            Health -= damage;
            Console.WriteLine($"The {Type} {Name} has {Health} health.");
        }
    }
    
    public void Attack(ICanFight target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}");
        target.TakeDamage(Damage);
    }
}

interface ICanTrade : ICanSpeak
{
    List<string> Inventory { get; set; }
    void Trade()
    {
        Console.WriteLine($"Available items at {Name}'s shop: ");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"* {item}");
        }
    }
}

class Player : ICanFight, ICanSpeak
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Dialogue { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public Player(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }



    public void Speak()
    {
        Console.WriteLine($"{Name} says: \"{Dialogue}\"");
    }
}

class NPC : ICanSpeak
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Dialogue { get; set; }

    public NPC(string name)
    {
        Name = name;
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} says: \"{Dialogue}\"");
    }
}

class Merchant : NPC, ICanTrade
{
    public List<string> Inventory { get; set; } = new List<string>();

    public Merchant(string name) : base(name) { }

    public void Trade()
    {
        Console.WriteLine($"Available items at {Name}'s shop: ");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"* {item}");
        }
    }
}

class Enemy : ICanFight
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public Enemy(string type, int health, int damage)
    {
        Type = type;
        Health = health;
        Damage = damage;
    }

    public void TakeDamage(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine($"The {Type} {Name} is killed!");
        }
        else
        {
            Health -= damage;
            Console.WriteLine($"The {Type} {Name} has {Health} health.");
        }
    }
}
