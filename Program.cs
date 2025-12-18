namespace RpgGame;

class Program
{
    static void Main(string[] args)
    {   

        bool running = true; 


        Console.WriteLine("Hello, Travaller Welcome to the Rift!");
        Console.Write("Enter your name: ");
        string name = Console.ReadLine()!;

        Character player = Game.ChooseClass(name); //players sets their class
        player.Inventory.Add(new Bomb());
        player.Inventory.Add(new HealthPotion());
        player.Inventory.Add(new HealthPotion()); //player gets 2 health potions
        Character enemy = new Goblin();   //we set the 1st enemy

        Console.WriteLine($"You Have chosen {player.ClassName}");

        while (running == true)
        {
            Console.WriteLine("\n==== MAIN MENU ===");
            Console.WriteLine("1. Explore");
            Console.WriteLine("2. Check Inventory");
            Console.WriteLine("3. View Player Stats");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine()!.ToLower();

            switch(input)
            {
            case "1":
                Console.WriteLine("\nYou venture forth...");
                Explore(player);
                break;

            case "2":
                ShowInventory(player, enemy);
                break;

            case "3":
                ShowStats(player);
                break;

            case "4":
                running = false;
                Console.WriteLine("Goodbye, adventurer!");
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break; 
            }
        }
    }

    static void ShowInventory(Character player, Character enemy)
    {
        if (player.Inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
            return;
        }

        Console.WriteLine("\n==== INVENTORY ====");
        for (int i = 0; i < player.Inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {player.Inventory[i].Name}");
        }

        Console.WriteLine("0. Back");
        Console.Write("Choose item to use: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
            return;

        if (choice == 0)
            return;

        int index = choice - 1;

        
        if (player.Inventory[index] is Bomb)
            player.UseItem(index, enemy);
        else
            player.UseItem(index);
    }
    static void ShowStats(Character player)
    {
        Console.WriteLine("\n==== PLAYER STATS ====");
        Console.WriteLine($"Name: {player.Name}");
        Console.WriteLine($"HP: {player.HP}/{player.MaxHP}");
        Console.WriteLine($"Attack: {player.Attack}");
        Console.WriteLine($"Defense: {player.Defence}");
    }

        static void Explore(Character player)
    {
        Random rnd = new Random();
        int eventRoll = rnd.Next(1, 8);

        Console.WriteLine("\nYou explore the Rift...\n");

        switch (eventRoll)
        {
            case 1:
                Console.WriteLine("You found a healing herb! +10 HP");
                player.Heal(10);
                break;

            case 2:
                Console.WriteLine("You discovered a small health potion!");
                player.Inventory.Add(new HealthPotion());
                break;

            case 3:
                Console.WriteLine("Another Goblin Attack!!!");
                Character enemy = new Goblin();
                Game.Battle(player, enemy);
                break;

            case 4:
                Console.WriteLine("You found a Health Potion!");
                player.Inventory.Add(new HealthPotion());
                break;

            case 5:
                Console.WriteLine("You trip over a rock!");
                player.TakeDamage(5);
                break;

            case 6:
                Console.WriteLine("⚔️ YOU ARE AMBUSHED! ⚔️");

                Character enemy1 = new Goblin();
                Game.Battle(player, enemy1);
                break;

            case 7:
                Console.WriteLine("You found the Ring of Power!");
                player.Inventory.Add(new HealthJug());
                break;
        }
    }
}
