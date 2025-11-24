using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class StaminaSpell : ISpell
{
    private readonly int _healthBonus = 5;

    public ICreature Cast(ICreature target)
    {
        HealthPoint newHealth = new(target.HealthPoints.Value + _healthBonus);
        target.ChangeHealthPoints(newHealth);
        return target;
    }
}