using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public sealed class DefaultCreatureBuilderFactory : CreaturesBuilderFactory
{
    private readonly IModifierApplier _magicShieldApplier = new MagicShieldApplier();
    private readonly IModifierApplier _attackSkillApplier = new AttackSkillApplier();

    public override ICreatureBuilder CreateCombatAnalystBuilder()
    {
        AttackPoint attackPoint = new(2);
        HealthPoint healthPoint = new(4);
        return new CombatAnalystBuilder().WithBaseStats(healthPoint, attackPoint);
    }

    public override ICreatureBuilder CreateEvilFighterBuilder()
    {
        AttackPoint attackPoint = new(1);
        HealthPoint healthPoint = new(6);
        return new EvilFighterBuilder().WithBaseStats(healthPoint, attackPoint);
    }

    public override ICreatureBuilder CreateImmortalHorrorBuilder()
    {
        AttackPoint attackPoint = new(4);
        HealthPoint healthPoint = new(4);
        return new ImmortalHorrorBuilder().WithBaseStats(healthPoint, attackPoint);
    }

    public override ICreatureBuilder CreateMimicChestBuilder()
    {
        AttackPoint attackPoint = new(1);
        HealthPoint healthPoint = new(1);
        return new MimicChestBuilder().WithBaseStats(healthPoint, attackPoint);
    }

    public override ICreatureBuilder CreateMasterAmuletsBuilder()
    {
        AttackPoint attackPoint = new(5);
        HealthPoint healthPoint = new(2);
        return new MasterAmuletsBuilder()
            .WithModifier(_magicShieldApplier).WithModifier(_attackSkillApplier).WithBaseStats(healthPoint, attackPoint);
    }
}