using System.ComponentModel.DataAnnotations;

namespace ToyRobot.Shared;

public class Command
{
    public int PositionX { get; set; } = 0;

    public int PositionY { get; set; } = 0;

    public RobotAction Action { get; set; }

    public Direction Direction { get; set; }
}