using Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Factories;

public class ImmortalHorrorBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        AttackPoint attackPoint = new(4);
        HealthPoint healthPoint = new(4);
        return new ImmortalHorrorBuilder().WithBaseStats(healthPoint, attackPoint);
    }
}