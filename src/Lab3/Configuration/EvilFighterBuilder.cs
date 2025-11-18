using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public class EvilFighterBuilder : CreatureBuilderBase
{
    protected override ICreature CreateCreature(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        return new EvilFighter(healthPoint, attackPoint);
    }
}