using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class MasterAmulets : ICreature
{
    public MasterAmulets(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        HealthPoints = healthPoint;
        AttackPoints = attackPoint;
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
        HealthPoint newHealthPoints = new(HealthPoints.Value - damage.Value);
        HealthPoints = newHealthPoints;
    }

    public ICreature Clone()
    {
        return new MasterAmulets(new(HealthPoints.Value), new(AttackPoints.Value));
    }
}