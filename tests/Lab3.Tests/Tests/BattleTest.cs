using Itmo.ObjectOrientedProgramming.Lab3.Board;
using Itmo.ObjectOrientedProgramming.Lab3.Configuration.Factories;
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
        var evilFactory = new EvilFighterBuilderFactory();
        var combatFactory = new CombatAnalystBuilderFactory();
        var fisrtBoard = new CreatureBoard();
        ICreature strongCreature = evilFactory.CreateBuilder().Build();
        fisrtBoard.AddCreature(strongCreature);
        var secondBoard = new CreatureBoard();
        ICreature weakCreature = combatFactory.CreateBuilder().Build();
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
        var combatFactory = new CombatAnalystBuilderFactory();
        var evilFactory = new EvilFighterBuilderFactory();
        var fisrtBoard = new CreatureBoard();
        ICreature strongCreature = combatFactory.CreateBuilder().Build();
        fisrtBoard.AddCreature(strongCreature);
        var secondBoard = new CreatureBoard();
        ICreature weakCreature = evilFactory.CreateBuilder().Build();
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
        var factory = new CombatAnalystBuilderFactory();
        ICreature baseCreature = factory.CreateBuilder().Build();
        int startHp = baseCreature.HealthPoints.Value;
        var applier = new MagicShieldApplier();
        ICreature shieldCreature = applier.Apply(baseCreature);

        // Act
        shieldCreature.TakeDamage(new(3));
        int hpAfterFirstDamage = shieldCreature.HealthPoints.Value;
        shieldCreature.TakeDamage(new(3));
        int hpAfterSecondDamage = shieldCreature.HealthPoints.Value;

        // Assert
        Assert.Equal(startHp, hpAfterFirstDamage);
        Assert.Equal(hpAfterSecondDamage, startHp - 3);
    }

    [Fact]
    public void AttackSkill_ShouldIncreaseDamageComparedToBaseCreature()
    {
        // Arrange
        var combatFactory = new CombatAnalystBuilderFactory();
        var immortalFactory = new ImmortalHorrorBuilderFactory();
        ICreature baseAttacker = combatFactory.CreateBuilder().Build();
        ICreature targetWithoutBuff = immortalFactory.CreateBuilder().Build();
        ICreature targetWithBuff = immortalFactory.CreateBuilder().Build();
        int targetHp = targetWithoutBuff.HealthPoints.Value;
        var applier = new AttackSkillApplier();
        ICreature buffedAttacker =
            applier.Apply(combatFactory.CreateBuilder().Build());

        // Act
        baseAttacker.Attack(targetWithoutBuff);
        int hpAfterDamage = targetWithoutBuff.HealthPoints.Value;
        int baseDamage = targetHp - hpAfterDamage;

        buffedAttacker.Attack(targetWithBuff);
        int hpAfterBuffDamage = targetWithBuff.HealthPoints.Value;
        int buffedDamage = targetHp - hpAfterBuffDamage;

        // Assert
        Assert.True(buffedDamage > baseDamage);
    }

    [Fact]
    public void PowerSpell_ShouldIncreaseAttackByFive()
    {
        // Arrange
        var factory = new CombatAnalystBuilderFactory();
        ICreature baseCreature = factory.CreateBuilder().Build();
        int startAttack = baseCreature.AttackPoints.Value;
        int startHealth = baseCreature.HealthPoints.Value;
        PowerSpell spell = new();

        // Act
        ICreature result = spell.Cast(baseCreature);

        // Assert
        Assert.Equal(startAttack + 5, result.AttackPoints.Value);
        Assert.Equal(startHealth, result.HealthPoints.Value);
    }

    [Fact]
    public void StaminaSpell_ShouldIncreaseHealthByFive()
    {
        // Arrange
        var factory = new CombatAnalystBuilderFactory();
        ICreature baseCreature = factory.CreateBuilder().Build();
        int startAttack = baseCreature.AttackPoints.Value;
        int startHealth = baseCreature.HealthPoints.Value;
        StaminaSpell spell = new();

        // Act
        ICreature result = spell.Cast(baseCreature);

        // Assert
        Assert.Equal(startAttack, result.AttackPoints.Value);
        Assert.Equal(startHealth + 5, result.HealthPoints.Value);
    }

    [Fact]
    public void AmuletSpell_ShouldGiveMagicShield()
    {
        // Arrange
        var factory = new CombatAnalystBuilderFactory();
        ICreature baseCreature = factory.CreateBuilder().Build();
        int startHealth = baseCreature.HealthPoints.Value;
        AmuletProtectionSpell spell = new();

        // Act
        ICreature protectedCreature = spell.Cast(baseCreature);
        protectedCreature.TakeDamage(new(3));
        int healthAfterFirstDamage = protectedCreature.HealthPoints.Value;
        protectedCreature.TakeDamage(new(3));
        int healthAfterSecondDamage = protectedCreature.HealthPoints.Value;

        // Assert
        Assert.Equal(startHealth, healthAfterFirstDamage);
        Assert.Equal(healthAfterSecondDamage, startHealth - 3);
    }

    [Fact]
    public void CreatureWithMagicShieldAndAttackSkill_ShouldIgnoreFirstDamage_AndDealMoreDamage()
    {
        // Arrange
        var combatFactory = new CombatAnalystBuilderFactory();
        var immortalFactory = new ImmortalHorrorBuilderFactory();
        var magicApplier = new MagicShieldApplier();
        var attackApplier = new AttackSkillApplier();
        ICreature baseAttacker = combatFactory.CreateBuilder().Build();
        ICreature bufAttacker = magicApplier.Apply(baseAttacker);
        bufAttacker = attackApplier.Apply(bufAttacker);
        int bufStartHealth = bufAttacker.HealthPoints.Value;
        ICreature baseTarget = immortalFactory.CreateBuilder().Build();
        ICreature bufTarget = immortalFactory.CreateBuilder().Build();
        int targetStartHp = baseTarget.HealthPoints.Value;

        // Act
        bufAttacker.TakeDamage(new(2));
        int hpAfterFisrtDamage = bufAttacker.HealthPoints.Value;
        baseTarget.TakeDamage(new(2));
        int baseDamage = targetStartHp - baseTarget.HealthPoints.Value;
        baseAttacker.Attack(bufTarget);
        int bufDamage = targetStartHp - bufTarget.HealthPoints.Value;

        // Assert
        Assert.Equal(bufStartHealth, hpAfterFisrtDamage);
        Assert.True(bufDamage > baseDamage);
    }

    [Fact]
    public void CreatureClone_ShouldBeIndependentCopy()
    {
        // Arrange
        var factory = new CombatAnalystBuilderFactory();
        ICreature baseCreature = factory.CreateBuilder().Build();
        int baseHpStart = baseCreature.HealthPoints.Value;
        int baseAttackStart = baseCreature.AttackPoints.Value;

        // Act
        ICreature clone = baseCreature.Clone();
        clone.TakeDamage(new(3));

        // Assert
        Assert.Equal(baseHpStart, baseCreature.HealthPoints.Value);
        Assert.Equal(baseAttackStart, baseCreature.AttackPoints.Value);
        Assert.NotEqual(baseCreature.HealthPoints, clone.HealthPoints);
        Assert.False(ReferenceEquals(baseCreature, clone));
    }
}