namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature : IPrototype<ICreature>
{
    int HealthPoints { get; }

    int AttackPoints { get; }

    void TakeDamage(int damage);

    void Attack(ICreature creature);

    void ChangeHealthPoints(int healthPoints);

    void ChangeAttackPoints(int attackPoints);
}