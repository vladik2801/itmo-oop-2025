using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Board;

public sealed class Battle
{
    private readonly CreatureBoard _firstBoard;
    private readonly CreatureBoard _secondBoard;

    public Battle(CreatureBoard firstBoard, CreatureBoard secondBoard)
    {
        _firstBoard = firstBoard.Clone();
        _secondBoard = secondBoard.Clone();
    }

    public ResultBattle RunBattle()
    {
        bool isFirstPlayerStep = true;
        while (true)
        {
            CreatureBoard basePlayer = isFirstPlayerStep ? _firstBoard : _secondBoard;
            CreatureBoard otherPlayer = isFirstPlayerStep ? _secondBoard : _firstBoard;
            ICreature? attacker = basePlayer.GetAttackerCreature();
            ICreature? defender = otherPlayer.GetDefenderCreature();

            if (attacker is null && defender is null) return new ResultBattle.Draw();
            if (attacker is null)
            {
                isFirstPlayerStep = !isFirstPlayerStep;
                continue;
            }

            if (defender is null)
            {
                return isFirstPlayerStep ? new ResultBattle.FirstWin() : new ResultBattle.SecondWin();
            }

            attacker.Attack(defender);
            isFirstPlayerStep = !isFirstPlayerStep;
        }
    }
}