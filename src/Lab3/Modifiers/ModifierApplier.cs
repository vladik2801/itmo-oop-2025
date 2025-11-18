using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class ModifierApplier
{
    public ICreature Apply(ICreature creature, ModifiersType type)
    {
        return type switch
        {
            ModifiersType.MagicShield => new MagicShield(creature),
            ModifiersType.AttackSkill => new AttackSkill(creature),
            _ => creature,
        };
    }
}