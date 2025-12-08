using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public static class Program
{
    public static void Main()
    {
        var output = new ConsoleOutputWriter();
        var context = new FileSystemContext(new UnixPathService());
        var connectionStrategies = new List<IConnectionModeStrategy>
        {
            new LocalConnectionModeStrategy(new LocalFileSystemFactory()),
        };

        var fileOutputMode = new List<IFileOutputMode>
        {
            new ConsoleFileOutputMode(output),
        };

        IParser parser = CommandParserFactory.CreateParser(connectionStrategies, fileOutputMode, output);
        while (true)
        {
            string? line = Console.ReadLine();
            if (line == null) break;
            if (string.IsNullOrWhiteSpace(line)) continue;

            ICommand? command = parser.Parse(line);
            if (command is null)
            {
                output.Write("Unknown command");
                continue;
            }

            OperationResult result;
            try
            {
                result = command.Execute(context);
            }
            catch (Exception ex)
            {
                output.Write($"Error: {ex.Message}");
                continue;
            }

            switch (result)
            {
                case OperationResult.Succes: break;
                case OperationResult.Failure failure:
                    if (!string.IsNullOrWhiteSpace(failure.Message)) output.Write("Error " + failure.Message);
                    else output.Write("Command failed");
                    break;
            }
        }
    }
}