// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ToyRobot.Services;
using ToyRobot.Shared;
using ToyRobot.Shared.Utils;

bool close = false;

Console.WriteLine("Hello, This is a Toy Command Simulator!");
Console.WriteLine($"This will take following commands as input:{Environment.NewLine}" +
                  $" - PLACE X, Y, DIRECTION{Environment.NewLine}" +
                  $" - MOVE{Environment.NewLine}" +
                  $" - LEFT{Environment.NewLine}" +
                  $" - RIGHT{Environment.NewLine}" +
                  $" - REPORT{Environment.NewLine}" +
                  $" - EXIT{Environment.NewLine}");
Console.WriteLine("===========================================================================");
var robot = new Robot();
var engine = new RobotService(new Logger<RobotService>(new NullLoggerFactory()),robot);

while (close == false)
{
    var input = Console.ReadLine();

    if (string.Equals(input, RobotAction.Exit.GetDisplayName(), StringComparison.OrdinalIgnoreCase))
    {
        close = true;
        Environment.Exit(0);
        return;
    }

    if (input != null)
    {
        robot = engine.Process(input);
    }
}
