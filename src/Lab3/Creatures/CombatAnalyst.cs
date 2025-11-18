using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class CombatAnalyst : ICreature
{
    public CombatAnalyst(HealthPoint healthPoints, AttackPoint attackPoints)
    {
        HealthPoints = healthPoints.Value;
        AttackPoints = attackPoints.Value;
    }

    public int HealthPoints { get; private set; }

    public int AttackPoints { get; private set; }

    public void Attack(ICreature creature)
    {
        AttackPoints += 2;
        creature.TakeDamage(AttackPoints);
    }

    public void ChangeHealthPoints(int healthPoints)
    {
        HealthPoints = healthPoints;
    }

    public void ChangeAttackPoints(int attackPoints)
    {
        AttackPoints = attackPoints;
    }

    public void TakeDamage(int damage)
    {
        HealthPoints -= damage;
    }

    public ICreature Clone()
    {
        return new CombatAnalyst(new(HealthPoints), new(AttackPoints));
    }
}