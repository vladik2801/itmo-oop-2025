using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;

public interface ICreatureBuilder
{
    ICreature Build();
}