namespace MiniKata7;

class Program
{
    static void Main(string[] args)
    {
        Player player = new("Player", 100, 16);
        Console.WriteLine();
        var enemy = new Enemy("Orc", 50, 10);
    }
}

class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Level { get; private set; }
    public Player(string name, int health, int level)
    {
        Name = name;
        Health = health;
        Level = level;
        
        PrintProperties();
    }

    void PrintProperties()
    {
        Console.WriteLine("\nPlayer info:" +
                          $"\nName: {Name}" +
                          $"\nHealth: {Health}" +
                          $"\nLevel: {Level}");
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
        
        PrintProperties();
    }

    void PrintProperties()
    {
        Console.WriteLine("\nEnemy info:" +
                          $"\nType: {Type}" +
                          $"\nDamage: {Damage}" +
                          $"\nHealth: {Health}");
    }
}