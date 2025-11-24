using Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Factories;

public class MasterAmuletsBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        AttackPoint attackPoint = new(5);
        HealthPoint healthPoint = new(2);
        return new MasterAmuletsBuilder()
            .WithModifier(new MagicShieldApplier()).WithModifier(new AttackSkillApplier()).WithBaseStats(healthPoint, attackPoint);
    }
}