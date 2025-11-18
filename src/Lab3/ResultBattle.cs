namespace Itmo.ObjectOrientedProgramming.Lab3;

public abstract record ResultBattle
{
    private ResultBattle() { }

    public sealed record FirstWin : ResultBattle;

    public sealed record SecondWin : ResultBattle;

    public sealed record Draw : ResultBattle;
}