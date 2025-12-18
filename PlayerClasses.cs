public class Warrior : Character
{
    public Warrior(string name) : base(name, 120, 20, 5)
    {
        
    }

    public override void SpecialAbility(Character target)
    {
        Console.WriteLine($"{Name} uses Power Strike to double his Damage!!");
        target.TakeDamage(Attack * 2);
    }
}

public class Mage : Character
{
    public int Mana { get; private set;} 

    public Mage(string name) : base(name,80,20,2)
    {
        Mana = 50;
    }

    public override void SpecialAbility(Character target)
    {
        if (Mana < 10)
        {
            Console.WriteLine("Not enough Mana, go recharge!!");
            return;
        }

        Mana -= 10;
        int damage = Attack + rng.Next(10,21); 
        Console.WriteLine($"{Name} casts a lighting Strike! (Mana: {Mana})");
        target.TakeDamage(damage);
    }
}

public class Tank : Character
{
    public Tank(string name):base(name,140,10,30)
    { }

    public override void SpecialAbility(Character target)
    {   
        int damage = Attack + rng.Next(5,40);
        Console.WriteLine($"{Name} You have picked up {target} and then body slammed them onto the ground!!");
        target.TakeDamage(damage);
    }
}