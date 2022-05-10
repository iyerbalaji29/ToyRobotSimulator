using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ToyRobot.Shared.Utils;

public static class EnumExtensions
{
    public static TEnum Parse<TEnum>(string value) where TEnum : struct
    {
        return (TEnum)Enum.Parse(typeof(TEnum), value);
    }
    
    public static string? GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()?
            .GetMember(enumValue.ToString())?
            .First()?
            .GetCustomAttribute<DisplayAttribute>()?
            .Name;
    }
    
    public static string? GetDisplayName<T>(this T enumValue) where T : IComparable?, IFormattable?, IConvertible?
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("Argument must be of type Enum");

        var displayAttribute = enumValue?.GetType()
            .GetMember(enumValue.ToString() ?? string.Empty)
            .First()
            .GetCustomAttribute<DisplayAttribute>();

        var displayName = displayAttribute?.GetName();

        return displayName ?? enumValue?.ToString();
    }
}