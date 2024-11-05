namespace Kata5;

class Program
{
    static void Main(string[] args)
    {
        AttackEnemy("Orc", 20);
        HealPlayer("Player", 10);
        void AttackEnemy(string enemyName, int damage)
        {
            Console.WriteLine($"{damage} of damage dealt to {enemyName}");
        }

        void HealPlayer(string playerName, int healAmount)
        {
            Console.WriteLine($"{playerName} heals with {healAmount} points");
        }
    }
}