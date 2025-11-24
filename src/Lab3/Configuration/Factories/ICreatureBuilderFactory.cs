using Itmo.ObjectOrientedProgramming.Lab3.Configuration.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration.Factories;

public interface ICreatureBuilderFactory
{
    ICreatureBuilder CreateBuilder();
}