using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;

public sealed class MasterAmuletsBuilder : CreatureBuilderBase
{
    protected override ICreature CreateCreature(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        return new MasterAmulets(healthPoint, attackPoint);
    }
}