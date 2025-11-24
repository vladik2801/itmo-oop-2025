using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackSkillApplier : IModifierApplier
{
    public ICreature Apply(ICreature creature)
    {
        return new AttackSkill(creature);
    }
}