using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class EvilFighter : ICreature
{
    public EvilFighter(HealthPoint healthPoints, AttackPoint attackPoints)
    {
        HealthPoints = healthPoints;
        AttackPoints = attackPoints;
    }

    public HealthPoint HealthPoints { get; private set; }

    public AttackPoint AttackPoints { get; private set; }

    public void Attack(ICreature creature)
    {
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
        HealthPoint newHealthPoint = new(HealthPoints.Value - damage.Value);
        if (HealthPoints.Value > 0)
        {
            AttackPoint newAttackPoint = new(AttackPoints.Value * 2);
            AttackPoints = newAttackPoint;
        }
    }

    public ICreature Clone()
    {
        return new EvilFighter(new(HealthPoints.Value), new(AttackPoints.Value));
    }
}