using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public sealed class MasterAmulets : ICreature
{
    public MasterAmulets(HealthPoint healthPoint, AttackPoint attackPoint)
    {
        HealthPoints = healthPoint.Value;
        AttackPoints = attackPoint.Value;
    }

    public int HealthPoints { get; private set; }

    public int AttackPoints { get; private set; }

    public void Attack(ICreature creature)
    {
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
        if (HealthPoints > 0) AttackPoints *= 2;
    }

    public ICreature Clone()
    {
        return new MasterAmulets(new(HealthPoints), new(AttackPoints));
    }
}