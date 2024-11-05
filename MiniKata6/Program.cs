namespace MiniKata6;

class Program
{
    static void Main(string[] args)
    {
        string[] enemies = {"Goblin", "Orc", "Troll"};
        var items = new List<string> {"Sword", "Shield", "Potion"};
        
        Console.WriteLine("Enemies:");
        PrintEnemies();
        Console.WriteLine("\nItems in inventory:");
        PrintInventory();
        items.Add("Helmet");
        Console.WriteLine("\nUpdated inventory:");
        PrintInventory();

        void PrintEnemies()
        {
            foreach (string enemy in enemies)
            {
                Console.WriteLine(enemy);
            }
        }

        void PrintInventory()
        {
            foreach (string item in items)
            {
                Console.WriteLine(item);
            }
        }

    }
}