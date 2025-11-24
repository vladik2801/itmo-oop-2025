using Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature : IPrototype<ICreature>
{
    HealthPoint HealthPoints { get; }

    AttackPoint AttackPoints { get; }

    void TakeDamage(AttackPoint damage);

    void Attack(ICreature creature);

    void ChangeHealthPoints(HealthPoint healthPoints);

    void ChangeAttackPoints(AttackPoint attackPoints);
}