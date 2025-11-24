using Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Factories;

public sealed class CombatAnalystBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        AttackPoint attackPoint = new(2);
        HealthPoint healthPoint = new(4);
        return new CombatAnalystBuilder().WithBaseStats(healthPoint, attackPoint);
    }
}