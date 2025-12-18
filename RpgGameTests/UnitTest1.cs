namespace RpgGameTests;

public class CharacterTests
{
    
    [Fact]
    public void Heal_ShouldNotExceedMaxHP()
    {
        Character player = new Warrior("Pawel");
        player.TakeDamage(50);

        player.Heal(999);

        Assert.Equal(player.MaxHP, player.HP);
    }

    [Fact]
    public void TakeDamage_ShouldReduceHP_WithDefenseApplied()
    {
        // Arrange
        Character player = new Warrior("Pawel");
        int startingHP = player.HP;

        // Act
        player.TakeDamage(10);

        // Assert
        Assert.True(player.HP < startingHP);
    }

    [Fact]
    public void Character_ShouldDie_WhenHPReachesZero()
    {
        Character player = new Warrior("Pawel");

        player.TakeDamage(999);

        Assert.False(player.isAlive);
    }

}
