using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public interface IModifierApplier
{
    ICreature Apply(ICreature creature);
}