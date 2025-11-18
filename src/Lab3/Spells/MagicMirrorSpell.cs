using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class MagicMirrorSpell : ISpell
{
    public ICreature Cast(ICreature target)
    {
        int oldAttack = target.AttackPoints;
        int oldHealth = target.HealthPoints;
        target.ChangeAttackPoints(oldHealth);
        target.ChangeHealthPoints(oldAttack);
        return target;
    }
}