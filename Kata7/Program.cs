namespace Kata7;

class Program
{
    static void Main(string[] args)
    {
        int playerDamage = 15; // not supposed to be included in the class as previously defined on the Github page
        int xpPostVictory = 10;
        
        var player = new Player("Player", 25, 5, 50);
        Enemy enemy = new("Orc", 75, 10);
        
        player.Attack(playerDamage);
        enemy.TakeDamage(playerDamage);
        
        player.GainExperience(xpPostVictory);
    }
}

class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Level { get; private set; }
    public int Experience { get; private set; }

    public Player(string name, int health, int level, int experience)
    {
        Name = name;
        Health = health;
        Level = level;
        Experience = experience;
    }

    public void Attack(int damage)
    {
        Console.WriteLine($"Player attacks the enemy dealing {damage} damage");
    }

    public void GainExperience(int experience)
    {
        Experience += experience;
        Console.WriteLine($"Player gained {experience} experience");
    }
}

class Enemy 
{
    public string Type { get; private set; }
    public int Health { get; private set; }
    public int Damage { get; private set; }

    public Enemy(string type, int health, int damage)
    {
        Type = type;
        Health = health;
        Damage = damage;
    }

    public void TakeDamage(int damage) // not the same damage as above
    {
        Health -= damage;
        Console.WriteLine($"{Type} takes {damage} damage");
        if (Health <= 0)
        {
            Console.WriteLine("Enemy defeated");
        }
    }
}