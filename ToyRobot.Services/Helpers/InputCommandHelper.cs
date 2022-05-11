using System.Globalization;
using ToyRobot.Shared;
using ToyRobot.Shared.Utils;

namespace ToyRobot.Services.Helpers;

public static class InputCommandHelper
{
    static TextInfo titleCase = CultureInfo.CurrentCulture.TextInfo;//used to convert to title case for input command
    public static bool IsValid(string input)
    {
        var inputCommands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        if (inputCommands.Length == 0 || inputCommands.Length > 2)
            return false;
        
        if (inputCommands.Length > 1)
        {
            var positions = inputCommands[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (string.Equals(inputCommands.FirstOrDefault(), RobotAction.Place.GetDisplayName(),
                    StringComparison.OrdinalIgnoreCase))
            {
                if (positions.Length > 3)
                    return false;
            }
        }

         //used to convert to title case for input command
        return Enum.IsDefined(typeof(RobotAction), titleCase.ToTitleCase(inputCommands[0].ToLower()));
    }

    public static Command ParseCommand(string input)
    {
        var command = new Command();
        var inputCommands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (inputCommands.Length > 2)
            return command;

        if (Enum.TryParse<RobotAction>(titleCase.ToTitleCase(inputCommands[0].ToLower()), out var parsedAction))
        {
            command.Action = parsedAction;
        }

        if (inputCommands.Length > 1)
        {
            //Get Co-ordinates from the input string
            (command.PositionX, command.PositionY) = GetCoordinates(inputCommands[1], command);
            if (inputCommands.Length == 2)
            {
                command.Direction = GetDirection(inputCommands[1]);
            }
        }

        return command;
    }

    private static Direction GetDirection(string input)
    {
        var splitStringForDirection = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
        if (splitStringForDirection.Length != 3)
            return Direction.None;
                
        //Get direction from input sring
        if (Enum.TryParse<Direction>(titleCase.ToTitleCase(splitStringForDirection[2].ToLower()), out var parsedDirection))
        {
            return parsedDirection;
        }

        return Direction.None;
    }

    private static (int, int) GetCoordinates(string coordinates, Command command)
    {
        var positions = coordinates.Split(',', StringSplitOptions.RemoveEmptyEntries);
        return (Convert.ToInt32(positions[0]), Convert.ToInt32(positions[1]));
    }
}