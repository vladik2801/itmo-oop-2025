using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;

public class MimicChestBuilder : CreatureBuilderBase
{
    protected override ICreature CreateCreature(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        return new MimicChest(healthPoint, attackPoint);
    }
}