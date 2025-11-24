using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class MagicMirrorSpell : ISpell
{
    public ICreature Cast(ICreature target)
    {
        HealthPoint newHealth = new(target.AttackPoints.Value);
        AttackPoint newAttack = new(target.HealthPoints.Value);
        target.ChangeAttackPoints(newAttack);
        target.ChangeHealthPoints(newHealth);
        return target;
    }
}