using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public abstract class CreatureBuilderBase : ICreatureBuilder
{
    private HealthPoint _healthPoint = new(1);
    private AttackPoint _attackPoint = new(1);

    public CreatureBuilderBase WithBaseStats(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        _healthPoint = healthPoint;
        _attackPoint = attackPoint;
        return this;
    }

    public ICreature Build()
    {
        return CreateCreature(_healthPoint, _attackPoint);
    }

    protected abstract ICreature CreateCreature(HealthPoint healthPoint, AttackPoint attackPoint);
}