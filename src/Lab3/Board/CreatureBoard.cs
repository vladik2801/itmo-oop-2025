using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Board;

public class CreatureBoard : IPrototype<CreatureBoard>
{
    private readonly int _maxSize = 7;

    private readonly List<ICreature> _creatures = new();

    public void AddCreature(ICreature creature)
    {
        if (_creatures.Count >= _maxSize) throw new Exception("Board limit is 7 creatures");
        _creatures.Add(creature);
    }

    public ICreature? GetAttackerCreature()
    {
        foreach (ICreature creature in _creatures)
        {
            if (creature.HealthPoints > 0 && creature.AttackPoints > 0)
            {
                return creature;
            }
        }

        return null;
    }

    public ICreature? GetDefenderCreature()
    {
        foreach (ICreature creature in _creatures)
        {
            if (creature.HealthPoints > 0)
            {
                return creature;
            }
        }

        return null;
    }

    public CreatureBoard Clone()
    {
        var board = new CreatureBoard();

        foreach (ICreature creature in _creatures)
        {
            board.AddCreature(creature.Clone());
        }

        return board;
    }
}