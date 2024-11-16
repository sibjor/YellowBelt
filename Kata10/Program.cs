using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace Kata10;

class Program
{
    static void Main(string[] args)
    {
        // All three requirements are set, but classes are instantiated and demonstrated through ExamKata
    }
}
interface ICombat
{
    void Attack();
    void TakeDamage(int damage);
}

interface IHealable
{
    void Heal(int amount);
}

interface IExperience
{
    void GainExperience(int amount);
}

interface ISpeakable
{
    void Speak();
}

interface ITradeable
{
    void BrowseItems();
    void Trade(string item);
}

public class Player : ICombat, IHealable, IExperience
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }

    public void Attack()
    {
        Console.WriteLine($"{Name} attacks the enemy!");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} takes {damage} damage. Remaining health: {Health}");
    }

    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{Name} heals for {amount}. Current health: {Health}");
    }

    public void GainExperience(int amount)
    {
        Experience += amount;
        Console.WriteLine($"{Name} gains {amount} experience. Total experience: {Experience}");

        if (Experience >= Level * 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        Experience = 0;
        Console.WriteLine($"{Name} levels up! New level: {Level}");
    }
}

public class Enemy : ICombat
{
    public string Type { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public void Attack()
    {
        Console.WriteLine($"The {Type} attacks with {Damage} damage!");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"The {Type} takes {damage} damage. Remaining health: {Health}");

        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Console.WriteLine($"The {Type} has been defeated!");
    }
}

public class NPC : ISpeakable
{
    public string Dialogue { get; set; }

    public void Speak()
    {
        Console.WriteLine($"NPC says: \"{Dialogue}\"");
    }
}

public class Merchant : ISpeakable, ITradeable
{
    public string Name { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();

    public void Speak()
    {
        Console.WriteLine($"{Name}: \"Welcome to my shop!\"");
    }

    public void BrowseItems()
    {
        Console.WriteLine($"{Name}'s Inventory:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"- {item}");
        }
    }

    public void Trade(string item)
    {
        if (Inventory.Contains(item))
        {
            Inventory.Remove(item);
            Console.WriteLine($"You purchased {item} from {Name}.");
        }
        else
        {
            Console.WriteLine($"{Name}: \"Sorry, I don't have {item}.\"");
        }
    }
}
