namespace Kata8;

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
        
        player.GainExperience(100);
        player.Health += 50;
    }
}

class Player
{
    // Fields
    private int _health;
    private int _level;
    private int _experience;
    
    // Constructor
    public Player(string name, int health, int level, int experience)
    {
        Name = name;
        Health = health;
        Level = level;
        Experience = experience;
    }
    // Properties
    public string Name { get; private set; }
    public int Health {
        get
        {
            return _health;
        }
        private set
        {
            _health = value;
        } 
    }

    public int Level
    {
        get => _level;
        set
        {
            if (value < 1)
            {
                Console.WriteLine("Level must be greater than 0. Keeping the previous value.");
            }
            else
            {
                _level = value; 
            }
        }
    }

    public int Experience
    {
        get => _experience;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Experience cannot be negative. Setting to 0.");
                _experience = 0;
            }
            else
            {
                _experience = value; 
            }
        }
    }
    // Methods
    
    public void Attack(int damage)
    {
        Console.WriteLine($"Player attacks the enemy dealing {damage} damage");
    }
    private void LevelUp()
    {
        _level++;
        _level = 0;
        Console.WriteLine("You current level: " + _level.ToString());
    }

    public void GainExperience(int exp)
    {
        _experience += exp;
        if (_experience >= 100)
        {
            LevelUp();
        }
        Console.WriteLine(exp + " experience points gained.");
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