namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : ICommand
{
    private readonly Session _session;

    public DisconnectCommand(Session session)
    {
        _session = session;
    }

    public OperationResult Execute()
    {
        if (_session.FileSystem is null) return new OperationResult.Failure("File not found");
        _session.Disconnect();
        return new OperationResult.Succes();
    }
}