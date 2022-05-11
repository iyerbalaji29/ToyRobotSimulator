using System.ComponentModel.DataAnnotations;

namespace ToyRobot.Shared;

public enum Direction
{
    [Display(Name="NONE")]
    None,
    [Display(Name="WEST")]
    West,
    [Display(Name="NORTH")]
    North,
    [Display(Name="EAST")]
    East,
    [Display(Name="SOUTH")]
    South
}