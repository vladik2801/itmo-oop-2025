namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public interface ICreatureBuilderFactory
{
    ICreatureBuilder CreateCombatAnalystBuilder();

    ICreatureBuilder CreateEvilFighterBuilder();

    ICreatureBuilder CreateImmortalHorrorBuilder();

    ICreatureBuilder CreateMasterAmuletsBuilder();

    ICreatureBuilder CreateMimicChestBuilder();
}