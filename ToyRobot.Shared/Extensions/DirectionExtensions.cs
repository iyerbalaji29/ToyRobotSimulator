using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ToyRobot.Shared.Extensions;

public static class DirectionExtensions
{
    public static string? GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()?
            .GetMember(enumValue.ToString())?
            .First()?
            .GetCustomAttribute<DisplayAttribute>()?
            .Name;
    }
}