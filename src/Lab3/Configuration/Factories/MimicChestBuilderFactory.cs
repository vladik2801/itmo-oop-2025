using Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Factories;

public class MimicChestBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        AttackPoint attackPoint = new(1);
        HealthPoint healthPoint = new(1);
        return new MimicChestBuilder().WithBaseStats(healthPoint, attackPoint);
    }
}