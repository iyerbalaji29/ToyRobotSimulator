using System.ComponentModel.DataAnnotations;

namespace ToyRobot.Shared;

public enum Direction
{
    [Display(Name="Left")]
    Left,
    [Display(Name="Right")]
    Right,
    [Display(Name="North")]
    North,
    [Display(Name="South")]
    South
}