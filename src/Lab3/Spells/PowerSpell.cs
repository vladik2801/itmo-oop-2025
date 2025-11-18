using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class PowerSpell : ISpell
{
    private readonly int _attackBonus = 5;

    public ICreature Cast(ICreature target)
    {
        target.ChangeAttackPoints(target.AttackPoints + _attackBonus);
        return target;
    }
}