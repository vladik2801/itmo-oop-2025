using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public class CombatAnalystBuilder : CreatureBuilderBase
{
    protected override ICreature CreateCreature(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        return new CombatAnalyst(healthPoint, attackPoint);
    }
}