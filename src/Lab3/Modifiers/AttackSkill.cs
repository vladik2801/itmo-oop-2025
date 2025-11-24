using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class AttackSkill : ICreature
{
    private readonly ICreature _creature;

    public AttackSkill(ICreature creature)
    {
        _creature = creature;
    }

    public HealthPoint HealthPoints => _creature.HealthPoints;

    public AttackPoint AttackPoints => _creature.AttackPoints;

    public void Attack(ICreature creature)
    {
        _creature.Attack(creature);
        if (creature.HealthPoints.Value > 0) _creature.Attack(creature);
    }

    public void TakeDamage(AttackPoint damage)
    {
        _creature.TakeDamage(damage);
    }

    public void ChangeAttackPoints(AttackPoint attackPoints)
    {
        _creature.ChangeAttackPoints(attackPoints);
    }

    public void ChangeHealthPoints(HealthPoint healthPoints)
    {
        _creature.ChangeHealthPoints(healthPoints);
    }

    public ICreature Clone()
    {
        ICreature newCreature = _creature.Clone();
        return new AttackSkill(newCreature);
    }
}