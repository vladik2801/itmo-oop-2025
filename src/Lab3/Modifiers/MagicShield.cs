using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class MagicShield : ICreature
{
    private readonly ICreature _creature;

    private bool _isUsed = false;

    public MagicShield(ICreature creature)
    {
        _creature = creature;
    }

    public int AttackPoints => _creature.AttackPoints;

    public int HealthPoints => _creature.HealthPoints;

    public void Attack(ICreature creature)
    {
        _creature.Attack(creature);
    }

    public void ChangeAttackPoints(int attackPoints)
    {
        _creature.ChangeAttackPoints(attackPoints);
    }

    public void ChangeHealthPoints(int healthPoints)
    {
        _creature.ChangeHealthPoints(healthPoints);
    }

    public void TakeDamage(int damage)
    {
        if (!_isUsed)
        {
            _isUsed = true;
        }
        else
        {
            _creature.TakeDamage(damage);
        }
    }

    public ICreature Clone()
    {
        ICreature newCreature = _creature.Clone();
        return new MagicShield(newCreature);
    }
}