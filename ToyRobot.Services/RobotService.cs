using Microsoft.Extensions.Logging;
using ToyRobot.Services.Helpers;
using ToyRobot.Shared;

namespace ToyRobot.Services;

public class RobotService : IRobotService
{
    private readonly ILogger<RobotService> _logger;
    private readonly TableTop _table;
    private Robot _toyRobot;
    public RobotService(ILogger<RobotService> logger, IRobot toyRobot)
    {
        _logger = logger;
        _table = new TableTop(6, 6);
        _toyRobot = new Robot();
    }

    public Robot Process(string input)
    {
        if (InputCommandHelper.IsValid(input))
        {
            var command = InputCommandHelper.ParseCommand(input);
            _toyRobot = Process(command);
            return _toyRobot;
        }

        Console.WriteLine("Invalid robot action entered. Please try again");
        return _toyRobot;
    }

    private Robot Process(Command command)
    {
        switch (command.Action)
        {
            case RobotAction.Place:
                var isValidPosition = _table.IsValid(command.PositionX, command.PositionY);
                var direction = command.Direction == Direction.None 
                    ? _toyRobot.Direction != Direction.None ? _toyRobot.Direction : Direction.None 
                    : command.Direction;
                if (isValidPosition && direction != Direction.None)
                {
                    _toyRobot.Place(command.PositionX,command.PositionY,direction);
                }
                else
                {
                    _toyRobot.IsPlaced = false;
                }
                break;
            case RobotAction.Left:
                if (_toyRobot.IsPlaced)
                {
                    _toyRobot.RotateLeft();
                }
                break;
            case RobotAction.Right:
                if (_toyRobot.IsPlaced)
                {
                    _toyRobot.RotateRight();
                }
                break;
            case RobotAction.Move:
                if (_toyRobot.IsPlaced)
                {
                    var (x, y) = _toyRobot.GetNextPosition();
                    if (_table.IsValid(x, y))
                    {
                        _toyRobot.PositionX = x;
                        _toyRobot.PositionY = y;
                    }
                    else
                    {
                        _toyRobot.IsPlaced = false;
                        _logger.LogInformation($"Robot could not be moved to this position of the table {x}, {y}");
                        Console.WriteLine($"Robot could not be moved to this position of the table {x}, {y}");
                    }
                }
                break;
            case RobotAction.Report:
                if (_toyRobot.IsPlaced)
                {
                    Console.WriteLine(_toyRobot.GetReport());
                }
                break;
            
            case RobotAction.None:
            default:
                _logger.LogInformation($"Action could not be taken");
                Console.WriteLine($"Action could not be taken");
                return _toyRobot;
        }
        return _toyRobot;
    }
}