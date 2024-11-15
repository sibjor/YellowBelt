namespace Kata8;

class Program
{
    static void Main(string[] args)
    {
        Player player = new();
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
    // Properties
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