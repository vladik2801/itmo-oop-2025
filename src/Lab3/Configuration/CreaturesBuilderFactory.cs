namespace Itmo.ObjectOrientedProgramming.Lab3.Configuration;

public abstract class CreaturesBuilderFactory : ICreatureBuilderFactory
{
    public abstract ICreatureBuilder CreateCombatAnalystBuilder();

    public abstract ICreatureBuilder CreateEvilFighterBuilder();

    public abstract ICreatureBuilder CreateImmortalHorrorBuilder();

    public abstract ICreatureBuilder CreateMasterAmuletsBuilder();

    public abstract ICreatureBuilder CreateMimicChestBuilder();
}