using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public class ImmortalHorrorBuilder : ICreatureBuilder
{
    private HealthPoint _healthPoint = new HealthPoint(0);
    private AttackPoint _attackPoint = new AttackPoint(0);

    public ImmortalHorrorBuilder WithBaseStats(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        _healthPoint = healthPoint;
        _attackPoint = attackPoint;
        return this;
    }

    public ICreature Build()
    {
        return new ImmortalHorror(_healthPoint, _attackPoint);
    }
}