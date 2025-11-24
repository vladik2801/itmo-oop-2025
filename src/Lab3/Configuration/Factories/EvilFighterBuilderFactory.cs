using Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Factories;

public sealed class EvilFighterBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        AttackPoint attackPoint = new(1);
        HealthPoint healthPoint = new(6);
        return new EvilFighterBuilder().WithBaseStats(healthPoint, attackPoint);
    }
}