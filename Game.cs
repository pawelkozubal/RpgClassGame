class Game
{
    public static Character ChooseClass(string name)
    {
        Console.WriteLine("Choose your characters class");
        Console.WriteLine("1.Warrior");
        Console.WriteLine("2. Mage");
        Console.WriteLine("3. Tank");

        string choice = Console.ReadLine()!;

        return choice switch
        {
            "1" => new Warrior(name),
            "2" => new Mage(name),
            "3" => new Tank(name),
            _ => new Warrior(name)
        };
    }

    public static void Battle(Character player, Character enemy)
    {
        Console.WriteLine($"\nA wild {enemy.Name} apprears!\n");

        while (player.isAlive && enemy.isAlive)
        {
            Console.WriteLine("\nYour turn:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Special Ability");
            Console.WriteLine("3. Use Item");

            string action = Console.ReadLine()!;

            if (action == "1")
                player.BasicAttack(enemy);
            else if (action == "2")
                player.SpecialAbility(enemy);
            else if (action == "3")
            {
                if (player.Inventory.Count == 0)
                {
                    Console.WriteLine("No items available");
                }
                else
                {
                    Console.WriteLine("Choose item");
                    for (int i=0; i < player.Inventory.Count; i++)
                        Console.WriteLine($"{i + 1}. {player.Inventory[i].Name}");
                    
                    int choice = int.Parse(Console.ReadLine()!) - 1;
                    player.UseItem(choice);
                }
            }
            else
                Console.WriteLine("you Hestitate...");

                if (enemy.isAlive)
                    enemy.BasicAttack(player);
        }
        Console.WriteLine(player.isAlive ? "\nYou Won!" : "\nYou died...");
    }
}