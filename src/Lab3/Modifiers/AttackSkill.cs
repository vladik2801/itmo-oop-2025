using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class AttackSkill : ICreature
{
    private readonly ICreature _creature;

    public AttackSkill(ICreature creature)
    {
        _creature = creature;
    }

    public int HealthPoints => _creature.HealthPoints;

    public int AttackPoints => _creature.AttackPoints;

    public void Attack(ICreature creature)
    {
        _creature.Attack(creature);
        if (creature.HealthPoints > 0) _creature.Attack(creature);
    }

    public void TakeDamage(int damage)
    {
        _creature.TakeDamage(damage);
    }

    public void ChangeAttackPoints(int attackPoints)
    {
        _creature.ChangeAttackPoints(attackPoints);
    }

    public void ChangeHealthPoints(int healthPoints)
    {
        _creature.ChangeHealthPoints(healthPoints);
    }

    public ICreature Clone()
    {
        ICreature newCreature = _creature.Clone();
        return new AttackSkill(newCreature);
    }
}