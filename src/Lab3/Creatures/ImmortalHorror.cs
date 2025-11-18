using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ImmortalHorror : ICreature
{
    private bool _isReborn = false;

    public ImmortalHorror(HealthPoint healthPoint, AttackPoint attackPoint)
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
        if (HealthPoints <= 0 && !_isReborn)
        {
            _isReborn = true;
            HealthPoints = 1;
        }
    }

    public ICreature Clone()
    {
        return new ImmortalHorror(new(HealthPoints), new(AttackPoints));
    }
}