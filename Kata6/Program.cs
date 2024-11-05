namespace Kata6;

class Program
{
    static void Main(string[] args)
    {
        string[] enemies = { "Goblin", "Orc", "Troll", "Skeleton", "Dragon" };
        var items = new List<string> { "Sword", "Shield", "Potion" };
        
        Console.WriteLine("Enemies:");
        PrintEnemies();
        Console.WriteLine("\nItems in inventory:");
        PrintItems();
        items.AddRange(new List<string> {"Helmet", "Armor"});
        items.Remove("Potion");
        Console.WriteLine("\nUpdated inventory:");
        PrintItems();
        
        void PrintEnemies()
        {
            foreach(string enemy in enemies)
            {
                Console.WriteLine(enemy);
            }
        }

        void PrintItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            } 
        }
    }
}