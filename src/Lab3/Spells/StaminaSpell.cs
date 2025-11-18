using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class StaminaSpell : ISpell
{
    private readonly int _healthBonus = 5;

    public ICreature Cast(ICreature target)
    {
        target.ChangeHealthPoints(target.HealthPoints + _healthBonus);
        return target;
    }
}