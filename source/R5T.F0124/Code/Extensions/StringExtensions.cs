﻿using System;


namespace R5T.F0124.Extensions
{
    public static partial class StringExtensions
    {
        /// <inheritdoc cref="F0124.IStringOperator.Trim_End(string, string)"/>
        public static string Trim_End(this string value,
            string ending)
        {
            return Instances.StringOperator.Trim_End(
                value,
                ending);
        }

        /// <inheritdoc cref="F0124.IStringOperator.Trim_NewLines(string)"/>
        public static string Trim_NewLines(this string value)
        {
            return Instances.StringOperator.Trim_NewLines(value);
        }

        /// <inheritdoc cref="F0124.IStringOperator.Trim_Start(string, string)"/>
        public static string Trim_Start(this string value,
            string beginning)
        {
            return Instances.StringOperator.Trim_Start(
                value,
                beginning);
        }
    }
}
