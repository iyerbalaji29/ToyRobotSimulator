// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ToyRobot.Shared;
using ToyRobotEngine;


string? input;
bool close = false;

do
{
    Console.WriteLine("Hello, This is a Toy Robot Simulator!");
    Console.WriteLine($"This will take following commands as input:{Environment.NewLine}" +
                      $" - PLACE X, Y, DIRECTION{Environment.NewLine}" +
                      $" - MOVE{Environment.NewLine}" +
                      $" - LEFT{Environment.NewLine}" +
                      $" - RIGHT{Environment.NewLine}" +
                      $" - REPORT{Environment.NewLine}" +
                      $" - EXIT{Environment.NewLine}");
    Console.WriteLine("===========================================================================");

    input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("No command entered. Robot shutting down");
        return;
    }

    if (string.Equals(input, Command.Exit, StringComparison.OrdinalIgnoreCase))
    {
        close = true;
        Environment.Exit(0);
        return;
    }

    var engine = new RobotService(new Logger<RobotService>(new NullLoggerFactory()));
    var commandResult = engine.RunCommand(Direction.Left);
    if (commandResult)
        Console.WriteLine("Command executed!");

} while (close == false);
