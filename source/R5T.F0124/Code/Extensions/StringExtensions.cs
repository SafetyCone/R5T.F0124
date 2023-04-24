using System;


namespace R5T.F0124.Extensions
{
    public static class StringExtensions
    {
        public static ILineSeparator ToLineSeparator(this string value)
        {
            return Instances.StringOperator_Extensions.ToLineSeparator(value);
        }
    }
}
