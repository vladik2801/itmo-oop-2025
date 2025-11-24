using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ImmortalHorror : ICreature
{
    private bool _isReborn = false;

    public ImmortalHorror(HealthPoint healthPoint, AttackPoint attackPoint)
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
        if (HealthPoints.Value <= 0 && !_isReborn)
        {
            _isReborn = true;
            HealthPoints = new(1);
        }
    }

    public ICreature Clone()
    {
        return new ImmortalHorror(new(HealthPoints.Value), new(AttackPoints.Value));
    }
}