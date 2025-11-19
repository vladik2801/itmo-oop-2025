using Itmo.ObjectOrientedProgramming.Lab3.Configuration;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public sealed class SpecialAbility
{
    [Fact]
    public void CombatAnalyst_SpecialAbility_ShouldChangeAttackStats()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature analyst = factory.CreateCombatAnalystBuilder().Build();
        ICreature target = factory.CreateEvilFighterBuilder().Build();
        int startAnalystAttack = analyst.AttackPoints;

        // Act
        analyst.Attack(target);
        int endAnalystAttack = analyst.AttackPoints;

        // Assert
        Assert.Equal(startAnalystAttack + 2, endAnalystAttack);
    }

    [Fact]
    public void EvilFighter_SpecialAbility_ShouldChangeStats_AsExpected()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature target = factory.CreateEvilFighterBuilder().Build();
        ICreature attacker = factory.CreateCombatAnalystBuilder().Build();
        int startTargetAttackPoint = target.AttackPoints;

        // Act
        attacker.Attack(target);
        int endTargetAttackPoint = target.AttackPoints;

        // Assert
        Assert.Equal(startTargetAttackPoint * 2, endTargetAttackPoint);
    }

    [Fact]
    public void MimicChester_SpecialAbility_ShouldMakeMaxStats()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature mimic = factory.CreateMimicChestBuilder().Build();
        ICreature target = factory.CreateEvilFighterBuilder().Build();
        int startTargetHp = target.HealthPoints;
        int startTargetAttack = target.AttackPoints;

        // Act
        mimic.Attack(target);

        // Assert
        Assert.Equal(mimic.HealthPoints, startTargetHp);
        Assert.Equal(mimic.AttackPoints, startTargetAttack);
    }

    [Fact]
    public void ImmortalHorror_SpecialAbility_ShouldReborn()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature horror = factory.CreateImmortalHorrorBuilder().Build();
        ICreature attacker = factory.CreateCombatAnalystBuilder().Build();
        int expectedHpAfterReborn = 1;

        // Act
        attacker.Attack(horror);
        int hpAfterAttack = horror.HealthPoints;

        // Assert
        Assert.Equal(expectedHpAfterReborn, hpAfterAttack);
    }

    [Fact]
    public void MasterAmulets_SpecialAbility_ShouldHaveAllModifiers()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature master = factory.CreateMasterAmuletsBuilder().Build();
        ICreature target = factory.CreateEvilFighterBuilder().Build();
        int startHpMaster = master.HealthPoints;
        int expectedHpAfterAttack = -4;

        // Act
        target.Attack(master);
        master.Attack(target);

        // Assert
        Assert.Equal(startHpMaster, master.HealthPoints);
        Assert.Equal(expectedHpAfterAttack, target.HealthPoints);
    }
}