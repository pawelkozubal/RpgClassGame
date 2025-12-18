class Goblin : Character
{
    public Goblin() : base("Goblin",60,10,3){ }

    public override void SpecialAbility(Character target)
    {
        BasicAttack(target);
    }
}