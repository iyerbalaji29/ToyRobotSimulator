using Microsoft.Extensions.Logging;
using ToyRobot.Shared;
using ToyRobot.Shared.Extensions;

namespace ToyRobotEngine;

public class RobotService
{
    private readonly ILogger _logger;
    public RobotService(ILogger<RobotService> logger)
    {
        _logger = logger;
    }

    public bool RunCommand(Direction direction, int x = 0, int y = 0)
    {
        switch (direction)
        {
            case Direction.Left:
                break;
            case Direction.Right:
                break;
            case Direction.North:
                break;
            case Direction.South:
                break;
            default:
                _logger.LogInformation($"Command could not be parsed based on input direction {direction.GetDisplayName()}");
                Console.WriteLine($"Robot could not be moved");
                return false;
        }
        
        _logger.LogInformation($"Robot moving in {direction.GetDisplayName()} direction");

        return true;
    }
}