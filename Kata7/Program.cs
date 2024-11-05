namespace Kata7;

class Program
{
    static void Main(string[] args)
    {
        
    }
}

class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Level { get; private set; }
    public int Experience { get; private set; }

    void Attack(int damage)
    {
        Console.WriteLine($"Player attacks the enemy dealing {damage} damage");
    }

    void GainExperience(int experience)
    {
        Experience += experience;
        Console.WriteLine($"Player gained {experience} experience");
    }
}

class Enemy // continue from here tomorrow!
{
    
}