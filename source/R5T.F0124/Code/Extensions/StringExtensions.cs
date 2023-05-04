using System;


namespace R5T.F0124.Extensions
{
    public static partial class StringExtensions
    {
        /// <inheritdoc cref="F0124.IStringOperator.Trim_NewLines(string)"/>
        public static string Trim_NewLines(this string value)
        {
            return Instances.StringOperator.Trim_NewLines(value);
        }
    }
}
