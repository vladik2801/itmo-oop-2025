using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public static class Program
{
    public static void Main()
    {
        Session session = new();
        Parser parser = new();
        ConsoleOutputWriter output = new();

        LocalFileSystemFactory lfsFactory = new();
        List<IConnectionModeStrategy> connectionStrategies = new();
        connectionStrategies.Add(new LocalConnectionModeStrategy(lfsFactory));

        List<IFileOutputMode> fileOutputModes = new();
        fileOutputModes.Add(new ConsoleFileOutputMode(output));

        List<ICommandFactory> factories = new();
        factories.Add(new ConnectCommandFactory(connectionStrategies));
        factories.Add(new DisconnectComandFactory());
        factories.Add(new TreeListCommandFactory(output));
        factories.Add(new TreeeGotoCommandFactory());
        factories.Add(new FileShowCommandFactory(fileOutputModes));
        factories.Add(new FileMoveCommandFactory());
        factories.Add(new FileRenameCommandFactory());
        factories.Add(new FileCopyCommandFactory());
        factories.Add(new FileDeleteCommandFactory());

        while (true)
        {
            string? line = Console.ReadLine();
            Console.WriteLine("You wrote: " + line);
            if (line == null) break;
            if (string.IsNullOrWhiteSpace(line)) continue;

            ParsedCommand? parsed = parser.Parse(line);
            if (parsed == null) continue;

            ICommandFactory? factory = null;
            foreach (ICommandFactory candidate in factories)
            {
                if (candidate.CanHandle(parsed))
                {
                    factory = candidate;
                    break;
                }
            }

            if (factory == null)
            {
                output.Write("Unknown command");
                continue;
            }

            ICommand command;
            try
            {
                command = factory.Create(parsed, session);
            }
            catch (Exception ex)
            {
                output.Write("Error creating command" + ex.Message);
                continue;
            }

            OperationResult result;
            try
            {
                result = command.Execute();
            }
            catch (Exception ex)
            {
                output.Write("Error executing command" + ex.Message);
                continue;
            }

            switch (result)
            {
                case OperationResult.Succes:
                    break;
                case OperationResult.Failure failure:
                    if (!string.IsNullOrEmpty(failure.Message))
                    {
                        output.Write("Error: " + failure.Message);
                    }
                    else
                    {
                        output.Write("Command failed");
                    }

                    break;
            }
        }
    }
}