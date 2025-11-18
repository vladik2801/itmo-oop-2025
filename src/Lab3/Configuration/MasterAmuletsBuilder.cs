using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public sealed class MasterAmuletsBuilder : CreatureBuilderBase
{
    private readonly ModifierApplier _modifierApplier;

    public MasterAmuletsBuilder(ModifierApplier modifierApplier)
    {
        _modifierApplier = modifierApplier;
    }

    protected override ICreature CreateCreature(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        ICreature creature = new MasterAmulets(healthPoint, attackPoint);
        creature = _modifierApplier.Apply(creature, ModifiersType.MagicShield);
        creature = _modifierApplier.Apply(creature, ModifiersType.AttackSkill);
        return creature;
    }
}