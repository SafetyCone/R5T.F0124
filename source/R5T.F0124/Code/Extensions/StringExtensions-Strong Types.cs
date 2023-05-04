using System;


namespace R5T.F0124.Extensions
{
    public static partial class StringExtensions
    {
        public static IColumnSeparator ToColumnSeparator(this string value)
        {
            return Instances.StringOperator_Extensions.ToColumnSeparator(value);
        }

        public static ILineSeparator ToLineSeparator(this string value)
        {
            return Instances.StringOperator_Extensions.ToLineSeparator(value);
        }
    }
}
