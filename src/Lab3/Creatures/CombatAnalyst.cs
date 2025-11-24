using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class CombatAnalyst : ICreature
{
    public CombatAnalyst(HealthPoint healthPoints, AttackPoint attackPoints)
    {
        HealthPoints = healthPoints;
        AttackPoints = attackPoints;
    }

    public HealthPoint HealthPoints { get; private set; }

    public AttackPoint AttackPoints { get; private set; }

    public void Attack(ICreature creature)
    {
        AttackPoint newAttack = new(AttackPoints.Value + 2);
        AttackPoints = newAttack;
        creature.TakeDamage(AttackPoints);
    }

    public void ChangeHealthPoints(HealthPoint healthPoints)
    {
        HealthPoints = healthPoints;
    }

    public void ChangeAttackPoints(AttackPoint attackPoints)
    {
        AttackPoints = attackPoints;
    }

    public void TakeDamage(AttackPoint damage)
    {
        HealthPoint newHealthPoints = new(HealthPoints.Value - damage.Value);
        HealthPoints = newHealthPoints;
    }

    public ICreature Clone()
    {
        return new CombatAnalyst(new(HealthPoints.Value), new(AttackPoints.Value));
    }
}