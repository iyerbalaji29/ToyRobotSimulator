using System.Globalization;

namespace ToyRobot.Shared.Utils;

public static class InputCommandHelper
{
    public static bool IsValid(string input)
    {
        var inputCommands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (inputCommands.Length > 3)
            return false;

        var positions = inputCommands[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
        if (string.Equals(inputCommands.FirstOrDefault(), RobotAction.Place.GetDisplayName(),
                StringComparison.OrdinalIgnoreCase))
        {
            if (positions.Length != 2)
                return false;
        }
        
        var titleCase = CultureInfo.CurrentCulture.TextInfo;
        
        return Enum.IsDefined(typeof(RobotAction), titleCase.ToTitleCase(inputCommands[0].ToLower()));
    }

    public static Command ParseCommand(string input)
    {
        var command = new Command();
        var inputCommands = input.Split(' ');
        if (inputCommands.Length > 3)
            return command;
        
        var positions = inputCommands[1].Split(',');
        if (Enum.TryParse<RobotAction>(inputCommands[0], out var parsedAction))
        {
            command.Action = parsedAction;
        }

        command.PositionX = Convert.ToInt32(positions[0]);
        command.PositionY = Convert.ToInt32(positions[1]);
        if (Enum.TryParse<Direction>(inputCommands[2], out var parsedDirection))
        {
            command.Direction = parsedDirection;
        }

        return command;
    }
}