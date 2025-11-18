using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public class CreaturesBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateCombatAnalystBuilder()
    {
        AttackPoint attackPoint = new(2);
        HealthPoint healthPoint = new(4);
        return new CombatAnalystBuilder().WithBaseStats(healthPoint, attackPoint);
    }

    public ICreatureBuilder CreateEvilFighterBuilder()
    {
        AttackPoint attackPoint = new(1);
        HealthPoint healthPoint = new(6);
        return new MasterAmuletsBuilder().WithBaseStats(healthPoint, attackPoint);
    }

    public ICreatureBuilder CreateImmortalHorrorBuilder()
    {
        AttackPoint attackPoint = new(4);
        HealthPoint healthPoint = new(4);
        return new ImmortalHorrorBuilder().WithBaseStats(healthPoint, attackPoint);
    }

    public ICreatureBuilder CreateMimicChestBuilder()
    {
        AttackPoint attackPoint = new(1);
        HealthPoint healthPoint = new(1);
        return new MimicChestBuilder().WithBaseStats(healthPoint, attackPoint);
    }

    public ICreatureBuilder CreateMasterAmuletsBuilder()
    {
        AttackPoint attackPoint = new(5);
        HealthPoint healthPoint = new(2);
        return new MasterAmuletsBuilder().WithBaseStats(healthPoint, attackPoint).WithMagicShield().WithAttackSkill();
    }
}