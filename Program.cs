// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ToyRobot.Shared;
using ToyRobot.Shared.Utils;
using ToyRobotEngine;


string? input;
bool close = false;

do
{
    Console.WriteLine("Hello, This is a Toy Command Simulator!");
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
        Console.WriteLine("No command entered. Command shutting down");
        return;
    }

    if (string.Equals(input, RobotAction.Exit.GetDisplayName(), StringComparison.OrdinalIgnoreCase))
    {
        close = true;
        Environment.Exit(0);
        return;
    }
    
    var engine = new RobotService(new Logger<IRobotService>(new NullLoggerFactory()));
    var commandResult = engine.Process(input);
    if (commandResult)
    {
        Console.WriteLine("RobotAction executed!");
    }
    else
    {
        Console.WriteLine("Invalid command entered. Please try again");
        return;
    }

} while (close == false);
