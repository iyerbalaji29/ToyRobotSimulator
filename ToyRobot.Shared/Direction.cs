using System.ComponentModel.DataAnnotations;

namespace ToyRobot.Shared;

public enum Direction
{
    [Display(Name="EAST")]
    East,
    [Display(Name="WEST")]
    West,
    [Display(Name="NORTH")]
    North,
    [Display(Name="SOUTH")]
    South
}