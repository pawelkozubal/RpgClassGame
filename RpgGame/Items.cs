public abstract class Item
{
    public string Name { get; protected set; } 

     protected Item(string name)
    {
        Name = name;
    }
    public abstract void Use( Character user,Character? target);
}

//Making small health potion
public class HealthPotion : Item
{
    private readonly int healAmount;


    public HealthPotion() :base("Health Potion")
    {
        healAmount = 10;
    }

    public override void Use(Character user, Character? target)
    {
        Console.WriteLine($"{user.Name} uses a {Name}!");
        user.Heal(healAmount);
    }
}

// //Making small big potion

public class HealthJug : Item
{
    private readonly int healAmount;


    public HealthJug() :base("Health Jug Potion")
    {
        healAmount = 25;
    }

    public override void Use(Character user, Character? target)
    {
        Console.WriteLine($"{user.Name} uses a {Name}!");
        user.Heal(healAmount);
    }
}

 // making the bomb
public class Bomb : Item
{
    public Bomb() : base("Bomb") { }

    public override void Use(Character user, Character target)
    {
        Console.WriteLine($"{user.Name} throws a  bomb at {target.Name}!");
        target.TakeDamage(25);
    }
}