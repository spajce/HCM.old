﻿using System.ComponentModel;
using System.Reflection;

namespace HCM.Application.Common.Extensions
{
    public static class EnumExtensions
    {
        public static T? ToEnum<T>(this string description)
        {

            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T?)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T?)field.GetValue(null);
                }
            }
            //throw new ArgumentException("Not found.", "description");
            return default;
        }

        public static string? GetDescription(this System.Enum value)
        {
            if (value == null)
            {
                return null;
            }
            Type type = value.GetType();
            string? name = Enum.GetName(type, value);
            if (name != null)
            {

                FieldInfo? field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute? attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }

                    // Last option
                    return value.ToString();

                }
            }
            return null;
        }
    }
}
