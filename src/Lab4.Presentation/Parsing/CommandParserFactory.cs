using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public static class CommandParserFactory
{
    public static IParser CreateParser(
        IReadOnlyCollection<IConnectionModeStrategy> connectionModeStrategies,
        IReadOnlyCollection<IFileOutputMode> fileOutputModes,
        IOutputWriter outputWriter)
    {
        ConnectCommandParseLink connectLink = new(connectionModeStrategies);
        ICommandParseLink disconnectLink = new DisconnectParseLink();
        ICommandParseLink treeListLink = new TreeListParserLink(outputWriter);
        ICommandParseLink treeGotoLink = new TreeGotoParseLink();
        ICommandParseLink fileShowLink = new FileShowParseLink(fileOutputModes);
        ICommandParseLink fileMoveLink = new FileMoveParseLink();
        ICommandParseLink fileCopyLink = new FileCopyParseLink();
        ICommandParseLink fileDeleteLink = new FileDeleteParseLink();
        ICommandParseLink fileRenameLink = new FileRenameParseLink();

        connectLink
            .AddNext(disconnectLink)
            .AddNext(treeListLink)
            .AddNext(treeGotoLink)
            .AddNext(fileShowLink)
            .AddNext(fileMoveLink)
            .AddNext(fileCopyLink)
            .AddNext(fileDeleteLink)
            .AddNext(fileRenameLink);
        return new Parser(connectLink);
    }
}