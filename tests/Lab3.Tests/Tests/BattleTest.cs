using Itmo.ObjectOrientedProgramming.Lab3.Board;
using Itmo.ObjectOrientedProgramming.Lab3.Configuration;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.Tests;

public class BattleTest
{
    [Fact]
    public void Run_WhenFirstBoardHasStrongerCreature_ShouldReturnFirstPlayerWin()
    {
        // Arrange
        var factory = new CreaturesBuilderFactory();
        var fisrtBoard = new CreatureBoard();
        ICreature strongCreature = factory.CreateCombatAnalystBuilder().Build();
        fisrtBoard.AddCreature(strongCreature);
        var secondBoard = new CreatureBoard();
        ICreature weakCreature = factory.CreateEvilFighterBuilder().Build();
        secondBoard.AddCreature(weakCreature);
        var battle = new Battle(fisrtBoard, secondBoard);

        // Act
        ResultBattle result = battle.RunBattle();

        // Assert
        Assert.Equal(new ResultBattle.FirstWin(), result);
    }
}