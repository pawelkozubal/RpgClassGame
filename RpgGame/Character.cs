public abstract class Character
{
    public string Name { get; protected set; }
    public int MaxHP { get; protected set; }
    public int HP { get; protected set; }
    public int Attack { get; protected set; }
    public int Defence { get; protected set; }

    public List<Item> Inventory {get; private set; } = new List<Item>();

    protected static Random rng = new Random();
    
    protected Character(string name, int hp, int attack, int defense)
    {
        Name = name; 
        MaxHP = hp;
        HP = hp;
        Attack = attack;
        Defence = defense;
    } 

    public string ClassName => GetType().Name;

    public bool isAlive => HP > 0; 

    public virtual void TakeDamage(int damage)
    {
        int reduced = Math.Max(1, damage - Defence);
        HP -= reduced;
        Console.WriteLine($"{Name} takes {reduced} damage (HP: {HP}/{MaxHP})");
    }

    public virtual void BasicAttack(Character target)
    {
        int damage = rng.Next(Attack - 2, Attack + 3);
        Console.WriteLine($"{Name} attacks {target.Name}!");
        target.TakeDamage(damage);
    }    

    public virtual void Heal(int amount)
    {
        HP = Math.Min(MaxHP, HP + amount);
        Console.WriteLine($"{Name} heals for {amount} HP (HP: {HP}/{MaxHP})");
    } 

    public void UseItem(int index, Character? target = null)
    {
        if (index < 0 || index >= Inventory.Count)
        {
            Console.WriteLine("Invalid item.");
            return;
        }

        Item item = Inventory[index];
        item.Use(this, target);
        Inventory.RemoveAt(index);
    }

    public abstract void SpecialAbility(Character target);
   
}