using System.ComponentModel.DataAnnotations;

namespace ToyRobot.Shared;

public enum RobotAction
{
    [Display(Name="PLACE")]
    Place,
    [Display(Name="MOVE")]
    Move,
    [Display(Name="LEFT")]
    Left,
    [Display(Name="RIGHT")]
    Right,
    [Display(Name="REPORT")]
    Report,
    [Display(Name="EXIT")]
    Exit
}