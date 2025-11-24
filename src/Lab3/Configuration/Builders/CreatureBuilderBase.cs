using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;

public abstract class CreatureBuilderBase : ICreatureBuilder
{
    private readonly List<IModifierApplier> _modifiers = new();
    private HealthPoint? _healthPoint;
    private AttackPoint? _attackPoint;

    public CreatureBuilderBase WithBaseStats(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        _healthPoint = healthPoint;
        _attackPoint = attackPoint;
        return this;
    }

    public CreatureBuilderBase WithModifier(IModifierApplier modifier)
    {
        _modifiers.Add(modifier);
        return this;
    }

    public ICreature Build()
    {
        if (_healthPoint is null || _attackPoint is null) throw new NullReferenceException("Stats should not be null");
        ICreature creature = CreateCreature(_healthPoint, _attackPoint);
        foreach (IModifierApplier modifier in _modifiers)
        {
            creature = modifier.Apply(creature);
        }

        return creature;
    }

    protected abstract ICreature CreateCreature(HealthPoint healthPoint, AttackPoint attackPoint);
}