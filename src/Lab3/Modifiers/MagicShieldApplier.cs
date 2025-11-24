using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class MagicShieldApplier : IModifierApplier
{
    public ICreature Apply(ICreature creature)
    {
        return new MagicShield(creature);
    }
}