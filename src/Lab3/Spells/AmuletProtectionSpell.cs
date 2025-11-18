using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public sealed class AmuletProtectionSpell : ISpell
{
    private readonly ModifierApplier _applier = new();

    public ICreature Cast(ICreature target)
    {
        return _applier.Apply(target, ModifiersType.MagicShield);
    }
}