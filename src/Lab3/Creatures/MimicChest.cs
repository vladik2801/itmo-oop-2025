using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : ICreature
{
    public MimicChest(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        HealthPoints = healthPoint;
        AttackPoints = attackPoint;
    }

    public HealthPoint HealthPoints { get; private set; }

    public AttackPoint AttackPoints { get; private set; }

    public void Attack(ICreature creature)
    {
        HealthPoints = new(int.Max(HealthPoints.Value, creature.HealthPoints.Value));
        AttackPoints = new(int.Max(AttackPoints.Value, creature.AttackPoints.Value));
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
        HealthPoints = new(HealthPoints.Value - damage.Value);
    }

    public ICreature Clone()
    {
        return new MimicChest(new(HealthPoints.Value), new(AttackPoints.Value));
    }
}