namespace YellowBelt;

class Program
{
    static void Main(string[] args)
    {
        
        Attack(20);
        Heal(40);
        
        static void Attack(int damage)
        {
            Console.WriteLine($"{damage} of damage is dealt");
        }

        static void Heal(int healAmount)
        {
            Console.WriteLine($"{healAmount} of health is added");
        }
    }
}