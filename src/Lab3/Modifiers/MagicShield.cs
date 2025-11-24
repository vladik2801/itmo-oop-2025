using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public sealed class MagicShield : ICreature
{
    private readonly ICreature _creature;

    private bool _isUsed = false;

    public MagicShield(ICreature creature)
    {
        _creature = creature;
    }

    private MagicShield(ICreature creature, bool isUsed)
    {
        _creature = creature;
        _isUsed = isUsed;
    }

    public AttackPoint AttackPoints => _creature.AttackPoints;

    public HealthPoint HealthPoints => _creature.HealthPoints;

    public void Attack(ICreature creature)
    {
        _creature.Attack(creature);
    }

    public void ChangeAttackPoints(AttackPoint attackPoints)
    {
        _creature.ChangeAttackPoints(attackPoints);
    }

    public void ChangeHealthPoints(HealthPoint healthPoints)
    {
        _creature.ChangeHealthPoints(healthPoints);
    }

    public void TakeDamage(AttackPoint damage)
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
        return new MagicShield(newCreature, _isUsed);
    }
}