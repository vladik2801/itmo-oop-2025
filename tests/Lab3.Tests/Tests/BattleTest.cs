using Itmo.ObjectOrientedProgramming.Lab3.Board;
using Itmo.ObjectOrientedProgramming.Lab3.Configuration;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public sealed class BattleTest
{
    [Fact]
    public void Run_WhenFirstBoardHasStrongerCreature_ShouldReturnFirstPlayerWin()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        var fisrtBoard = new CreatureBoard();
        ICreature strongCreature = factory.CreateCombatAnalystBuilder().Build();
        fisrtBoard.AddCreature(strongCreature);
        var secondBoard = new CreatureBoard();
        ICreature weakCreature = factory.CreateEvilFighterBuilder().Build();
        secondBoard.AddCreature(weakCreature);
        var battle = new Battle(fisrtBoard, secondBoard);

        // Act
        ResultBattle result = battle.RunBattle();

        // Assert
        Assert.Equal(new ResultBattle.FirstWin(), result);
    }

    [Fact]
    public void Run_WhenSecondBoardHasStrongerCreature_ShouldReturnSecondPlayerWin()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        var fisrtBoard = new CreatureBoard();
        ICreature strongCreature = factory.CreateEvilFighterBuilder().Build();
        fisrtBoard.AddCreature(strongCreature);
        var secondBoard = new CreatureBoard();
        ICreature weakCreature = factory.CreateCombatAnalystBuilder().Build();
        secondBoard.AddCreature(weakCreature);
        var battle = new Battle(fisrtBoard, secondBoard);

        // Act
        ResultBattle result = battle.RunBattle();

        // Assert
        Assert.Equal(new ResultBattle.SecondWin(), result);
    }

    [Fact]
    public void Run_WhenBothBoardsEmpty_ShouldReturnDraw()
    {
        // Arrange
        var fisrtBoard = new CreatureBoard();
        var secondBoard = new CreatureBoard();
        var battle = new Battle(fisrtBoard, secondBoard);

        // Act
        ResultBattle result = battle.RunBattle();

        // Assert
        Assert.Equal(new ResultBattle.Draw(), result);
    }

    [Fact]
    public void MagicShield_ShouldIgnoreFirstDamage_AndApplySecond()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature baseCreature = factory.CreateCombatAnalystBuilder().Build();
        int startHp = baseCreature.HealthPoints;
        var applier = new ModifierApplier();
        ICreature shieldCreature = applier.Apply(baseCreature, ModifiersType.MagicShield);

        // Act
        shieldCreature.TakeDamage(3);
        int hpAfterFirstDamage = shieldCreature.HealthPoints;
        shieldCreature.TakeDamage(3);
        int hpAfterSecondDamage = shieldCreature.HealthPoints;

        // Assert
        Assert.Equal(startHp, hpAfterFirstDamage);
        Assert.Equal(hpAfterSecondDamage, startHp - 3);
    }

    [Fact]
    public void AttackSkill_ShouldIncreaseDamageComparedToBaseCreature()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature baseAttacker = factory.CreateCombatAnalystBuilder().Build();
        ICreature targetWithoutBuff = factory.CreateEvilFighterBuilder().Build();
        ICreature targetWithBuff = factory.CreateEvilFighterBuilder().Build();
        int targetHp = targetWithoutBuff.HealthPoints;
        var applier = new ModifierApplier();
        ICreature buffedAttacker =
            applier.Apply(factory.CreateCombatAnalystBuilder().Build(), ModifiersType.AttackSkill);

        // Act
        baseAttacker.Attack(targetWithoutBuff);
        int hpAfterDamage = targetWithoutBuff.HealthPoints;
        int baseDamage = targetHp - hpAfterDamage;

        buffedAttacker.Attack(targetWithBuff);
        int hpAfterBuffDamage = targetWithBuff.HealthPoints;
        int buffedDamage = targetHp - hpAfterBuffDamage;

        // Assert
        Assert.True(buffedDamage > baseDamage);
    }

    [Fact]
    public void PowerSpell_ShouldIncreaseAttackByFive()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature baseCreature = factory.CreateCombatAnalystBuilder().Build();
        int startAttack = baseCreature.AttackPoints;
        int startHealth = baseCreature.HealthPoints;
        PowerSpell spell = new();

        // Act
        ICreature result = spell.Cast(baseCreature);

        // Assert
        Assert.Equal(startAttack + 5, result.AttackPoints);
        Assert.Equal(startHealth, result.HealthPoints);
    }

    [Fact]
    public void StaminaSpell_ShouldIncreaseHealthByFive()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature baseCreature = factory.CreateCombatAnalystBuilder().Build();
        int startAttack = baseCreature.AttackPoints;
        int startHealth = baseCreature.HealthPoints;
        StaminaSpell spell = new();

        // Act
        ICreature result = spell.Cast(baseCreature);

        // Assert
        Assert.Equal(startAttack, result.AttackPoints);
        Assert.Equal(startHealth + 5, result.HealthPoints);
    }

    [Fact]
    public void AmuletSpell_ShouldGiveMagicShield()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature baseCreature = factory.CreateCombatAnalystBuilder().Build();
        int startHealth = baseCreature.HealthPoints;
        AmuletProtectionSpell spell = new();

        // Act
        ICreature protectedCreature = spell.Cast(baseCreature);
        protectedCreature.TakeDamage(3);
        int healthAfterFirstDamage = protectedCreature.HealthPoints;
        protectedCreature.TakeDamage(3);
        int healthAfterSecondDamage = protectedCreature.HealthPoints;

        // Assert
        Assert.Equal(startHealth, healthAfterFirstDamage);
        Assert.Equal(healthAfterSecondDamage, startHealth - 3);
    }

    [Fact]
    public void CreatureWithMagicShieldAndAttackSkill_ShouldIgnoreFirstDamage_AndDealMoreDamage()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        var applier = new ModifierApplier();
        ICreature baseAttacker = factory.CreateCombatAnalystBuilder().Build();
        ICreature bufAttacker = applier.Apply(baseAttacker, ModifiersType.MagicShield);
        bufAttacker = applier.Apply(bufAttacker, ModifiersType.AttackSkill);
        int bufStartHealth = bufAttacker.HealthPoints;
        ICreature baseTarget = factory.CreateEvilFighterBuilder().Build();
        ICreature bufTarget = factory.CreateEvilFighterBuilder().Build();
        int targetStartHp = baseTarget.HealthPoints;

        // Act
        bufAttacker.TakeDamage(3);
        int hpAfterFisrtDamage = bufAttacker.HealthPoints;
        baseTarget.TakeDamage(3);
        int baseDamage = targetStartHp - baseTarget.HealthPoints;
        baseAttacker.Attack(bufTarget);
        int bufDamage = targetStartHp - bufTarget.HealthPoints;

        // Assert
        Assert.Equal(bufStartHealth, hpAfterFisrtDamage);
        Assert.True(bufDamage > baseDamage);
    }

    [Fact]
    public void CreatureClone_ShouldBeIndependentCopy()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        ICreature baseCreature = factory.CreateCombatAnalystBuilder().Build();
        int baseHpStart = baseCreature.HealthPoints;
        int baseAttackStart = baseCreature.AttackPoints;

        // Act
        ICreature clone = baseCreature.Clone();
        clone.TakeDamage(3);

        // Assert
        Assert.Equal(baseHpStart, baseCreature.HealthPoints);
        Assert.Equal(baseAttackStart, baseCreature.AttackPoints);
        Assert.NotEqual(baseCreature.HealthPoints, clone.HealthPoints);
        Assert.False(ReferenceEquals(baseCreature, clone));
    }
}