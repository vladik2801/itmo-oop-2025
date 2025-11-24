using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class PowerSpell : ISpell
{
    private readonly int _attackBonus = 5;

    public ICreature Cast(ICreature target)
    {
        AttackPoint attackPoint = new(target.AttackPoints.Value + _attackBonus);
        target.ChangeAttackPoints(attackPoint);
        return target;
    }
}