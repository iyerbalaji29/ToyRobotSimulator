using Microsoft.Extensions.Logging;
using ToyRobot.Shared;
using ToyRobot.Shared.Utils;
using Robot = ToyRobot.Shared.ToyRobot;

namespace ToyRobotEngine;

public class RobotService : IRobotService
{
    private readonly ILogger _logger;
    private Command _command;
    private readonly TableTop _table;
    private readonly Robot _robot;
    public RobotService(ILogger logger)
    {
        _logger = logger;
        _command = new Command();
        _table = new TableTop(6, 6);
        _robot = new Robot();
    }

    public bool Process(string input)
    {
        if (InputCommandHelper.IsValid(input))
        {
            var command = InputCommandHelper.ParseCommand(input);
            var result = Process(command);
            
            return true;
        }

        Console.WriteLine("Invalid robotAction entered. Please try again");
        return false;
    }

    private Robot Process(Command command)
    {
        switch (command.Action)
        {
            case RobotAction.Place:
                var isValidPosition = _table.IsValid(command.PositionX, command.PositionY);
                if (isValidPosition)
                {
                    _robot.Place(command.PositionX,command.PositionY,command.Direction);
                }
                break;
            case RobotAction.Left:
                _robot.RotateLeft();
                break;
            case RobotAction.Right:
                _robot.RotateRight();
                break;
            case RobotAction.Move:
                var (x,y) = _robot.GetNextPosition();
                if (_table.IsValid(x, y))
                {
                    _robot.PositionX = x;
                    _robot.PositionY = y;
                }
                _logger.LogInformation($"Robot could not be moved to this position as its end of the table {x}, {y}");
                Console.WriteLine($"Robot could not be moved to this position as its end of the table");
                break;
            case RobotAction.Report:
                _robot.Report = _robot.GetReport();
                break;
            
            default:
                _logger.LogInformation($"Action could not be parsed based on input {command.Action.GetDisplayName()}");
                Console.WriteLine($"Command could not be moved");
                return _robot;
        }
        return _robot;
    }
}