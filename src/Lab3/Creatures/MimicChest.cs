using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : ICreature
{
    public MimicChest(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        HealthPoints = healthPoint.Value;
        AttackPoints = attackPoint.Value;
    }

    public int HealthPoints { get; private set; }

    public int AttackPoints { get; private set; }

    public void Attack(ICreature creature)
    {
        HealthPoints = int.Max(HealthPoints, creature.HealthPoints);
        AttackPoints = int.Max(AttackPoints, creature.AttackPoints);
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
        return new MimicChest(new(HealthPoints), new(AttackPoints));
    }
}